using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AlexaNetCore.Interfaces;
using AlexaNetCore.Model;
using AlexaNetCore.RequestModel;
using Microsoft.Extensions.Logging;

namespace AlexaNetCore
{
    /// <summary>
    /// Base class all custom skills should derive from
    /// </summary>
    public abstract class AlexaSkillBase : AlexaObjectBase
    {
        /// <summary>
        /// Message Logger for writing debug messages
        /// </summary>
        public ILogger MsgLogger { get; private set; }


        /// <summary>
        /// The parsed contents of the incoming request string
        /// </summary>
        private AlexaRequestEnvelope RequestEnv { get; set; }

        private List<AlexaCustomSlotType> CustomSlotTypes { get; set; } = new List<AlexaCustomSlotType>();

        public AlexaSkillBase AddCustomSlotType(AlexaCustomSlotType customSlotType)
        {
            CustomSlotTypes.Add(customSlotType);
            return this;
        }

        public IEnumerable<AlexaRequestSlot> GetAllSlots()
        {
            return RequestEnv.Request.Intent.GetAllSlots();
        }

      

        public AlexaCard GetCard()
        {
            return ResponseEnv.GetCard();
        }

        public string GetConfirmationStatus()
        {
            return RequestEnv.Request.Intent.ConfirmationStatus;
        }

        /// <summary>
        /// All the components of a value to return back to Amazon
        /// </summary>
        private AlexaResponseEnvelope ResponseEnv { get; set; }

        public AlexaIntentHandlerBase ChosenIntent { get; private set; }

        private List<AlexaIntentHandlerBase> Intents = new List<AlexaIntentHandlerBase>();

        
        public string GetSpokenText(AlexaLocale locale = null)
        {
            locale ??= RequestEnv.Request.Locale;
            return ResponseEnv.GetOutputSpeechText(locale);
        }

        public string GetRepromptText(AlexaLocale locale = null)
        {
            locale ??= RequestEnv.Request.Locale;
            return ResponseEnv.GetRepromptSpeechText(locale);
        }

        public AlexaOutputSpeech GetOutputSpeech()
        {
            return ResponseEnv.GetOutputSpeech();
        }

        public AlexaLocale GetRequestLocale()
        {
            return RequestEnv.Request.Locale;
        }


        public object GetInteractionModel(AlexaLocale locale )
        {
            dynamic interactionModelObj = new ExpandoObject();

            interactionModelObj.languageModel = GetLanguageModel(locale);

            var dlgItems = Intents.Where(i => i.RequiresDialog)
                .Select(i => i.GetInteractionModelForDialog(locale)).ToList();
            if (dlgItems.Any())
            {
                dynamic dlgObj = new ExpandoObject();
                dlgObj.delegationStrategy = DialogDelegrationStrategy;
                dlgObj.intents = dlgItems.ToArray();
                interactionModelObj.dialog = dlgObj;
            }

            var prompts = GetAllPrompts();
            if (prompts != null && prompts.Any())
                interactionModelObj.prompts = prompts.Select(alexaPrompt => alexaPrompt.GetInteractionModel(locale)).ToArray();


            dynamic obj = new ExpandoObject();
            obj.interactionModel = interactionModelObj;
            return obj;
        }

        /// <summary>
        /// Valid values are "ALWAYS", "SKILL_RESPONSE"
        /// </summary>
        public string DialogDelegrationStrategy { get; set; } = "ALWAYS";

        public AlexaSkillBase ValidateInteractionModel(AlexaLocale locale)
        {

            //Sample utterances can consist of only unicode characters, spaces, periods for abbreviations, underscores, possessive apostrophes, and hyphens.
            var errLst = ValidateLanguageModel(locale);

            var prompts = GetAllPrompts();
            errLst.AddRange(ValidatePromptModel(prompts));

            if (errLst.Any()) throw new ArgumentException(errLst.First());
            return this;
        }


        
        public object GetLanguageModel(AlexaLocale locale)
        {
            if (string.IsNullOrEmpty(InvocationName.GetText(locale))) throw new ArgumentNullException();
            var intents = Intents.Where(i => i.IncludeInInteractionModel).OrderBy(i => i.IntentName).ToList();
            if (intents == null) throw new ArgumentNullException();
            if (!intents.Any()) throw new ArgumentNullException();

            dynamic obj = new ExpandoObject();
            obj.invocationName = InvocationName.GetText(locale);

