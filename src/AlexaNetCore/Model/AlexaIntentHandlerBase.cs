using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AlexaNetCore.Directives;
using AlexaNetCore.InteractionModel;
using AlexaNetCore.Interfaces;
using AlexaNetCore.RequestModel;
using Microsoft.Extensions.Logging;

namespace AlexaNetCore.Model
{
    public abstract class AlexaIntentHandlerBase
    {
        protected ILogger MsgLogger;

        public AlexaMultiLanguageText DefaultCardTitleText { get; private set; }
        public AlexaMultiLanguageText DefaultCardBodyText { get; private set; }
        public AlexaImageLink DefaultCardLink { get; set; }

        /// <summary>
        /// The order in which the intents will be queried to see if they can handle an intent.  By default the sortOrder is 1000,
        /// but by setting the sort order (at build time or run time) do a lower number, this intent will be asked first whether
        /// it can satisfy an incoming request.  Intents are sorted by IntentType (where Launch is first, then SessionEnd, then Custom), then SortOrder, then order added
        /// </summary>
        public int SortOrder { get; set; } = 1000;

        /// <summary>
        /// Setting this to false will exclude this intent to the interaction model.  It can only be set for Custom intent types
        /// </summary>
        public bool IncludeInInteractionModel
        {
            get => _includeInInteractionModel;
            set => _includeInInteractionModel = IntentType == AlexaIntentType.Custom && value;
        }
        private bool _includeInInteractionModel;

        public AlexaIntentHandlerBase ClearDynamicEntities()
        {
            AddDirective(new AlexaClearDynamicEntitiesDirective());
            return this;
        }

        public AlexaIntentHandlerBase AddDirective(IAlexaDirective dir)
        {
            ResponseEnvInternal.AddDirective(dir);
            return this;
        }

        public AlexaIntentHandlerBase UpdateDynamicEntities(AlexaSlotUpdate slotUpdate)
        {
            var directive = new AlexaUpdateDynamicEntitiesDirective(slotUpdate);
            ResponseEnvInternal.AddDirective(directive);
            return this;
        }

        public AlexaLocale GetLocale()
        {
            return RequestEnvInternal.GetLocale();
        }

        public AlexaIntentHandlerBase RemoveDirective(IAlexaDirective dir)
        {
            ResponseEnvInternal.RemoveDirective(dir);
            return this;
        }

        public AlexaRequestSlot GetAlexaSlot(string slotKey)
        {
            return RequestEnvInternal.GetSlot(slotKey);
        }

        public IEnumerable<AlexaRequestSlot> GetAllSlots()
        {
            return RequestEnvInternal.Request.Intent.GetAllSlots();
        }


        /// <summary>
        /// This can have values of "NONE", "DENIED", or "CONFIRMED".  You will get an empty string if something went wrong.
        /// </summary>
        public string IntentConfirmationStatus => RequestEnvInternal?.Request?.Intent?.ConfirmationStatus ?? "";


        /// <summary>
        /// List of invocations to use for this intent.  Adding invocations here does not affect
        /// the operation of the intent, it just helps with the generation of the IntentCollectionIteractionModel
        /// </summary>
        private List<AlexaMultiLanguageText> SampleInvocations { get; set; } = new List<AlexaMultiLanguageText>();

        public AlexaIntentHandlerBase AddSampleInvocation(string sample)
        {
            SampleInvocations.Add(new AlexaMultiLanguageText(sample));
            return this;
        }

        public AlexaIntentHandlerBase AddSampleInvocation(IEnumerable<string> samples)
        {
            foreach (var sample in samples)
            {
                SampleInvocations.Add(new AlexaMultiLanguageText(sample));
            }
            return this;
        }

        public AlexaIntentHandlerBase AddSampleInvocation(AlexaMultiLanguageText sample)
        {
            SampleInvocations.Add(sample);
            return this;
        }

        public AlexaIntentHandlerBase AddSampleInvocation(IEnumerable<AlexaMultiLanguageText> samples)
        {
            SampleInvocations.AddRange(samples);
            return this;
        }


        /// <summary>
        /// This will add a card to the response only if one is not being returned.
        /// </summary>
        public AlexaIntentHandlerBase WithDefaultCard(AlexaMultiLanguageText title, AlexaMultiLanguageText txt, AlexaImageLink urlLink = null)
        {
            DefaultCardTitleText = title;
            DefaultCardBodyText = txt;
            DefaultCardLink = urlLink;
            return this;
        }

        /// <summary>
        /// this lets the user add a card during the intent handler setup that will be used later.  During
        /// setup there is no response yet to add the card to
        /// </summary>
        private AlexaCard CardToAdd;

        /// <summary>
        /// A standard card is one that has text and an image
        /// </summary>
        public AlexaCard AddCard(string title, string txt, AlexaImageLink urlLink = null)
        {
            var card = new AlexaCard(title,txt, urlLink);
            return AddCard(card);
        }

