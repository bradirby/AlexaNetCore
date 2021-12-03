using AlexaSkillDotNet;

namespace AlexaSkillDotNet
{
    public class DefaultCancelIntentHandler : AlexaIntentHandlerBase
    {

        public override void Process()
        {
            ResponseEnv.Response.OutputSpeech.SetText(CancelText);
            ResponseEnv.Response.ShouldEndSession = true;
            ResponseEnv.IntentHandlerName = this.GetType().Name;
        }

        public AlexaMultiLanguageText CancelText { get; private set; } 

        public DefaultCancelIntentHandler(IAlexaSkillMessageLogger log) : base(AlexaBuiltInIntents.CancelIntent, log)
        {
            CancelText=new AlexaMultiLanguageText("Goodbye.");
        }

        public DefaultCancelIntentHandler(string txt, IAlexaSkillMessageLogger log) : base(AlexaBuiltInIntents.CancelIntent, log)
        {
            CancelText=new AlexaMultiLanguageText(txt);
        }
        public DefaultCancelIntentHandler(AlexaMultiLanguageText txt, IAlexaSkillMessageLogger log) : base(AlexaBuiltInIntents.CancelIntent, log)
        {
            CancelText=txt;
        }
    }
}