            obj.intents = intents.Select(i => i.GetInteractionModel(locale)).ToArray();

            if (CustomSlotTypes.Any())
            {
                var SlotTypes = CustomSlotTypes.Select(st => st.GetInteractionModel(locale)).ToList();
                if (SlotTypes.Any()) obj.types = SlotTypes.ToArray();
            }

            var fallbackIntent =
                (IFallbackIntentHandler)intents.FirstOrDefault(i => i.IntentName == AlexaBuiltInIntents.FallbackIntent);
            if (fallbackIntent == null) return obj;
            if (fallbackIntent.Sensitivity == "RECOMMENDED") return obj;

            dynamic configObj = new ExpandoObject();
            configObj.fallbackIntentSensitivity = fallbackIntent.Sensitivity;
            obj.modelConfiguration = configObj;
            return obj;
        }

        private List<AlexaPrompt> GetAllPrompts()
        {
            var lst = new List<AlexaPrompt>();
            foreach (var intent in Intents) lst.AddRange(intent.GetAllPrompts());
            return lst;
        }

        internal List<string> ValidatePromptModel(List<AlexaPrompt> prompts)
        {
            var errLst = new List<string>();
            if (prompts.Any(p => p.Id.Contains(" ")))
                errLst.Add("Prompt IDs cannot have spaces in them");
            return errLst;
        }

        internal List<string> ValidateLanguageModel(AlexaLocale locale)
        {
            var errLst = new List<string>();
            if (InvocationName == null) errLst.Add("You must specify an invocation name");
            else if (InvocationName.GetText(locale) != InvocationName.GetText(locale).Trim().ToLower())
            {
                var errMsg = "Invocation name must start with a letter and can only contain lower case letters, spaces, apostrophes, and periods.";
                if (InvocationName.NumLanguages > 1) errMsg = $"({locale.LocaleString}) {errMsg}";
                errLst.Add(errMsg);
            } else if (InvocationName.GetText(locale).StartsWith("ask "))
                errLst.Add("Invocation name must not contain the launch word");


            //at least one custom intent is required
            if (!Intents.Any())
            {
                errLst.Add("No intents are defined");
                return errLst;
            }

            if (Intents.All(i => !i.IsCustomIntent))
                errLst.Add("You must have at least one custom intent");

            LookForRequiredIntents(errLst);

            //each custom intent must have at least one invocation example
            foreach (var intent in Intents.Where(i => i.IsCustomIntent))
            {
                if (!intent.GetSampleInvocations().Any()) errLst.Add($"{intent.IntentName} has no sample invocatios");

                foreach (var sample in intent.GetSampleInvocations())
                {
                    if (sample.GetText(locale).Contains("?"))
                        errLst.Add($"{intent.IntentName} - Question marks are not valid in sample invocations: Sample utterances can consist of only unicode characters, spaces, periods for abbreviations, underscores, possessive apostrophes, and hyphens.");
                    if (sample.GetText(locale).Contains("!"))
                        errLst.Add($"{intent.IntentName} - Exclamation points are not valid in sample invocations: Sample utterances can consist of only unicode characters, spaces, periods for abbreviations, underscores, possessive apostrophes, and hyphens.");

                }
            }

            foreach (var intent in Intents)
            {
                foreach (var slotOption in intent.GetSlotOptions.Where(s => !s.SlotType.StartsWith("AMAZON.")))
                {
                    if (CustomSlotTypes.All(st => st.Name != slotOption.SlotType))
                        errLst.Add(
                            $"Intent '{intent.IntentName}' uses custom slot type '{slotOption.SlotType}' which is not defined.  Names are case sensitive and custom slot types are defined at the Skill level.");
                }
            }

            return errLst;
        }