        /// <summary>
        /// A standard card is one that has text and an image
        /// </summary>
        public AlexaCard AddCard(AlexaMultiLanguageText title, AlexaMultiLanguageText txt, AlexaImageLink urlLink = null)
        {
            var card = new AlexaCard(title,txt, urlLink);
            return AddCard(card);
        }

        /// <summary>
        /// A standard card is one that has text and an image
        /// </summary>
        public AlexaCard AddCard(AlexaCard card)
        {
            if (ResponseEnvInternal == null) CardToAdd = card;
            else
            {
                CardToAdd = null;
                ResponseEnvInternal.AddCard(card);
            }
            return card;
        }


        public AlexaIntentHandlerBase RegisterRequestInterceptor(AlexaBaseRequestInterceptor reqInt)
        {
            RequestInterceptors ??= new List<AlexaBaseRequestInterceptor>();
            RequestInterceptors.Add(reqInt);
            return this;
        }
        private List<AlexaBaseRequestInterceptor> RequestInterceptors;

        public AlexaIntentHandlerBase RegisterResponseInterceptor(AlexaBaseResponseInterceptor respInt)
        {
            ResponseInterceptors ??= new List<AlexaBaseResponseInterceptor>();
            ResponseInterceptors.Add(respInt);
            return this;
        }
        private List<AlexaBaseResponseInterceptor> ResponseInterceptors;

        internal async Task PreProcessAsync()
        {
            await ProcessRequestInterceptorsAsync();
        }

        internal async Task PostProcessAsync()
        {
            AddMissingCard();
            await ProcessResponseInterceptorsAsync();
        }

        internal async Task ProcessRequestInterceptorsAsync()
        {
            if (RequestInterceptors == null) return;
            foreach (var interceptor in RequestInterceptors.OrderBy(i => i.ExecutionOrder))
            {
                await interceptor.ProcessAsync_Internal(RequestEnvInternal);
            }
        }


        internal async Task ProcessResponseInterceptorsAsync()
        {
            if (ResponseInterceptors == null) return;
            foreach (var interceptor in ResponseInterceptors.OrderBy(i => i.ExecutionOrder))
            {
                await interceptor.ProcessAsync_Internal(RequestEnvInternal, ResponseEnvInternal);
            }
        }

        internal void AddMissingCard()
        {
            if (ResponseEnvInternal.HasCard) return;
            if (DefaultCardBodyText == null || DefaultCardTitleText == null) return;
            if (DefaultCardLink == null) AddCard(DefaultCardTitleText, DefaultCardBodyText);
            else AddCard(DefaultCardTitleText, DefaultCardBodyText, DefaultCardLink);
        }

        public string DialogDelegationStrategy { get; set; } = "ALWAYS";

        internal List<AlexaMultiLanguageText> GetSampleInvocations()
        {
            return SampleInvocations.ToList();
        }

        public object GetInteractionModel(AlexaLocale locale = null)
        {
            locale ??= AlexaLocale.English_US;

            dynamic obj = new ExpandoObject();
            obj.name = IntentName;

            var slotObjects = SlotsAvailableToIntent.OrderBy(s => s.SlotOrder).Select(s => s.GetInteractionModelForIntent()).ToArray();
            if (slotObjects.Any()) obj.slots = slotObjects;

            obj.samples = SampleInvocations.Select(i => i.GetText(locale)).ToArray();
            return obj;
        }

        internal bool RequiresDialog => ConfirmationRequired || HasRequiredSlots || HasValidations;
        public bool ConfirmationRequired => Requirements != null;

        public bool HasValidations => SlotsAvailableToIntent.Any(s => s.HasValidations);

        private AlexaRequiredIntentSettings Requirements{ get; set; }

        public AlexaIntentHandlerBase RemoveConfirmation()
        {
            Requirements = null;
            return this;
        }

        public AlexaIntentHandlerBase RequireConfirmation(AlexaRequiredIntentSettings setting)
        {
            Requirements = setting;
            return this;
        }

        public object GetInteractionModelForDialog(AlexaLocale locale = null)
        {
            locale ??= AlexaLocale.English_US;

            dynamic obj = new ExpandoObject();
            obj.name = IntentName;
            obj.delegationStrategy = DialogDelegationStrategy;
            obj.confirmationRequired = ConfirmationRequired;
            if (ConfirmationRequired)
            {
                dynamic confPromptObj = new ExpandoObject();
                confPromptObj.confirmation = Requirements.Prompt.Id;
                obj.prompts = confPromptObj;
            }
            else
            {
                obj.prompts = new ExpandoObject();
            }


