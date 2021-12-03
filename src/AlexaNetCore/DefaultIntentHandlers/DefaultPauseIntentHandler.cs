using AlexaSkillDotNet;

namespace AlexaSkillDotNet
{
    public class DefaultPauseIntentHandler: AlexaIntentHandlerBase
    {
        public AlexaMultiLanguageText DefaultText { get; set; }

        public override void Process()
        {
            ResponseEnv.Response.OutputSpeech.SetText(DefaultText);

            ResponseEnv.Response.ShouldEndSession = true;
            ResponseEnv.IntentHandlerName = this.GetType().Name;

        }

        public DefaultPauseIntentHandler(IAlexaSkillMessageLogger log) : base(AlexaBuiltInIntents.PauseIntent, log)
        {
            DefaultText = new AlexaMultiLanguageText("I'm sorry, I don't know how to do that.");
        }

        public DefaultPauseIntentHandler(string txt, IAlexaSkillMessageLogger log) : base(AlexaBuiltInIntents.PauseIntent, log)
        {
            DefaultText = new AlexaMultiLanguageText(txt);
        }

        public DefaultPauseIntentHandler(AlexaMultiLanguageText txt, IAlexaSkillMessageLogger log) : base(AlexaBuiltInIntents.PauseIntent, log)
        {
            DefaultText = txt;
        }

    }
}