using System;
using System.Collections.Generic;

namespace AlexaSkillDotNet
{
    public abstract class AlexaIntentHandlerBase
    {
        protected IAlexaSkillMessageLogger MsgLogger;

        public bool AddThisIntentToIntentHistory { get; protected set; }


        /// <summary>
        /// Set this flag to True if this intent is an extension of the previous intent.  For example, the
        /// Yes and No intents operate on a prompt from the previous intent
        /// </summary>
        public bool OperatesOnPreviousIntent { get; protected set; }


        public string IntentName { get; internal set; }

        protected Dictionary<int, string> IntentHistory { get; set; }

        protected int IntentHistorySize { get; set; } = 10;

        public AlexaIntentHandlerBase(string intentName, IAlexaSkillMessageLogger log)
        {
            MsgLogger = log;
            IntentName = intentName;
        }

        public AlexaSkillRequestEnvelope RequestEnv { get; protected set; }

        public AlexaSkillResponseEnvelope ResponseEnv { get; protected set; }


        internal void InitIntent(AlexaSkillRequestEnvelope request, AlexaSkillResponseEnvelope response)
        {
            RequestEnv = request ?? throw new ArgumentNullException(nameof(request));
            ResponseEnv = response ?? throw new ArgumentNullException(nameof(ResponseEnv));

            ResponseEnv.IntentHandlerName = IntentName;
            
            if (AddThisIntentToIntentHistory)
            {
                IntentHistory = RequestEnv.GetIntentHistory();
                ResponseEnv.AddToIntentHistory(RequestEnv.Request.Intent.Name, IntentHistory, IntentHistorySize);
            }

        }

        /// <summary>
        /// This sets the text that the device will speak.  This is limited so simple text with no SSL, or multiple languages of simple speech.
        /// </summary>
        public void SetShouldEndSession(bool shouldEndSession)
        {
            ResponseEnv.Response.ShouldEndSession = shouldEndSession;
        }

        /// <summary>
        /// This sets the text that the device will speak.  This is limited so simple text with no SSL, or multiple languages of simple speech.
        /// </summary>
        public void SetOutputSpeech(string txt)
        {
            ResponseEnv.SetOutputSpeech(txt);
        }

        /// <summary>
        /// This sets the text that the device will speak.  This is limited so simple text with no SSL, or multiple languages of simple speech.
        /// </summary>
        public void SetOutputSpeech(AlexaMultiLanguageText txt)
        {
            ResponseEnv.SetOutputSpeech(txt);
        }

        /// <summary>
        /// This sets the text that the device will speak.  This is limited so simple text with no SSL, or multiple languages of simple speech.
        /// </summary>
        public void SetRepromptSpeech(string txt)
        {
            ResponseEnv.SetRepromptSpeech(txt);
        }

        /// <summary>
        /// This sets the text that the device will speak.  This is limited so simple text with no SSL, or multiple languages of simple speech.
        /// </summary>
        public void SetRepromptSpeech(AlexaMultiLanguageText txt)
        {
            ResponseEnv.SetRepromptSpeech(txt);
        }
        
        /// <summary>
        /// Override this method to process the intent.  The RequestEnv and ResponseEnv variables have already been populated
        /// </summary>
        public abstract void Process();

        protected T GetSlotValue<T>(string slotName, T defaultVal)
        {
            return RequestEnv.Request.Intent.GetSlotValue(slotName, defaultVal);
        }

        protected string GetSessionValue(string valueName, string defaultVal)
        {
            return RequestEnv.Session.GetAttributeValue(valueName,defaultVal).ToString();
        }

        protected void SetSessionValue(string valueName, string val)
        {
            ResponseEnv.SetAttributeValue(valueName, val);
        }
    }


}
