using AlexaSkillDotNet;

namespace AlexaSkillDotNet
{
    public class DefaultRepeatIntentHandler: AlexaIntentHandlerBase
    {
     
        public AlexaMultiLanguageText DefaultText { get; set; }

        public override void Process()
        {
            ResponseEnv.Response.OutputSpeech.SetText(DefaultText);

            ResponseEnv.Response.ShouldEndSession = true;
            ResponseEnv.IntentHandlerName = this.GetType().Name;

        }

        public DefaultRepeatIntentHandler(IAlexaSkillMessageLogger log) : base(AlexaBuiltInIntents.RepeatIntent, log)
        {
            DefaultText = new AlexaMultiLanguageText("I'm sorry, I don't know how to do that.");
        }

        public DefaultRepeatIntentHandler(string txt, IAlexaSkillMessageLogger log) : base(AlexaBuiltInIntents.RepeatIntent, log)
        {
            DefaultText = new AlexaMultiLanguageText(txt);
        }

        public DefaultRepeatIntentHandler(AlexaMultiLanguageText txt, IAlexaSkillMessageLogger log) : base(AlexaBuiltInIntents.RepeatIntent, log)
        {
            DefaultText = txt;
        }

    }
}