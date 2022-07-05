using System.Threading.Tasks;
using AlexaNetCore.Model;
using AlexaNetCore.Interfaces;

namespace AlexaNetCore
{
    public class DefaultCancelIntentHandler : AlexaIntentHandlerBase
    {

        public override Task ProcessAsync()
        {
            Speak(CancelText.GetText(RequestEnv.GetLocale()));
            EndSessionAfterResponse();
            return Task.CompletedTask;
        }

        public AlexaMultiLanguageText CancelText { get; private set; } 

        public DefaultCancelIntentHandler(IAlexaMessageLogger log = null) : base(AlexaIntentType.Custom, AlexaBuiltInIntents.CancelIntent, log)
        {
            CancelText=new AlexaMultiLanguageText("Ok, cancelling", AlexaLocale.English_US);
        }

        public DefaultCancelIntentHandler(string txt, IAlexaMessageLogger log = null) : base(AlexaIntentType.Custom, AlexaBuiltInIntents.CancelIntent, log)
        {
            CancelText=new AlexaMultiLanguageText(txt, AlexaLocale.English_US);
        }
        public DefaultCancelIntentHandler(AlexaMultiLanguageText txt, IAlexaMessageLogger log = null) : base(AlexaIntentType.Custom, AlexaBuiltInIntents.CancelIntent, log)
        {
            CancelText=txt;
        }
    }
}