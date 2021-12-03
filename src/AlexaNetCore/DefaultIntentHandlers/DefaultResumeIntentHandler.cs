using AlexaNetCore;

namespace AlexaNetCore
{
    public class DefaultResumeIntentHandler: AlexaIntentHandlerBase
    {
     
        public AlexaMultiLanguageText DefaultText { get; set; }

        public override void Process()
        {
            ResponseEnv.Response.OutputSpeech.SetText(DefaultText);

            ResponseEnv.Response.ShouldEndSession = true;
            ResponseEnv.IntentHandlerName = this.GetType().Name;

        }

        public DefaultResumeIntentHandler(IAlexaSkillMessageLogger log = null) : base(AlexaBuiltInIntents.ResumeIntent, log)
        {
            DefaultText = new AlexaMultiLanguageText("I'm sorry, I don't know how to do that.");
        }

        public DefaultResumeIntentHandler(string txt, IAlexaSkillMessageLogger log = null) : base(AlexaBuiltInIntents.ResumeIntent, log)
        {
            DefaultText = new AlexaMultiLanguageText(txt);
        }

        public DefaultResumeIntentHandler(AlexaMultiLanguageText txt, IAlexaSkillMessageLogger log = null) : base(AlexaBuiltInIntents.ResumeIntent, log)
        {
            DefaultText = txt;
        }

    }
}