using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using AlexaNetCore.Interfaces;
using Microsoft.Extensions.Logging;

namespace AlexaNetCore.Model
{
    internal class AlexaResponse
    {
        private ILogger MsgLogger;

        internal AlexaResponse(AlexaLocale locale, ILogger log)
        {
            MsgLogger = log;
            OutputSpeech = new AlexaOutputSpeech(locale, MsgLogger);
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

        public IList<string> Validate()
        {
            var errLst = new List<string>();
            if (Card != null) errLst.AddRange(Card.Validate());
            if (Reprompt != null) errLst.AddRange(Reprompt.Validate());
            if (OutputSpeech == null) errLst.Add("AlexaResponse.OutputSpeech is null");
            else errLst.AddRange(OutputSpeech.Validate());
            return errLst;
        }

        public AlexaCard AddCard(string title, string txt, AlexaImageLink urlLink = null)
        {
            Card = new AlexaCard(title, txt,urlLink, MsgLogger);
            return Card;
        }

        public AlexaCard AddCard(AlexaMultiLanguageText title, AlexaMultiLanguageText txt, AlexaImageLink urlLink = null)
        {
            Card = new AlexaCard(title, txt,urlLink, MsgLogger);
            return Card;
        }

        public AlexaCard AddCard(AlexaCard card)
        {
            Card = card;
            return Card;
        }

        private IList<IAlexaDirective> Directives { get; set; } = new List<IAlexaDirective>();

        /// <summary>
        /// The object containing the outputSpeech to use if a re-prompt is necessary.
        /// This is used if the your service keeps the session open after sending the response, 
        /// but the user does not respond with anything that maps to an intent defined in your voice interface while the audio stream is open.
        /// To reprompt the user you must set this text and the ShouldEndSession = false
        /// </summary>
        public AlexaReprompt Reprompt { get; private set; }


        internal void SetRepromptSpeechText(string repromptTxt, AlexaOutputSpeechType typ)
        {
            if (string.IsNullOrEmpty(repromptTxt)) SetRepromptSpeechText((AlexaMultiLanguageText)null, typ);
            else SetRepromptSpeechText(new AlexaMultiLanguageText(repromptTxt), typ);
        }

        public void SetRepromptSpeechText(AlexaMultiLanguageText repromptTxt, AlexaOutputSpeechType typ)
        {
            if (repromptTxt == null)
            {
                Reprompt = null;
                return;
            }
            OutputSpeech.SpeechType = typ;
            Reprompt = new AlexaReprompt(repromptTxt, MsgLogger);
            ShouldEndSession = false;
        }

        /// <summary>
        /// Indicates whether the session should be ended immediately after the response is sent, with no reprompt text sent.
        /// To reprompt the user you must set this value to True and set the reprompt text
        /// </summary>
        public bool? ShouldEndSession { get; set; }

        /// <summary>
        /// Returns true if there is a reprompt set
        /// </summary>
        public bool IsRepromptSet => Reprompt != null;

        public object CreateAlexaResponse(AlexaLocale locale)
        {
            dynamic obj = new ExpandoObject();
            obj.outputSpeech = OutputSpeech.CreateAlexaResponse(locale);

            if (Card != null)
            {
                var cardObj = Card.CreateAlexaResponse(locale);
                if (cardObj != null) obj.card = cardObj;
            }

            if (Reprompt != null && ShouldEndSession.HasValue && !ShouldEndSession.Value)
            {
                var repromptObj = Reprompt.CreateAlexaResponse(locale);
                if (repromptObj != null) obj.reprompt = repromptObj;
            }

            if (Directives != null && Directives.Any())
            {
                var dirLst = Directives.Select(directive => directive.CreateAlexaResponse(locale)).ToList();
                obj.directives = dirLst.ToArray();
            }

            if (ShouldEndSession.HasValue)
            {
                obj.shouldEndSession = ShouldEndSession.Value;
            }

            return obj;

        }

        public void SetOutputSpeechText(AlexaMultiLanguageText txt, AlexaOutputSpeechType typ = AlexaOutputSpeechType.PlainText)
        {
            OutputSpeech.SetText(txt);
            OutputSpeech.SpeechType = typ;
        }

        public void SetOutputSpeechText(string txt, AlexaOutputSpeechType typ = AlexaOutputSpeechType.PlainText)
        {
            OutputSpeech.SetText(txt);
            OutputSpeech.SpeechType = typ;
        }


        public string GetOutputSpeachText(AlexaLocale locale)
        {
            return OutputSpeech.GetText(locale);
        }


        public void AddDirective(IAlexaDirective dir)
        {
            if (dir == null) return;
            Directives ??= new List<IAlexaDirective>();
            if (Directives.Any(d => d.DirectiveType == dir.DirectiveType)) return;
            Directives.Add(dir);
        }

        public void RemoveDirective(IAlexaDirective dir)
        {
            var dirToRemove = Directives?.FirstOrDefault(d => d.DirectiveType == dir.DirectiveType);
            if (dirToRemove != null) Directives.Remove(dir);
        }

    }
}