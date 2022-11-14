using System.Threading.Tasks;
using AlexaNetCore.Interfaces;
using AlexaNetCore.Model;
using Microsoft.Extensions.Logging;

namespace AlexaNetCore
{
    public class DefaultHelpIntentHandler : AlexaIntentHandlerBase
    {

        public override Task ProcessAsync()
        {
            Speak(HelpTxt.GetText(GetLocale()));
            if (RepromptTxt != null) Reprompt(RepromptTxt.GetText(GetLocale()));
            KeepSessionActiveAfterResponse();
            return Task.CompletedTask;
        }

        public AlexaMultiLanguageText HelpTxt { get; private set; }
        public AlexaMultiLanguageText RepromptTxt{ get; private set; }

        public DefaultHelpIntentHandler(ILogger log = null) : base(AlexaIntentType.Custom, AlexaBuiltInIntents.HelpIntent, log)
        {
            HelpTxt = new AlexaMultiLanguageText("I'm sorry you're having trouble.  Please ask again and I'll try harder.");
        }

        public DefaultHelpIntentHandler(string defaultTxt, string reprompText = "", ILogger log = null) : base(AlexaIntentType.Custom, AlexaBuiltInIntents.HelpIntent, log)
        {
            HelpTxt = new AlexaMultiLanguageText(defaultTxt);
            if (!string.IsNullOrEmpty(reprompText)) RepromptTxt = new AlexaMultiLanguageText(reprompText);
        }

        public DefaultHelpIntentHandler(AlexaMultiLanguageText defaultTxt, AlexaMultiLanguageText repromptTxt = null, ILogger log = null) : base(AlexaIntentType.Custom, AlexaBuiltInIntents.HelpIntent, log)
        {
            HelpTxt =  defaultTxt;
            RepromptTxt = repromptTxt;
        }

    
    }
}