using AlexaNetCore;

namespace AlexaNetCore
{
    public class DefaultLoopOffIntentHandler: AlexaIntentHandlerBase
    {
     
        public AlexaMultiLanguageText DefaultText { get; set; }

        public override void Process()
        {
            ResponseEnv.Response.OutputSpeech.SetText(DefaultText);

            ResponseEnv.Response.ShouldEndSession = true;
            ResponseEnv.IntentHandlerName = this.GetType().Name;

        }

        public DefaultLoopOffIntentHandler(IAlexaSkillMessageLogger log) : base(AlexaBuiltInIntents.LoopOffIntent, log)
        {
            DefaultText = new AlexaMultiLanguageText("I'm sorry, I don't know how to do that.");
        }

        public DefaultLoopOffIntentHandler(string txt, IAlexaSkillMessageLogger log) : base(AlexaBuiltInIntents.LoopOffIntent, log)
        {
            DefaultText = new AlexaMultiLanguageText(txt);
        }

        public DefaultLoopOffIntentHandler(AlexaMultiLanguageText txt, IAlexaSkillMessageLogger log) : base(AlexaBuiltInIntents.LoopOffIntent, log)
        {
            DefaultText = txt;
        }

    }
}