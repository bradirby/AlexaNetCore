using System.Threading.Tasks;
using AlexaNetCore.Interfaces;
using AlexaNetCore.Model;
using Microsoft.Extensions.Logging;

namespace AlexaNetCore
{
    public class DefaultStopIntentHandler : AlexaIntentHandlerBase
    {
     
        public AlexaMultiLanguageText DefaultText { get; set; }

        public override Task ProcessAsync()
        {
            Speak(DefaultText.GetText(GetLocale()));
            EndSessionAfterResponse();
            return Task.CompletedTask;

        }

        public DefaultStopIntentHandler(ILogger log = null) : base(AlexaIntentType.Custom,AlexaBuiltInIntents.StopIntent, log)
        {
            DefaultText = new AlexaMultiLanguageText("Ok, stopping");
        }

        public DefaultStopIntentHandler(string txt, ILogger log = null) : base(AlexaIntentType.Custom,AlexaBuiltInIntents.StopIntent, log)
        {
            DefaultText = new AlexaMultiLanguageText(txt);
        }

        public DefaultStopIntentHandler(AlexaMultiLanguageText txt, ILogger log = null) : base(AlexaIntentType.Custom,AlexaBuiltInIntents.StopIntent, log)
        {
            DefaultText = txt;
        }

    }
}