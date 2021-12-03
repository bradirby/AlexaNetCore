using AlexaNetCore;

namespace AlexaNetCore
{
    public class DefaultNoIntentHandler: AlexaIntentHandlerBase
    {
        public AlexaMultiLanguageText DefaultText { get; set; }

        public override void Process()
        {
            ResponseEnv.Response.OutputSpeech.SetText(DefaultText);

            ResponseEnv.Response.ShouldEndSession = true;
            ResponseEnv.IntentHandlerName = this.GetType().Name;

        }

        public DefaultNoIntentHandler(IAlexaSkillMessageLogger log) : base(AlexaBuiltInIntents.NoIntent, log)
        {
            DefaultText = new AlexaMultiLanguageText("I'm sorry, I don't know how to do that.");
        }

        public DefaultNoIntentHandler(string txt, IAlexaSkillMessageLogger log) : base(AlexaBuiltInIntents.NoIntent, log)
        {
            DefaultText = new AlexaMultiLanguageText(txt);
        }

        public DefaultNoIntentHandler(AlexaMultiLanguageText txt, IAlexaSkillMessageLogger log) : base(AlexaBuiltInIntents.NoIntent, log)
        {
            DefaultText = txt;
        }

    }
}