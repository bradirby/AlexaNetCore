using System.Threading.Tasks;
using AlexaNetCore.Interfaces;
using AlexaNetCore.Model;

namespace AlexaNetCore
{
    public class DefaultStopIntentHandler : AlexaIntentHandlerBase
    {
     
        public AlexaMultiLanguageText DefaultText { get; set; }

        public override Task ProcessAsync()
        {
            Speak(DefaultText.GetText(RequestEnv.GetLocale()));
            EndSessionAfterResponse();
            return Task.CompletedTask;

        }

        public DefaultStopIntentHandler(IAlexaMessageLogger log = null) : base(AlexaIntentType.Custom,AlexaBuiltInIntents.StopIntent, log)
        {
            DefaultText = new AlexaMultiLanguageText("Ok, stopping");
        }

        public DefaultStopIntentHandler(string txt, IAlexaMessageLogger log = null) : base(AlexaIntentType.Custom,AlexaBuiltInIntents.StopIntent, log)
        {
            DefaultText = new AlexaMultiLanguageText(txt);
        }

        public DefaultStopIntentHandler(AlexaMultiLanguageText txt, IAlexaMessageLogger log = null) : base(AlexaIntentType.Custom,AlexaBuiltInIntents.StopIntent, log)
        {
            DefaultText = txt;
        }

    }
}