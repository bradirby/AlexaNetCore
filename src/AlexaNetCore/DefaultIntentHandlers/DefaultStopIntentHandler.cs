using AlexaSkillDotNet;

namespace AlexaSkillDotNet
{
    public class DefaultStopIntentHandler : AlexaIntentHandlerBase
    {
     
        public AlexaMultiLanguageText DefaultText { get; set; }

        public override void Process()
        {
            ResponseEnv.Response.OutputSpeech.SetText(DefaultText);

            ResponseEnv.Response.ShouldEndSession = true;
            ResponseEnv.IntentHandlerName = this.GetType().Name;

        }

        public DefaultStopIntentHandler(IAlexaSkillMessageLogger log) : base(AlexaBuiltInIntents.StopIntent, log)
        {
            DefaultText = new AlexaMultiLanguageText("Goodbye.");
        }

        public DefaultStopIntentHandler(string txt, IAlexaSkillMessageLogger log) : base(AlexaBuiltInIntents.StopIntent, log)
        {
            DefaultText = new AlexaMultiLanguageText(txt);
        }

        public DefaultStopIntentHandler(AlexaMultiLanguageText txt, IAlexaSkillMessageLogger log) : base(AlexaBuiltInIntents.StopIntent, log)
        {
            DefaultText = txt;
        }

    }
}