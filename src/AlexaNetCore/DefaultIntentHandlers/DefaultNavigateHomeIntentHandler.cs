using System.Threading.Tasks;
using AlexaNetCore.Interfaces;
using AlexaNetCore.Model;

namespace AlexaNetCore
{
    public class DefaultNavigateHomeIntentHandler : AlexaIntentHandlerBase
    {
     
        public AlexaMultiLanguageText DefaultText { get; set; }
        public AlexaMultiLanguageText RepromptText { get; set; }

        public override Task ProcessAsync()
        {
            Speak(DefaultText.GetText(RequestEnv.GetLocale()));
            if (RepromptText != null) Reprompt(RepromptText);
            EndSessionAfterResponse();
            return Task.CompletedTask;

        }

        public DefaultNavigateHomeIntentHandler(IAlexaMessageLogger log = null) : base(AlexaIntentType.Custom,AlexaBuiltInIntents.NavigateHomeIntent, log)
        {
            DefaultText = new AlexaMultiLanguageText("I'm sorry, I don't know how navigate home.");
        }

        public DefaultNavigateHomeIntentHandler(string txt, string reprompt= "", IAlexaMessageLogger log = null) : base(AlexaIntentType.Custom,AlexaBuiltInIntents.NavigateHomeIntent, log)
        {
            DefaultText = new AlexaMultiLanguageText(txt);
            if (!string.IsNullOrEmpty(reprompt)) RepromptText = new AlexaMultiLanguageText(reprompt) ;
        }

        public DefaultNavigateHomeIntentHandler(AlexaMultiLanguageText txt, AlexaMultiLanguageText reprompt =null, IAlexaMessageLogger log = null) : base(AlexaIntentType.Custom,AlexaBuiltInIntents.NavigateHomeIntent, log)
        {
            DefaultText = txt;
            RepromptText = reprompt;
        }

    }
}