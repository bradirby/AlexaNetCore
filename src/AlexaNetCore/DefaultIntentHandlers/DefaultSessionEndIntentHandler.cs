using AlexaNetCore;

namespace AlexaNetCore
{
    public class DefaultSessionEndRequest : AlexaIntentHandlerBase
    {
        public override void Process()
        {
            ResponseEnv.Response.OutputSpeech.SetText(CancelText);
            ResponseEnv.Response.ShouldEndSession = true;
            ResponseEnv.IntentHandlerName = this.GetType().Name;
        }

        public AlexaMultiLanguageText CancelText { get; private set; } 

        public DefaultSessionEndRequest(IAlexaSkillMessageLogger log = null) : base(AlexaBuiltInIntents.SessionEndedRequest, log)
        {
            CancelText=new AlexaMultiLanguageText("Goodbye.");
        }

        public DefaultSessionEndRequest(string txt, IAlexaSkillMessageLogger log = null) : base(AlexaBuiltInIntents.SessionEndedRequest, log)
        {
            CancelText=new AlexaMultiLanguageText(txt);
        }
        public DefaultSessionEndRequest(AlexaMultiLanguageText txt, IAlexaSkillMessageLogger log = null) : base(AlexaBuiltInIntents.SessionEndedRequest, log)
        {
            CancelText=txt;
        }
    }
}