        private void LookForRequiredIntents(List<string> errLst)
        {
            //these intents are required
            if (Intents.All(i => i.IntentType != AlexaIntentType.Launch))
                errLst.Add("A Launch Request intent is required");

            if (Intents.All(i => i.IntentType != AlexaIntentType.SessionEnded) )
                errLst.Add("A Session Ended Request intent is required");

            if (Intents.All(i => i.IntentType != AlexaIntentType.Custom && i.IntentName != AlexaBuiltInIntents.HelpIntent ))
                errLst.Add("AMAZON.HelpIntent is required ");

            if (Intents.All(i => i.IntentType != AlexaIntentType.Custom && i.IntentName != AlexaBuiltInIntents.StopIntent ))
                errLst.Add("A Stop intent is required ");

            if (Intents.All(i => i.IntentType != AlexaIntentType.Custom && i.IntentName != AlexaBuiltInIntents.CancelIntent ))
                errLst.Add("A Cancel intent is required ");
            
            if (Intents.All(i => i.IntentType != AlexaIntentType.Custom && i.IntentName != AlexaBuiltInIntents.FallbackIntent ))
                errLst.Add("A Fallback intent is required ");

            if (Intents.All(i => i.IntentType != AlexaIntentType.Custom && i.IntentName != AlexaBuiltInIntents.NavigateHomeIntent ))
                errLst.Add("A Navigate Home intent is required ");

        }

        /// <summary>
        /// String used to invoke this skill.  This is only needed when auto-generating the interaction model.
        /// Invocation name must start with a letter and can only contain lower case letters, spaces, apostrophes, and periods.
        /// </summary>
        public AlexaMultiLanguageText InvocationName { get; private set; }


        public AlexaSkillBase SetInvocationName(string name)
        {
            InvocationName = new AlexaMultiLanguageText(name);
            return this;
        }
        
        public AlexaSkillBase SetInvocationName(AlexaMultiLanguageText name)
        {
            InvocationName = name;
            return this;
        }

        protected AlexaSkillBase(ILoggerFactory loggerFactory)
        {
            MsgLogger = loggerFactory.CreateLogger<AlexaSkillBase>();
        }


        /// <summary>
        /// The version of this skill
        /// </summary>
        public string SkillVersion { get; private set; }

        protected AlexaSkillBase SetSkillVersion(string newVersion)
        {
            SkillVersion = newVersion;
            if (RequestEnv != null) RequestEnv.Version = newVersion;
            return this;
        }

        public AlexaMultiLanguageText IntentNotFoundMessage { get; set; } = new AlexaMultiLanguageText(
            "I'm sorry, I could not figure out what you want me to do.  Please try again");

        public async Task<AlexaSkillBase> ProcessRequestAsync()
        {
            try
            {
                await ProcessRequestInterceptorsAsync(RequestEnv);
                ResponseEnv = new AlexaResponseEnvelope(RequestEnv, MsgLogger) { Version = SkillVersion };
                await ProcessIntentRequestAsync();
                ResponseEnv = await ProcessResponseInterceptorsAsync(RequestEnv, ResponseEnv);
                return this;
            }
            catch (Exception exc)
            {
                MsgLogger?.LogError($"{this.GetType().Name} LogError ProcessIntentRequestAsync", exc);
                ResponseEnv.Speak(IntentNotFoundMessage);
                ResponseEnv.ShouldEndSession = true;
                return null;
            }

        }


        /// <summary>
        /// Examines the incoming request and decides how it should be handled, then returns an Alexa appropriate JSON string
        /// </summary>
        public AlexaSkillBase LoadRequest(string postedJsonData)
        {

            if (string.IsNullOrEmpty(postedJsonData))
            {
                MsgLogger?.LogError($"{this.GetType().Name} No Data to create request and response");
                throw new ArgumentNullException("postedJsonData", "No data to create request and response");
            }

            MsgLogger?.LogDebug($"postedJsonData: {postedJsonData}");

            try
            {
                RequestEnv  = JsonSerializer.Deserialize<AlexaRequestEnvelope>(postedJsonData);
                return LoadRequest(RequestEnv);
            }
            catch (Exception exc)
            {
                MsgLogger?.LogError($"{this.GetType().Name} ProcessRequestAsync LogError parsing request envelope", exc);
                ProcessErrorInRequest();
                return null;
            }

        }

        public AlexaSkillBase LoadRequest(AlexaRequestEnvelope env)
        {
            try
            {
                RequestEnv = env;
                return this;
            }
            catch (Exception exc)
            {
                MsgLogger?.LogError($"{this.GetType().Name} LogError parsing request envelope", exc);
                ProcessErrorInRequest();
                return null;
            }
        }

        /// <summary>
        /// Returns a string in JSON format that the Alexa Services can use on an Echo
        /// </summary>
        public string GetResponse()
        {
            var responseStr = ResponseEnv.CreateAlexaResponse();
            MsgLogger?.LogDebug($"Response str after intent {RequestEnv.Request.Intent?.Name}: {responseStr}");
            return responseStr;
        }


