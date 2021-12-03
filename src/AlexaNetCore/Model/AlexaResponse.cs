using System.Dynamic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AlexaNetCore
{
    public class AlexaResponse
    {
        private IAlexaNetCoreMessageLogger MsgLogger;

        public AlexaResponse(AlexaLocale locale, IAlexaNetCoreMessageLogger log)
        {
            MsgLogger = log;
            OutputSpeech  = new AlexaOutputSpeech(locale, MsgLogger);
        }


        /// <summary>
        /// The object containing the speech to render to the user.
        /// </summary>
        public AlexaOutputSpeech OutputSpeech { get; private set; }

        /// <summary>
        /// The object containing a card to render to the Amazon Alexa App.  This is empty by default.
        /// </summary>
        public AlexaCard Card { get; private set; }

        public void SetCard(AlexaCard c)
        {
            Card = c;
        }

        public AlexaCard AddSimpleCard(string title, string txt)
        {
            Card = new AlexaCard(AlexaCardType.Simple, MsgLogger);
            Card.SetTitleText(title);
            Card.SetContentText(txt);
            Card.SetText(txt);
            return Card;
        }

        public AlexaCard AddSimpleCard(AlexaMultiLanguageText title, AlexaMultiLanguageText txt)
        {
            Card = new AlexaCard(AlexaCardType.Simple, MsgLogger);
            Card.SetTitleText(title);
            Card.SetContentText(txt);
            Card.SetText(txt);
            return Card;
        }

        public AlexaCard AddStandardCard(string title, string txt, AlexaImageLink urlLink)
        {
            Card = new AlexaCard(AlexaCardType.Standard, MsgLogger);
            Card.SetTitleText(title);
            Card.SetContentText(txt);
            Card.SetText(txt);
            Card.SetImageLink(urlLink);
            return Card;
        }
        
        public AlexaCard AddStandardCard(AlexaMultiLanguageText title, AlexaMultiLanguageText txt, AlexaImageLink urlLink)
        {
            Card = new AlexaCard(AlexaCardType.Standard, MsgLogger);
            Card.SetTitleText(title);
            Card.SetContentText(txt);
            Card.SetText(txt);
            Card.SetImageLink(urlLink);
            return Card;
        }

        /// <summary>
        /// The object containing the outputSpeech to use if a re-prompt is necessary.
        /// This is used if the your service keeps the session open after sending the response, 
        /// but the user does not respond with anything that maps to an intent defined in your voice interface while the audio stream is open.
        /// To reprompt the user you must set this text and the ShouldEndSession = false
        /// </summary>
        public AlexaReprompt Reprompt { get; private set; }

    
        public void SetRepromptSpeech(string repromptTxt)
        {
            if (string.IsNullOrEmpty(repromptTxt)) SetRepromptSpeech((AlexaMultiLanguageText) null);
            else SetRepromptSpeech(new AlexaMultiLanguageText(repromptTxt));        
        }

        public void SetRepromptSpeech(AlexaMultiLanguageText repromptTxt)
        {
            if (repromptTxt == null)
            {
                Reprompt = null;
                return;
            }
            Reprompt = new AlexaReprompt(repromptTxt, MsgLogger);
            ShouldEndSession = false;
        }

        /// <summary>
        /// Indicates whether the session should be ended immediately after the response is sent, with no reprompt text sent.
        /// To reprompt the user you must set this value to True and the reprompt text
        /// </summary>
        public bool? ShouldEndSession { get; set; }

        public bool IsRepromptSet => (Reprompt != null);

        public object GetJson(AlexaLocale locale, IAlexaTranslationService translator = null)
        {

            dynamic obj = new ExpandoObject();
            obj.outputSpeech = OutputSpeech.GetJson(locale, translator);

            if (Card != null)
            {
                var cardObj = Card.GetJson(locale, translator);
                if (cardObj != null) obj.card = cardObj;
            }

            if (Reprompt != null && ShouldEndSession.HasValue && !ShouldEndSession.Value)
            {
                var repromptObj = Reprompt.GetJson(locale, translator);
                if (repromptObj != null) obj.reprompt = repromptObj;
            }

            if (ShouldEndSession.HasValue)
            {
                obj.shouldEndSession = ShouldEndSession.Value;
            }

            return obj;

        }

        public void SetOutputSpeech(AlexaMultiLanguageText txt)
        {
            OutputSpeech.SetText(txt);
        }

        public void SetOutputSpeech(string txt)
        {
            OutputSpeech.SetText(txt);
        }

        public string GetOutputSpeach(AlexaLocale locale, IAlexaTranslationService translator)
        {
            return OutputSpeech.GetText(locale, translator);
        }

        public void SetDefaultResponseLocale(AlexaLocale locale)
        {
            OutputSpeech.SetDefaultLocale(locale);
            Reprompt.SetDefaultLocale(locale);
        }
    }
}