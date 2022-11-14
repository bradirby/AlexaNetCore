using System;
using System.Collections.Generic;
using System.Dynamic;
using AlexaNetCore.Interfaces;
using Microsoft.Extensions.Logging;

namespace AlexaNetCore.Model
{
    /// <summary>
    /// The object containing the speech to render to the user.
    /// </summary>
    public class AlexaOutputSpeech
    {
        private ILogger MsgLogger;
        public AlexaOutputSpeech(AlexaLocale locale, ILogger log = null)
        {
            MsgLogger = log;
            SpeechType = AlexaOutputSpeechType.PlainText;
        }


        /// <summary>
        /// A string containing the type of output speech to render. Valid types are:
        ///    "PlainText": Indicates that the output speech is defined as plain text.
        ///    "SSML": Indicates that the output speech is text marked up with SSML.
        /// </summary>
        /// <remarks>
        /// Getter and setter must be public for the JSON parser
        /// </remarks>
        public AlexaOutputSpeechType SpeechType { get; internal set; } = AlexaOutputSpeechType.PlainText;

        private AlexaMultiLanguageText MultiLangText { get; set; } = new AlexaMultiLanguageText();

        public IList<string> Validate()
        {
            var errLst = new List<string>();
            if (MultiLangText == null) errLst.Add("AlexaOutputSpeech has no MultiLangText value");
            return errLst;
        }

        public string GetText(AlexaLocale locale = null)
        {
            locale ??= AlexaLocale.English_US;
            return MultiLangText.GetText(locale);
        }

        public void SetText(string txt, AlexaLocale locale = null)
        {
            MultiLangText.AddText(txt, locale);
        }

        public void SetText(AlexaMultiLanguageText txt)
        {
            MultiLangText = txt;
        }


        public string PlayBehavior { get; internal set; }


        public object CreateAlexaResponse(AlexaLocale locale)
        {
            try
            {
                var txt = MultiLangText.GetText(locale);
                if (string.IsNullOrEmpty(txt)) return null;

                dynamic obj = new ExpandoObject();
                obj.type = SpeechType.ToString();

                //Echo expects different fields depending on what the developer wants to send, either plain text or SSML
                if (SpeechType == AlexaOutputSpeechType.PlainText) obj.text = txt;
                else obj.ssml = txt;

                if (!string.IsNullOrEmpty(PlayBehavior)) obj.playBehavior = PlayBehavior;

                return obj;
            }
            catch (Exception e)
            {
                MsgLogger?.LogError(e, $"{GetType().Name} threw exception");
                return null;
            }

        }


    }
}