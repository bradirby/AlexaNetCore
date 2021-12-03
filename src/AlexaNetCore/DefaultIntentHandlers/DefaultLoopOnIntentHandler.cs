using AlexaSkillDotNet;

namespace AlexaSkillDotNet
{
    public class DefaultLoopOnIntentHandler : AlexaIntentHandlerBase
    {
     
        public AlexaMultiLanguageText DefaultText { get; set; }

        public override void Process()
        {
            ResponseEnv.Response.OutputSpeech.SetText(DefaultText);

            ResponseEnv.Response.ShouldEndSession = true;
            ResponseEnv.IntentHandlerName = this.GetType().Name;

        }

        public DefaultLoopOnIntentHandler(IAlexaSkillMessageLogger log) : base(AlexaBuiltInIntents.LoopOnIntent, log)
        {
            DefaultText = new AlexaMultiLanguageText("I'm sorry, I don't know how to do that.");
        }

        public DefaultLoopOnIntentHandler(string txt, IAlexaSkillMessageLogger log) : base(AlexaBuiltInIntents.LoopOnIntent, log)
        {
            DefaultText = new AlexaMultiLanguageText(txt);
        }

        public DefaultLoopOnIntentHandler(AlexaMultiLanguageText txt, IAlexaSkillMessageLogger log) : base(AlexaBuiltInIntents.LoopOnIntent, log)
        {
            DefaultText = txt;
        }

    }
}