        /// <summary>
        /// Gets called when something went wrong in processing the request
        /// </summary>
        protected virtual void ProcessErrorInRequest()
        {
            var intent = Intents.FirstOrDefault(i => i.IntentName == AlexaBuiltInIntents.HelpIntent);
            intent?.InitIntent(RequestEnv, ResponseEnv);
            intent?.ProcessAsync();
        }

        /// <summary>
        /// Processes a Launch Request
        /// </summary>
        private async Task<AlexaIntentHandlerBase> ProcessIntentRequestAsync()
        {
            try
            {
                ChosenIntent = GetIntentToProcess(RequestEnv);

                MsgLogger?.LogDebug("Request being handled by " + ChosenIntent.IntentName);

                ChosenIntent.InitIntent(RequestEnv, ResponseEnv);

                await ChosenIntent.PreProcessAsync();
                await ChosenIntent.ProcessAsync();
                await ChosenIntent.PostProcessAsync();
            }
            catch (Exception exc)
            {
                MsgLogger?.LogError($"{this.GetType().Name} LogError ProcessIntentRequestAsync", exc);
                return null;
            }
            return ChosenIntent;
        }


        private AlexaIntentHandlerBase GetIntentToProcess(AlexaRequestEnvelope requestEnv)
        {
            AlexaIntentHandlerBase chosenIntent = null;

            IEnumerable<AlexaIntentHandlerBase> validIntents;

            if (requestEnv.Request.IsLaunchIntent) 
                validIntents= Intents.Where(i => i.IntentType == AlexaIntentType.Launch );
            else if (requestEnv.Request.IsSessionEndIntent)
                validIntents = Intents.Where(i => i.IntentType == AlexaIntentType.SessionEnded );
            else if (requestEnv.Request.IsCustomIntent)
                validIntents = Intents.Where(i => i.IntentType == AlexaIntentType.Custom);
            else return GetHelpIntent();


            chosenIntent = validIntents.OrderBy(i => i.SortOrder)
                .FirstOrDefault(i => i.CanHandle(requestEnv).CanHandle);

            if (chosenIntent == null) chosenIntent = validIntents.FirstOrDefault();


            if (chosenIntent == null)
            {
                MsgLogger?.LogWarning($"Could not find intent with name '{requestEnv.Request.Intent.Name}' - returning the Help intent");
                chosenIntent = GetHelpIntent();
            }

            return chosenIntent;
        }


        private AlexaIntentHandlerBase GetHelpIntent()
        {
            return Intents.FirstOrDefault(i => i.IntentName.Equals(AlexaBuiltInIntents.HelpIntent, StringComparison.CurrentCultureIgnoreCase) );
        }


        public T GetResponseSessionValue<T>(string sessionKey, T defaultVal)
        {
            return ResponseEnv.GetSessionValue(sessionKey, defaultVal);
        }


        /// <summary>
        /// THis flag is read only.  To change its value call either KeepSessionActiveAfterResponse() or EndSessionAfterResponse()
        /// </summary>
        public bool? ShouldEndSession => ResponseEnv.ShouldEndSession;


        public AlexaCard AddCard(string title, string txt, AlexaImageLink urlLink = null)
        {
            return ResponseEnv.AddCard(
                new AlexaMultiLanguageText(title),
                new AlexaMultiLanguageText(txt), urlLink);
        }

        public AlexaCard AddCard(AlexaMultiLanguageText title, AlexaMultiLanguageText txt, AlexaImageLink urlLink = null)
        {
            return ResponseEnv.AddCard(title, txt, urlLink);
        }

        
        /// <summary>
        /// Request interceptors allow you to pre-process the incoming request to manipulate it to
        /// your own purposes.  An example of this would be a source language setter that changes
        /// the incoming source language to a value you need for testing.  Request interceptors
        /// are run in the order they are registered
        /// </summary>
        public AlexaSkillBase RegisterRequestInterceptor(AlexaBaseRequestInterceptor reqInt)
        {
            RequestInterceptors ??= new List<AlexaBaseRequestInterceptor>();
            RequestInterceptors.Add(reqInt);
            return this;
        }


