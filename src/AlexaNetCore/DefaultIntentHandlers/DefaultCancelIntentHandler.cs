using AlexaNetCore;

namespace AlexaNetCore
{
    public class DefaultCancelIntentHandler : AlexaIntentHandlerBase
    {

        public override void Process()
        {
            ResponseEnv.SetOutputSpeech(CancelText);
            ResponseEnv.ShouldEndSession = true;
            ResponseEnv.IntentHandlerName = this.GetType().Name;
        }

        public AlexaMultiLanguageText CancelText { get; private set; } 

        public DefaultCancelIntentHandler(IAlexaNetCoreMessageLogger log = null) : base(AlexaBuiltInIntents.CancelIntent, log)
        {
            CancelText=new AlexaMultiLanguageText("Goodbye.");
        }

        public DefaultCancelIntentHandler(string txt, IAlexaNetCoreMessageLogger log = null) : base(AlexaBuiltInIntents.CancelIntent, log)
        {
            CancelText=new AlexaMultiLanguageText(txt);
        }
        public DefaultCancelIntentHandler(AlexaMultiLanguageText txt, IAlexaNetCoreMessageLogger log = null) : base(AlexaBuiltInIntents.CancelIntent, log)
        {
            CancelText=txt;
        }
    }
}