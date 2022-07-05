using System.Threading.Tasks;
using AlexaNetCore.Interfaces;
using AlexaNetCore.Model;

namespace AlexaNetCore
{
    public class DefaultStartOverIntentHandler: AlexaIntentHandlerBase
    {
        public override Task ProcessAsync()
        {
            Speak(CustomStartOverText.GetText(RequestEnv.GetLocale()));
            if (RepromptText != null) Reprompt(RepromptText.GetText(RequestEnv.GetLocale()));
            KeepSessionActiveAfterResponse();
            return Task.CompletedTask;

        }

        public AlexaMultiLanguageText CustomStartOverText { get; set; }
        public AlexaMultiLanguageText RepromptText { get; set; }

        public DefaultStartOverIntentHandler(IAlexaMessageLogger log = null) : base(AlexaIntentType.Custom, AlexaBuiltInIntents.StartOverIntent, log)
        {
            CustomStartOverText = new AlexaMultiLanguageText("I'm sorry, I don't know how to do that.");
        }

        public DefaultStartOverIntentHandler(string txt, string repromptTxt = "", IAlexaMessageLogger log = null) : base(AlexaIntentType.Custom, AlexaBuiltInIntents.StartOverIntent, log)
        {
            CustomStartOverText = new AlexaMultiLanguageText(txt);
            if (!string.IsNullOrEmpty(repromptTxt)) RepromptText = new AlexaMultiLanguageText(repromptTxt); 
        }

        public DefaultStartOverIntentHandler(AlexaMultiLanguageText txt,AlexaMultiLanguageText repromptTxt = null, IAlexaMessageLogger log = null) : base(AlexaIntentType.Custom, AlexaBuiltInIntents.StartOverIntent, log)
        {
            CustomStartOverText =  txt;
            RepromptText = repromptTxt; 
        }

    }
}