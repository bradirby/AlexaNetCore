using AlexaSkillDotNet;

namespace AlexaSkillDotNet
{
    public class DefaultShuffleOnIntentHandler: AlexaIntentHandlerBase
    {
     
        public AlexaMultiLanguageText DefaultText { get; set; }

        public override void Process()
        {
            ResponseEnv.Response.OutputSpeech.SetText(DefaultText);

            ResponseEnv.Response.ShouldEndSession = true;
            ResponseEnv.IntentHandlerName = this.GetType().Name;

        }

        public DefaultShuffleOnIntentHandler(IAlexaSkillMessageLogger log) : base(AlexaBuiltInIntents.ShuffleOnIntent, log)
        {
            DefaultText = new AlexaMultiLanguageText("I'm sorry, I don't know how to do that.");
        }

        public DefaultShuffleOnIntentHandler(string txt, IAlexaSkillMessageLogger log) : base(AlexaBuiltInIntents.ShuffleOnIntent, log)
        {
            DefaultText = new AlexaMultiLanguageText(txt);
        }

        public DefaultShuffleOnIntentHandler(AlexaMultiLanguageText txt, IAlexaSkillMessageLogger log) : base(AlexaBuiltInIntents.ShuffleOnIntent, log)
        {
            DefaultText = txt;
        }

    }
}