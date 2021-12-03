using AlexaNetCore;

namespace AlexaNetCore
{
    public class DefaultShuffleOffIntentHandler: AlexaIntentHandlerBase
    {
     
        public AlexaMultiLanguageText DefaultText { get; set; }

        public override void Process()
        {
            ResponseEnv.Response.OutputSpeech.SetText(DefaultText);

            ResponseEnv.Response.ShouldEndSession = true;
            ResponseEnv.IntentHandlerName = this.GetType().Name;

        }

        public DefaultShuffleOffIntentHandler(IAlexaSkillMessageLogger log) : base(AlexaBuiltInIntents.ShuffleOffIntent, log)
        {
            DefaultText = new AlexaMultiLanguageText("I'm sorry, I don't know how to do that.");
        }

        public DefaultShuffleOffIntentHandler(string txt, IAlexaSkillMessageLogger log) : base(AlexaBuiltInIntents.ShuffleOffIntent, log)
        {
            DefaultText = new AlexaMultiLanguageText(txt);
        }

        public DefaultShuffleOffIntentHandler(AlexaMultiLanguageText txt, IAlexaSkillMessageLogger log) : base(AlexaBuiltInIntents.ShuffleOffIntent, log)
        {
            DefaultText = txt;
        }

    }
}