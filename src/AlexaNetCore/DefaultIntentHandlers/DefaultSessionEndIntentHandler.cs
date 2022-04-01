using AlexaNetCore;

namespace AlexaNetCore
{
    public class DefaultSessionEndRequest : AlexaIntentHandlerBase
    {
        public override void Process()
        {
            ResponseEnv.SetOutputSpeechText(CancelText);
            ResponseEnv.ShouldEndSession = true;
        }

        public AlexaMultiLanguageText CancelText { get; private set; } 

        public DefaultSessionEndRequest(IAlexaNetCoreMessageLogger log = null) : base(AlexaRequestType.SessionEndedRequest, log)
        {
            Init(new AlexaMultiLanguageText("Goodbye."));
        }

        public DefaultSessionEndRequest(string txt, IAlexaNetCoreMessageLogger log = null) : base(AlexaRequestType.SessionEndedRequest, log)
        {
            Init(new AlexaMultiLanguageText(txt));
        }
        public DefaultSessionEndRequest(AlexaMultiLanguageText txt, IAlexaNetCoreMessageLogger log = null) : base(AlexaRequestType.SessionEndedRequest, log)
        {
            Init(txt);
        }

        private void Init(AlexaMultiLanguageText txt)
        {
            IntentType = AlexaRequestType.SessionEndedRequest;
            IncludeInInteractionModel = false;
            CancelText=txt;
        }
    }
}