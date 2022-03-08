using System;
using System.Diagnostics;
using System.Dynamic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AlexaNetCore
{
    /// <summary>
    /// The object containing the speech to render to the user.
    /// </summary>
    public class AlexaOutputSpeech
    {
        private IAlexaNetCoreMessageLogger MsgLogger;
        public AlexaOutputSpeech(AlexaLocale locale, IAlexaNetCoreMessageLogger log)
        {
            MsgLogger = log;
            SpeechType = AlexaOutputSpeechType.PlainText;
        }

        public AlexaOutputSpeech SetDefaultLocale(AlexaLocale locale)
        {
            MultiLangText.SetDefaultLocale(locale);
            return this;
        }

        public AlexaLocale DefaultLocale => MultiLangText.DefaultLocale;

        /// <summary>
        /// A string containing the type of output speech to render. Valid types are:
        ///    "PlainText": Indicates that the output speech is defined as plain text.
        ///    "SSML": Indicates that the output speech is text marked up with SSML.
        /// </summary>
        /// <remarks>
        /// Getter and setter must be public for the JSON parser
        /// </remarks>
        public AlexaOutputSpeechType SpeechType { get; internal set; } = AlexaOutputSpeechType.PlainText;

        private AlexaMultiLanguageText MultiLangText { get; set; } = new AlexaMultiLanguageText(AlexaLocale.English_US);


        public string GetText(AlexaLocale locale = null, IAlexaTranslationService translator = null)
        {
            return MultiLangText.GetText(locale, translator);
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


        public object GetJson(AlexaLocale locale, IAlexaTranslationService translator = null)
        {
            try
            {
                var txt = MultiLangText.GetText(locale, translator);
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
                MsgLogger?.Error(e,$"{this.GetType().Name} threw exception");
                return null;
            }

        }

      
    }
}