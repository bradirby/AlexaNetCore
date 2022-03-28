using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AlexaNetCore.Model;
using Amazon.Lambda.Core;

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
        public IAlexaNetCoreMessageLogger MsgLogger { get; private set; }

        /// <summary>
        /// The parsed contents of the incoming request string
        /// </summary>
        public AlexaSkillRequestEnvelope RequestEnv { get; private set; }

        /// <summary>
        /// All the components of a value to return back to Amazon
        /// </summary>
        public AlexaSkillResponseEnvelope ResponseEnv { get; private set; }

        private AlexaIntentHandlerBase ChosenIntent { get; set; }

        private List<AlexaIntentHandlerBase> Intents = new List<AlexaIntentHandlerBase>();



        
        protected AlexaSkillBase()
        {
            MsgLogger = new ConsoleMessageLogger();
        }

        protected AlexaSkillBase(IAlexaNetCoreMessageLogger log)
        {
            MsgLogger = log ?? null;
        }

        protected AlexaSkillBase(ILambdaLogger log)
        {
            MsgLogger = log == null ? null : new ConsoleMessageLogger(log);
        }

        private AlexaLocale defaultResponseLocale = AlexaLocale.English_US;

        /// <summary>
        /// Locale to be used in the response if no locale is specified.
        /// </summary>
        public AlexaSkillBase SetDefaultResponseLocale(AlexaLocale locale)
        {
            defaultResponseLocale = locale;
            ResponseEnv?.SetDefaultResponseLocale(defaultResponseLocale);
            return this;
        }

        public AlexaSkillBase SetLogger(IAlexaNetCoreMessageLogger log)
        {
            MsgLogger = log;
            return this;
        }

        public AlexaSkillBase SetLogger(ILambdaLogger log)
        {
            MsgLogger = new ConsoleMessageLogger(log);
            return this;
        }


        /// <summary>
        /// Make sure to ignore missing members when parsing
        /// </summary>
        protected static JsonSerializerOptions DeserializationSettings = new JsonSerializerOptions
        {
            IgnoreNullValues = true
        };

        /// <summary>
        /// The version of this skill
        /// </summary>
        public string SkillVersion => _skillVersion;

        private string _skillVersion = "1.0";  //default version - set to your version using the SkillVersion property

        protected AlexaSkillBase SetSkillVersion(string newVersion)
        {
            _skillVersion = newVersion;
            if (RequestEnv != null) RequestEnv.Version = newVersion;
            return this;
        }

        public AlexaSkillBase ProcessRequest()
        {
            try
            {
                //doing this here instead of in the LoadRequest  allows for modifying the request before processing
                ResponseEnv = new AlexaSkillResponseEnvelope(RequestEnv, MsgLogger) { Version = SkillVersion };
                ProcessIntentRequest();
                return this;
            }
            catch (Exception exc)
            {
                MsgLogger?.Error($"{this.GetType().Name} Error ProcessIntentRequest", exc);
                ResponseEnv.SetOutputSpeechText("I'm sorry, I could not figure out what you want me to do.  Please try again");
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
                MsgLogger?.Error($"{this.GetType().Name} No Data to create request and response");
                throw new ArgumentNullException("postedJsonData", "No data to create request and response");
            }

            MsgLogger?.Debug($"postedJsonData: {postedJsonData}");

            try
            {
                RequestEnv  = JsonSerializer.Deserialize<AlexaSkillRequestEnvelope>(postedJsonData);
                return LoadRequest(RequestEnv);
            }
            catch (Exception exc)
            {
                MsgLogger?.Error($"{this.GetType().Name} ProcessRequest Error parsing request envelope", exc);
                ProcessErrorInRequest();
                return null;
            }

        }

        public AlexaSkillBase LoadRequest(AlexaSkillRequestEnvelope env)
        {
            try
            {
                //parse data from the request, and copy over info into response
                RequestEnv  = env;
                return this;
            }
            catch (Exception exc)
            {
                MsgLogger?.Error($"{this.GetType().Name} Error parsing request envelope", exc);
                ProcessErrorInRequest();
                MsgLogger?.Error($"{this.GetType().Name}", ResponseEnv);
                return null;
            }
        }

        /// <summary>
        /// Returns a string in JSON format that the Alexa Services can use on an Echo
        /// </summary>
        public string CreateAlexaResponse(IAlexaTranslationService translator = null)
        {
            var responseStr = ResponseEnv.CreateAlexaResponse(translator);

            MsgLogger?.Debug($"Response str after intent {RequestEnv.Request.Intent?.Name}: {responseStr}");
            return responseStr;
        }


        /// <summary>
        /// This method validates the response and logs any errors found to the given logger.  It will never throw
        /// any exceptions, just log the issues that are found.
        /// </summary>
        public AlexaSkillBase ValidateResponse()
        {
            try
            {
                ResponseEnv.ValidateResponse();
            }
            catch (Exception)
            {
                //ignore
            }
            return this;
        }

        /// <summary>
        /// Gets called when something went wrong in processing the request
        /// </summary>
        protected virtual void ProcessErrorInRequest()
        {
            var intent = Intents.FirstOrDefault(i => i.IntentName == AlexaBuiltInIntents.HelpIntent);
            intent?.InitIntent(RequestEnv, ResponseEnv);
            intent?.Process();
        }

        /// <summary>
        /// Processes a Launch Request
        /// </summary>
        private AlexaIntentHandlerBase ProcessIntentRequest()
        {
            try
            {
                ChosenIntent = GetIntentToProcess(RequestEnv);

                if (ChosenIntent.OperatesOnPreviousIntent)
                {
                    MsgLogger?.Information($"Changed to intent {ChosenIntent.IntentName}");
                    ChosenIntent = GetPreviousSignificantIntent(ChosenIntent);
                }

                MsgLogger?.Debug("Request being handled by " + ChosenIntent.IntentName);

                ChosenIntent.InitIntent(RequestEnv, ResponseEnv);
                ChosenIntent.Process();
            }
            catch (Exception exc)
            {
                MsgLogger?.Error($"{this.GetType().Name} Error ProcessIntentRequest", exc);
                return null;
            }
            return ChosenIntent;
        }

        private AlexaIntentHandlerBase GetPreviousSignificantIntent(AlexaIntentHandlerBase defaultIntent)
        {
            var history = RequestEnv.GetIntentHistory();
            for (int n = 1; n <= history.Count; n++)
            {
                var intentName = history[n];
                var i = GetIntentByName(intentName);
                if (!i.OperatesOnPreviousIntent) return i;
            }
            return defaultIntent;
        }


        private AlexaIntentHandlerBase GetIntentToProcess(AlexaSkillRequestEnvelope request)
        {
            if (request.Request.RequestType == AlexaRequestType.IntentRequest)
            {
                return GetIntentByName(request.Request.Intent.Name);
            }
            return GetIntentByName(request.Request.RequestType);
        }

        private AlexaIntentHandlerBase GetIntentByName(string intentName)
        {
            var intent = Intents.FirstOrDefault(i => i.IntentName.Equals(intentName, StringComparison.CurrentCultureIgnoreCase) );
            if (intent == null)
            {
                MsgLogger?.Warning($"Could not find intent with name '{intentName}' - returning the Help intent");
                intent = Intents.FirstOrDefault(i => i.IntentName.Equals(AlexaBuiltInIntents.HelpIntent, StringComparison.CurrentCultureIgnoreCase) );
            }
            return intent;
        }

        /// <summary>
        /// This will register defaults for all missing built-in intent handlers.  If an intent handler is already specified, it will not be changed unless you set replaceExisting = true
        /// </summary>
        /// <param name="replaceExisting">Parameter that determines if any existing intent handlers should be replaced</param>
        protected internal AlexaSkillBase RegisterDefaultIntentHandlers(bool replaceExisting = false)
        {
            RegisterIntentHandler(new DefaultCancelIntentHandler(MsgLogger), replaceExisting);
            RegisterIntentHandler(new DefaultHelpIntentHandler(MsgLogger), replaceExisting);
            RegisterIntentHandler(new DefaultFallbackIntentHandler(MsgLogger), replaceExisting);
            RegisterIntentHandler(new DefaultLaunchIntentHandler(MsgLogger), replaceExisting);
            RegisterIntentHandler(new DefaultLoopOffIntentHandler(MsgLogger), replaceExisting);
            RegisterIntentHandler(new DefaultLoopOnIntentHandler(MsgLogger), replaceExisting);
            RegisterIntentHandler(new DefaultNextIntentHandler(MsgLogger), replaceExisting);
            RegisterIntentHandler(new DefaultNoIntentHandler(MsgLogger), replaceExisting);
            RegisterIntentHandler(new DefaultPauseIntentHandler(MsgLogger), replaceExisting);
            RegisterIntentHandler(new DefaultPreviousIntentHandler(MsgLogger), replaceExisting);
            RegisterIntentHandler(new DefaultRepeatIntentHandler(MsgLogger), replaceExisting);
            RegisterIntentHandler(new DefaultResumeIntentHandler(MsgLogger), replaceExisting);
            RegisterIntentHandler(new DefaultSessionEndRequest(MsgLogger), replaceExisting);
            RegisterIntentHandler(new DefaultShuffleOffIntentHandler(MsgLogger), replaceExisting);
            RegisterIntentHandler(new DefaultShuffleOnIntentHandler(MsgLogger), replaceExisting);
            RegisterIntentHandler(new DefaultStartOverIntentHandler(MsgLogger), replaceExisting);
            RegisterIntentHandler(new DefaultStopIntentHandler(MsgLogger), replaceExisting);
            RegisterIntentHandler(new DefaultYesIntentHandler(MsgLogger), replaceExisting);

            return this;
        }

        /// <summary>
        /// This will register defaults for all missing built-in intent handlers.  If an intent handler is already specified, it will not be changed unless you set replaceExisting = true
        /// </summary>
        /// <param name="replaceExisting">Parameter that determines if any existing intent handlers should be replaced</param>
        protected internal AlexaSkillBase RegisterDefaultIntentHandlers(string txt, bool replaceExisting = false)
        {
            return RegisterDefaultIntentHandlers(new AlexaMultiLanguageText(txt), replaceExisting);
        }

        /// <summary>
        /// This will register defaults for all missing built-in intent handlers.  If an intent handler is already specified, it will not be changed unless you set replaceExisting = true
        /// </summary>
        /// <param name="replaceExisting">Parameter that determines if any existing intent handlers should be replaced</param>
        protected internal AlexaSkillBase RegisterDefaultIntentHandlers(AlexaMultiLanguageText txt, bool replaceExisting = false)
        {
            RegisterIntentHandler(new DefaultCancelIntentHandler(txt, MsgLogger), replaceExisting);
            RegisterIntentHandler(new DefaultHelpIntentHandler(txt, MsgLogger), replaceExisting);
            RegisterIntentHandler(new DefaultFallbackIntentHandler(txt, MsgLogger), replaceExisting);
            RegisterIntentHandler(new DefaultLaunchIntentHandler(txt, MsgLogger), replaceExisting);
            RegisterIntentHandler(new DefaultLoopOffIntentHandler(txt, MsgLogger), replaceExisting);
            RegisterIntentHandler(new DefaultLoopOnIntentHandler(txt, MsgLogger), replaceExisting);
            RegisterIntentHandler(new DefaultNextIntentHandler(txt, MsgLogger), replaceExisting);
            RegisterIntentHandler(new DefaultNoIntentHandler(txt, MsgLogger), replaceExisting);
            RegisterIntentHandler(new DefaultPauseIntentHandler(txt, MsgLogger), replaceExisting);
            RegisterIntentHandler(new DefaultPreviousIntentHandler(txt, MsgLogger), replaceExisting);
            RegisterIntentHandler(new DefaultRepeatIntentHandler(txt, MsgLogger), replaceExisting);
            RegisterIntentHandler(new DefaultResumeIntentHandler(txt, MsgLogger), replaceExisting);
            RegisterIntentHandler(new DefaultSessionEndRequest(txt, MsgLogger), replaceExisting);
            RegisterIntentHandler(new DefaultShuffleOffIntentHandler(txt, MsgLogger), replaceExisting);
            RegisterIntentHandler(new DefaultShuffleOnIntentHandler(txt, MsgLogger), replaceExisting);
            RegisterIntentHandler(new DefaultStartOverIntentHandler(txt, MsgLogger), replaceExisting);
            RegisterIntentHandler(new DefaultStopIntentHandler(txt, MsgLogger), replaceExisting);
            RegisterIntentHandler(new DefaultYesIntentHandler(txt, MsgLogger), replaceExisting);

            return this;
        }

        /// <summary>
        /// Registers an intent handler, potentially replacing the existing one if one is already registered by that name
        /// </summary>
        protected void RegisterIntentHandler(AlexaIntentHandlerBase intent, bool replaceExisting = true)
        {
            var existingIntent = Intents.FirstOrDefault(i => i.IntentName.Equals(intent.IntentName, StringComparison.CurrentCultureIgnoreCase));
            if (existingIntent == null)
            {
                Intents.Add(intent);
                return;
            }

            if (!replaceExisting) return;

            Intents.Remove(existingIntent);
            Intents.Add(intent);
        }

        public AlexaSkillBase SetShouldEndSession(bool shouldEndSession)
        {
            ResponseEnv.ShouldEndSession = shouldEndSession;
            return this;
        }

        public AlexaSkillBase SetRepromptSpeach(AlexaMultiLanguageText txt)
        {
            ResponseEnv.SetRepromptSpeechText(txt);
            return this;
        }

        public bool IsRepromptSet => ResponseEnv.IsRepromptSet;

        public AlexaSkillBase SetRepromptSpeach(string txt)
        {
            ResponseEnv.SetRepromptSpeechText(txt);
            return this;
        }

    }
}