        public AlexaIntentHandlerBase GetRegisteredIntent(AlexaIntentType typ,  string intentName)
        {
            var intent = Intents.FirstOrDefault(i => i.IntentType == typ && i.IntentName == intentName);
            if (intent == null) throw new ArgumentException($"Intent '{intentName}' not found ");
            return intent;
        }

        private List<AlexaBaseRequestInterceptor> RequestInterceptors;

        private async Task ProcessRequestInterceptorsAsync(AlexaRequestEnvelope env)
        {
            if (RequestInterceptors == null) return ;
            foreach (var requestInterceptor in RequestInterceptors.OrderBy(i => i.ExecutionOrder))
            {
                await requestInterceptor.ProcessAsync_Internal(env);    
            }
        }

        /// <summary>
        /// Response interceptors allow you to post-process the outgoing response to manipulate it to
        /// your own purposes.  An example of this would be adding a reprompt to any responses that don't
        /// already have one.  Response interceptors are run in the order they are registered
        /// </summary>
        public AlexaSkillBase RegisterResponseInterceptor(AlexaBaseResponseInterceptor respInt)
        {
            ResponseInterceptors ??= new List<AlexaBaseResponseInterceptor>();
            ResponseInterceptors.Add(respInt);
            return this;
        }
        private List<AlexaBaseResponseInterceptor> ResponseInterceptors;


        private async Task<AlexaResponseEnvelope> ProcessResponseInterceptorsAsync(AlexaRequestEnvelope reqEnv, AlexaResponseEnvelope env)
        {
            if (ResponseInterceptors == null) return env;
            foreach (var interceptor in ResponseInterceptors.OrderBy(r => r.ExecutionOrder))
            {
                await interceptor.ProcessAsync_Internal(reqEnv, env);
            }
            return env;
        }


        protected internal AlexaSkillBase UnregisterIntentHandler(AlexaIntentHandlerBase intent)
        {
            var existingIntent = Intents.FirstOrDefault(i =>
                i.IntentName.Equals(intent.IntentName, StringComparison.CurrentCultureIgnoreCase));
            if (existingIntent != null) Intents.Remove(existingIntent);
            return this;
        }

        /// <summary>
        /// Registers an intent handler, potentially replacing the existing one if one is already registered by that name
        /// </summary>
        protected internal AlexaSkillBase RegisterIntentHandler(AlexaIntentHandlerBase intent)
        {
            if (intent.IntentType == AlexaIntentType.Launch)
            {
                var existingLaunchHandler = Intents.FirstOrDefault(i => i.IntentType == AlexaIntentType.Launch);
                if (existingLaunchHandler != null)
                    throw new ArgumentException($"{existingLaunchHandler.IntentName} Launch Intent is already registered while {intent.IntentName} was submitted");
            }

            if (intent.IntentType == AlexaIntentType.SessionEnded)
            {
                var endIntent = Intents.FirstOrDefault(i => i.IntentType == AlexaIntentType.SessionEnded);
                if (endIntent != null)
                    throw new ArgumentException($"{endIntent.IntentName} Session Ended Intent is already registered while {intent.IntentName} was submitted");
            }

            if (Intents.Any(i => i.IntentName.Equals(intent.IntentName, StringComparison.CurrentCultureIgnoreCase))) 
                throw new ArgumentException($"Intent handler {intent.IntentName} already registered");
             
            Intents.Add(intent);
            return this;
        }


        [Obsolete("Changing this call to Reprompt to be inline with Alexa Developer Console")]
        public AlexaSkillBase SetRepromptSpeach(AlexaMultiLanguageText txt)
        {
            return Reprompt(txt);
        }

        public AlexaSkillBase Reprompt(AlexaMultiLanguageText txt)
        {
            ResponseEnv.Reprompt(txt);
            return this;
        }


        public bool IsRepromptSet => ResponseEnv.IsRepromptSet;

        [Obsolete("Changing this call to Reprompt to be inline with Alexa Developer Console")]
        public AlexaSkillBase SetRepromptSpeach(string txt)
        {
            return Reprompt(txt);
        }

        public AlexaSkillBase Reprompt(string txt)
        {
            ResponseEnv.Reprompt(txt);
            return this;
        }

        public AlexaSkillBase EndSessionAfterResponse()
        {
            ResponseEnv.ShouldEndSession = true;
            return this;
        }
        
        public AlexaSkillBase KeepSessionActiveAfterResponse()
        {
            ResponseEnv.ShouldEndSession = false;
            return this;
        }
    }
}
