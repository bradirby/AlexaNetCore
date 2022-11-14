using System.Collections.Generic;
using System.Dynamic;
using AlexaNetCore.Interfaces;
using Microsoft.Extensions.Logging;

namespace AlexaNetCore.Model
{


    public class AlexaReprompt
    {
        private ILogger MsgLogger;

        public IList<string> Validate()
        {
            var errLst = new List<string>();
            if (OutputSpeech == null) errLst.Add("Nothing in OutputSpeech in Reprompt");
            return errLst;
        }


        public AlexaReprompt(string repromptText, ILogger log = null)
        {
            MsgLogger = log;
            OutputSpeech = new AlexaOutputSpeech(AlexaLocale.English_US, MsgLogger);
            OutputSpeech.SetText(repromptText);
        }

        public AlexaReprompt(AlexaMultiLanguageText repromptText, ILogger log = null)
        {
            MsgLogger = log;
            OutputSpeech = new AlexaOutputSpeech(AlexaLocale.English_US, MsgLogger);
            OutputSpeech.SetText(repromptText);
        }

        /// <summary>
        /// The object containing the outputSpeech to use if a re-prompt is necessary.
        /// This is used if your service keeps the session open after sending the response, 
        /// but the user does not respond with anything that maps to an intent defined in your voice interface while the audio stream is open.
        /// If this is not set, the user is not re-prompted.
        /// </summary>
        public AlexaOutputSpeech OutputSpeech { get; set; }


        public object CreateAlexaResponse(AlexaLocale locale)
        {
            var outputSpeechObj = OutputSpeech.CreateAlexaResponse(locale);
            if (outputSpeechObj == null) return null;

            dynamic obj = new ExpandoObject();
            obj.outputSpeech = outputSpeechObj;

            return obj;

        }

    }
}