            obj.slots = SlotsAvailableToIntent.Where(s => s.IncludeInDialog)
                .Select(s => s.GetInteractionModelForDialog()).ToArray();
            return obj;
        }

        
        private List<AlexaSlot> SlotsAvailableToIntent { get; set; } = new List<AlexaSlot>();

        public List<AlexaSlot> GetSlotOptions => SlotsAvailableToIntent.ToList();


        /// <summary>
        /// Add a user input slot to the intent.  The slot is optional unless you MakeSlotRequired
        /// </summary>
        public AlexaSlot AddSlot(AlexaSlot slot)
        {
            SlotsAvailableToIntent.Add(slot);
            return slot;
        }

        /// <summary>
        /// Add a user input slot to the intent.  The slot is optional unless you MakeSlotRequired
        /// </summary>
        /// <param name="name">Name of the slot. A string that is unique throughout the skill</param>
        /// <param name="slotType">Data type for the slot.  Thsi must be a built in Amazon data type or a custom one</param>
        /// <param name="allowMultipleOptions">True if the user can specify multiple options for this slot, such as "this" and "that"</param>
        /// <returns></returns>
        public AlexaSlot AddSlot(string name, string slotType, bool allowMultipleOptions)
        {
            var slot = new AlexaSlot(name, slotType, allowMultipleOptions);
            SlotsAvailableToIntent.Add(slot);
            return slot;
        }

        public AlexaIntentType IntentType { get; private set; } = AlexaIntentType.Custom;


        public string IntentName { get; private set; }


        /// <summary>
        /// Constructor for a intent handler 
        /// </summary>
        public AlexaIntentHandlerBase(AlexaIntentType reqTyp, string intentName, ILogger log = null)
        {
            if (string.IsNullOrEmpty(intentName)) throw new ArgumentNullException(intentName);
            IntentName = intentName;
            MsgLogger = log;
            IncludeInInteractionModel = reqTyp == AlexaIntentType.Custom;
            IntentType = reqTyp;
        }

        private AlexaRequestEnvelope RequestEnvInternal { get; set; }


        /// <summary>
        /// The request envelope contains all the information coming from Amazon in the request
        /// </summary>
        public IAlexaRequestEnvelope RequestEnv => RequestEnvInternal;


        /// <summary>
        /// Response envelope is where you craft your response
        /// </summary>
        public IAlexaResponseEnvelope ResponseEnv => ResponseEnvInternal;
        
        private AlexaResponseEnvelope ResponseEnvInternal { get; set; }

        public bool IsCustomIntent => IntentType == AlexaIntentType.Custom && !IntentName.StartsWith("AMAZON.");

        private bool HasRequiredSlots => SlotsAvailableToIntent.Any(s => s.IsRequired);


        /// <summary>
        /// Called by the dispatching engine
        /// </summary>
        /// <param name="request"></param>
        /// <param name="response"></param>
        internal void InitIntent(AlexaRequestEnvelope request, AlexaResponseEnvelope response)
        {
            RequestEnvInternal = request ?? throw new ArgumentNullException(nameof(request));
            ResponseEnvInternal = response ?? throw new ArgumentNullException(nameof(ResponseEnvInternal));

            ResponseEnvInternal.IntentHandlerName = IntentName;

            //check if a card was added during intent definition
            if (CardToAdd != null)
            {
                ResponseEnvInternal.AddCard(CardToAdd);
                CardToAdd = null;
            }
        }


        /// <summary>
        /// This sets the text that the device will speak.  This is limited so simple text with no SSL, or multiple languages of simple speech.
        /// </summary>
        public AlexaIntentHandlerBase Speak(string txt)
        {
            ResponseEnvInternal.Speak(txt);
            return this;
        }


        /// <summary>
        /// This sets the text that the device will speak.  This is limited so simple text with no SSL, or multiple languages of simple speech.
        /// </summary>
        public AlexaIntentHandlerBase Speak(AlexaMultiLanguageText txt)
        {
            ResponseEnvInternal.Speak(txt);
            return this;
        }



        /// <summary>
        /// This sets the text that the device will speak.  This is limited so simple text with no SSL, or multiple languages of simple speech.
        /// </summary>
        public AlexaIntentHandlerBase Reprompt(string txt)
        {
            ResponseEnvInternal.Reprompt(txt);
            return this;
        }



        /// <summary>
        /// This sets the text that the device will speak.  This is limited so simple text with no SSL, or multiple languages of simple speech.
        /// </summary>
        public AlexaIntentHandlerBase Reprompt(AlexaMultiLanguageText txt)
        {
            ResponseEnvInternal.Reprompt(txt);
            return this;
        }

        /// <summary>
        /// This will make the device end the session immediately without waiting for further input
        /// </summary>
        public AlexaIntentHandlerBase EndSessionAfterResponse()
        {
            ResponseEnvInternal.ShouldEndSession = true;
            return this;
        }

