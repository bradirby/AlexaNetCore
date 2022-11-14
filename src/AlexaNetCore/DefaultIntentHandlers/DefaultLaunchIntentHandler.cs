using System.Threading.Tasks;
using AlexaNetCore.Interfaces;
using AlexaNetCore.Model;
using Microsoft.Extensions.Logging;

namespace AlexaNetCore
{
    public class DefaultLaunchIntentHandler : AlexaIntentHandlerBase
    {
        public AlexaMultiLanguageText LaunchText { get; private set; }
        public AlexaMultiLanguageText RepromptText { get; private set; }
        private static string intentName = "LaunchIntent";
      

        public DefaultLaunchIntentHandler(ILogger log = null) : base(AlexaIntentType.Launch,intentName, log)
        {
            LaunchText = new AlexaMultiLanguageText("Hello, what can I do for you today?");
        }

        public DefaultLaunchIntentHandler(string defaultTxt, string repromptText = "", ILogger log = null) : base(AlexaIntentType.Launch,intentName, log)
        {
            LaunchText = new AlexaMultiLanguageText(defaultTxt);
            if (!string.IsNullOrEmpty(repromptText)) RepromptText = new AlexaMultiLanguageText(repromptText);
        }

        public DefaultLaunchIntentHandler(AlexaMultiLanguageText defaultTxt, AlexaMultiLanguageText repromptTxt = null,ILogger log = null) : base(AlexaIntentType.Launch,intentName, log)
        {
            LaunchText = defaultTxt;
            RepromptText = repromptTxt;
        }

    

        public override Task ProcessAsync()
        {
            Speak(LaunchText.GetText(GetLocale()));
            if (RepromptText != null) Reprompt(RepromptText.GetText(GetLocale()));
            if (DefaultCardLink != null) AddCard(DefaultCardTitleText, DefaultCardBodyText, DefaultCardLink);
            else if (DefaultCardBodyText != null) AddCard(DefaultCardTitleText, DefaultCardBodyText);
            KeepSessionActiveAfterResponse();
            return Task.CompletedTask;

        }
    }
}
