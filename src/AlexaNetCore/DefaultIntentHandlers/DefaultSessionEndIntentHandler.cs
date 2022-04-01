using AlexaNetCore;

namespace AlexaNetCore
{
    public class DefaultSessionEndRequest : AlexaIntentHandlerBase
    {
        public override void Process()
        {
            ResponseEnv.SetOutputSpeechText(CancelText);
            ResponseEnv.ShouldEndSession = true;
            ResponseEnv.IntentHandlerName = this.GetType().Name;
        }

        public AlexaMultiLanguageText CancelText { get; private set; } 

        public DefaultSessionEndRequest(IAlexaNetCoreMessageLogger log = null) : base(AlexaBuiltInIntents.SessionEndedRequest, log)
        {
            IncludeInInteractionModel = false;
            CancelText=new AlexaMultiLanguageText("Goodbye.");
        }

        public DefaultSessionEndRequest(string txt, IAlexaNetCoreMessageLogger log = null) : base(AlexaBuiltInIntents.SessionEndedRequest, log)
        {
            IncludeInInteractionModel = false;
            CancelText=new AlexaMultiLanguageText(txt);
        }
        public DefaultSessionEndRequest(AlexaMultiLanguageText txt, IAlexaNetCoreMessageLogger log = null) : base(AlexaBuiltInIntents.SessionEndedRequest, log)
        {
            IncludeInInteractionModel = false;
            CancelText=txt;
        }
    }
}