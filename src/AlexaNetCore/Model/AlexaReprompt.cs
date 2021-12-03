using System;
using System.Dynamic;
using System.Runtime.Serialization;

namespace AlexaNetCore
{


    public class AlexaReprompt
    {
        private IAlexaNetCoreMessageLogger MsgLogger;

        public AlexaReprompt(string repromptText, IAlexaNetCoreMessageLogger log)
        {
            MsgLogger = log;
            OutputSpeech = new AlexaOutputSpeech(AlexaLocale.English_US, MsgLogger);
            OutputSpeech.SetText(repromptText);
        }

        public AlexaReprompt(AlexaMultiLanguageText repromptText, IAlexaNetCoreMessageLogger log)
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

        public void SetDefaultLocale(AlexaLocale locale)
        {
            OutputSpeech.SetDefaultLocale(locale);
        }

        public object GetJson()
        {
            return GetJson(OutputSpeech.DefaultLocale);
        }

        public object GetJson(AlexaLocale locale, IAlexaTranslationService translator = null)
        {
            var outputSpeechObj = OutputSpeech.GetJson(locale, translator);
            if (outputSpeechObj == null) return null;

            dynamic obj = new ExpandoObject();
            obj.outputSpeech = outputSpeechObj;

            return obj;

        }

    }
}