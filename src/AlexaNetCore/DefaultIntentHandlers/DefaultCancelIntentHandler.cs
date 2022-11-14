using System.Threading.Tasks;
using AlexaNetCore.Model;
using AlexaNetCore.Interfaces;
using Microsoft.Extensions.Logging;


namespace AlexaNetCore
{
    public class DefaultCancelIntentHandler : AlexaIntentHandlerBase
    {

        public override Task ProcessAsync()
        {
            Speak(CancelText.GetText(GetLocale()));
            EndSessionAfterResponse();
            return Task.CompletedTask;
        }

        public AlexaMultiLanguageText CancelText { get; private set; } 

        public DefaultCancelIntentHandler(ILogger log = null) : base(AlexaIntentType.Custom, AlexaBuiltInIntents.CancelIntent, log)
        {
            CancelText=new AlexaMultiLanguageText("Ok, cancelling", AlexaLocale.English_US);
        }

        public DefaultCancelIntentHandler(string txt, ILogger log = null) : base(AlexaIntentType.Custom, AlexaBuiltInIntents.CancelIntent, log)
        {
            CancelText=new AlexaMultiLanguageText(txt, AlexaLocale.English_US);
        }
        public DefaultCancelIntentHandler(AlexaMultiLanguageText txt, ILogger log = null) : base(AlexaIntentType.Custom, AlexaBuiltInIntents.CancelIntent, log)
        {
            CancelText=txt;
        }
    }
}