using AlexaSkillDotNet;

namespace AlexaSkillDotNet
{
    public class DefaultNextIntentHandler : AlexaIntentHandlerBase
    {
     
        public AlexaMultiLanguageText DefaultText { get; set; }

        public override void Process()
        {
            ResponseEnv.Response.OutputSpeech.SetText(DefaultText);

            ResponseEnv.Response.ShouldEndSession = true;
            ResponseEnv.IntentHandlerName = this.GetType().Name;

        }

        public DefaultNextIntentHandler(IAlexaSkillMessageLogger log) : base(AlexaBuiltInIntents.NextIntent, log)
        {
            DefaultText = new AlexaMultiLanguageText("I'm sorry, I don't know how to do that.");
        }

        public DefaultNextIntentHandler(string txt, IAlexaSkillMessageLogger log) : base(AlexaBuiltInIntents.NextIntent, log)
        {
            DefaultText = new AlexaMultiLanguageText(txt);
        }

        public DefaultNextIntentHandler(AlexaMultiLanguageText txt, IAlexaSkillMessageLogger log) : base(AlexaBuiltInIntents.NextIntent, log)
        {
            DefaultText = txt;
        }

    }
}