        /// <summary>
        /// This will keep the session active so your device will continue listening for more interactions
        /// </summary>
        public AlexaIntentHandlerBase KeepSessionActiveAfterResponse()
        {
            ResponseEnvInternal.ShouldEndSession = false;
            return this;
        }


        /// <summary>
        /// Override this method to process the intent.  The RequestEnvInternal and ResponseEnvInternal variables have already been populated
        /// by the time this method is called
        /// </summary>
        public abstract Task ProcessAsync();


        /// <summary>
        /// by default only the specific intent handler can handle the incoming request.  Override this to provide alternative logic
        /// </summary>
        public virtual ICanHandleResponse CanHandle(AlexaRequestEnvelope req)
        {
            //if user is launching and we are a launch intent, then do it!
            //Note that the Alexa console limits to only one launch handler, but ths library allows multiple
            if (req.Request.IsLaunchIntent && IntentType == AlexaIntentType.Launch) return new CanHandleResponse(true);

            //if user is ending and we are session end, then do it.
            if (req.Request.IsSessionEndIntent && IntentType == AlexaIntentType.SessionEnded) return new CanHandleResponse(true);

            //we are a Custom intent handler so check the name
            return new CanHandleResponse(IntentName.Equals(req.Request.Intent.Name, StringComparison.CurrentCultureIgnoreCase));
        }

        /// <summary>
        /// Returns the AlexaRequestSlot object which contains the value the user spoke and other attendant information.
        /// </summary>
        /// <param name="slotName">Name of the slot to retrieve</param>
        protected AlexaRequestSlot GetSlot(string slotName)
        {
            return RequestEnvInternal.Request.Intent.GetSlot(slotName);
        }


        /// <summary>
        /// An easy and simple way of returning the value the user provided for this slot.
        /// If there was a list of options provided for the slot, this will provide the best match according
        /// to the available Authorities.  If no list of options was provided or the users utterance did not match any options
        /// this will return what the user uttered.
        /// To get the full slot with all of the associated parameters including the ID of the slot value chosen use GetSlot instead.
        /// </summary>
        /// <param name="slotName">Name of the slot to retrieve</param>
        /// <param name="defaultVal">Default value if the slot value does not exist</param>
        protected string GetSlotValue(string slotName, string defaultVal = "")
        {
            var slot = GetSlot(slotName);
            if (slot == null) return defaultVal;

            if (slot.BestMatchedValues != null)
            {
                var bestMatch = slot.BestMatchedValues.FirstOrDefault();
                if (bestMatch != null) return bestMatch.Value.Name;
            }

            return slot.Value;
        }


        /// <summary>
        /// Gets the value from the incoming session
        /// </summary>
        /// <param name="valueName"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        protected string GetSessionValue(string valueName, string defaultVal = null)
        {
            return RequestEnvInternal.Session.GetAttributeValue(valueName, defaultVal).ToString();
        }


        /// <summary>
        /// Incoming session values are pulled from the request, not the response.  This is here if you need to
        /// check a value that you've set, but it is not typically used.
        /// </summary>
        /// <param name="valueName"></param>
        /// <param name="defaultVal"></param>
        protected void GetSessionValueFromResponse(string valueName, string defaultVal = null)
        {
            ResponseEnvInternal.SetSessionValue(valueName, defaultVal);
        }

        /// <summary>
        /// Sets the value of the given session variable.  Session variables will persist from one invocation to another,
        /// but not from on session to the next.
        /// </summary>
        /// <param name="sessVariableName">Name of the variable to set</param>
        /// <param name="variableValue">Value to set</param>
        protected void SetSessionValue(string sessVariableName, string variableValue)
        {
            ResponseEnvInternal.SetSessionValue(sessVariableName, variableValue);
        }

        /// <summary>
        /// Setting the incoming request session value is typically only done during debugging when you want to setup a
        /// certain condition.
        /// </summary>
        /// <param name="sessVariableName">Name of the variable to set</param>
        /// <param name="variableValue">Value to set</param>
        protected void SetSessionValueOnRequest(string sessVariableName, string variableValue)
        {
            RequestEnvInternal.SetSessionAttribute(sessVariableName, variableValue);
        }


        internal virtual IEnumerable<AlexaPrompt> GetAllPrompts()
        {
            var lst = new List<AlexaPrompt>();

            if (ConfirmationRequired) lst.Add(Requirements.Prompt);

            foreach (var slot in SlotsAvailableToIntent)
                lst.AddRange(slot.GetAllPrompts());

            return lst;
        }
    }

    public interface ICanHandleResponse
    {
        bool CanHandle { get; set; }
    }

    public class CanHandleResponse : ICanHandleResponse
    {
        public bool CanHandle { get; set; }

        public CanHandleResponse(bool canHandle)
        {
            CanHandle = canHandle;
        }   
    }
}
