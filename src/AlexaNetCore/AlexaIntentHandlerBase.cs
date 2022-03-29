using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlexaNetCore
{
    public abstract class AlexaIntentHandlerBase
    {
        protected IAlexaNetCoreMessageLogger MsgLogger;
        private string dblQuote => "\"";

        /// <summary>
        /// Set this flag to True if this intent is an extension of the previous intent.  For example, the
        /// Yes and No intents operate on a prompt from the previous intent
        /// </summary>
        public bool OperatesOnPreviousIntent { get; protected set; }


        /// <summary>
        /// List of invocations to use for this intent.  Adding invocations here does not affect
        /// the operation of the intent, it just helps with the generation of the InteractionModel
        /// </summary>
        private List<string> SampleInvocations { get; set; } = new List<string>();

        public void AddSampleInvocation(string sample)
        {
            if (!string.IsNullOrEmpty(sample)) SampleInvocations.Add(sample);
        }

        public List<string> GetSampleInvocations()
        {
            return SampleInvocations.ToList();
        }

        public string GetInteractionModelIntentDescriptor()
        {
            var sb = new StringBuilder();
            sb.AppendLine("{");
            sb.AppendLine($"{dblQuote}name{dblQuote}: {dblQuote}{IntentName}{dblQuote},");
            sb.AppendLine($"{dblQuote}samples{dblQuote}: [");
            foreach (var sampleInvocation in SampleInvocations)
            {
                sb.AppendLine($"{dblQuote}{sampleInvocation}{dblQuote}, ");
            }

            var finalStr = sb.ToString();
            if (SampleInvocations.Any()) finalStr = finalStr.Substring(0, finalStr.Length - 4);  //remove ending , and space and carriage return
            return finalStr + "]}";
        }


        public string IntentName { get; internal set; }

        /// <summary>
        /// Constructor for a custom skill
        /// </summary>
        /// <param name="intentName">This intent name must match the intent name in the Alexa Skill creation screen</param>
        /// <param name="log">Logger to use </param>
        public AlexaIntentHandlerBase(string intentName, IAlexaNetCoreMessageLogger log)
        {
            MsgLogger = log;
            IntentName = intentName;
        }

        /// <summary>
        /// Constructor for a custom skill
        /// </summary>
        /// <param name="intentName">This intent name must match the intent name in the Alexa Skill creation screen</param>
        protected AlexaIntentHandlerBase(string intentName)
        {
            IntentName = intentName;
        }

        /// <summary>
        /// The request envelope contains all the information coming from Amazon in the reqeust
        /// </summary>
        public AlexaSkillRequestEnvelope RequestEnv { get; protected set; }

        /// <summary>
        /// Response envelope is where you craft your response
        /// </summary>
        public AlexaSkillResponseEnvelope ResponseEnv { get; protected set; }


        /// <summary>
        /// Called by the dispatching engine
        /// </summary>
        /// <param name="request"></param>
        /// <param name="response"></param>
        internal void InitIntent(AlexaSkillRequestEnvelope request, AlexaSkillResponseEnvelope response)
        {
            RequestEnv = request ?? throw new ArgumentNullException(nameof(request));
            ResponseEnv = response ?? throw new ArgumentNullException(nameof(ResponseEnv));

            ResponseEnv.IntentHandlerName = IntentName;

        }

        /// <summary>
        /// This sets the text that the device will speak.  This is limited so simple text with no SSL, or multiple languages of simple speech.
        /// </summary>
        public void SetShouldEndSession(bool shouldEndSession)
        {
            ResponseEnv.ShouldEndSession = shouldEndSession;
        }

        /// <summary>
        /// This sets the text that the device will speak.  This is limited so simple text with no SSL, or multiple languages of simple speech.
        /// </summary>
        public void SetOutputSpeech(string txt)
        {
            ResponseEnv.SetOutputSpeechText(txt);
        }

        /// <summary>
        /// This sets the text that the device will speak.  This is limited so simple text with no SSL, or multiple languages of simple speech.
        /// </summary>
        public void SetOutputSpeech(AlexaMultiLanguageText txt)
        {
            ResponseEnv.SetOutputSpeechText(txt);
        }

        /// <summary>
        /// This sets the text that the device will speak.  This is limited so simple text with no SSL, or multiple languages of simple speech.
        /// </summary>
        public void SetRepromptSpeech(string txt)
        {
            ResponseEnv.SetRepromptSpeechText(txt);
        }

        /// <summary>
        /// This sets the text that the device will speak.  This is limited so simple text with no SSL, or multiple languages of simple speech.
        /// </summary>
        public void SetRepromptSpeech(AlexaMultiLanguageText txt)
        {
            ResponseEnv.SetRepromptSpeechText(txt);
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
