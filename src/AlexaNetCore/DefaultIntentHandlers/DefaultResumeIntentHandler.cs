using AlexaNetCore;

namespace AlexaNetCore
{
    public class DefaultResumeIntentHandler: AlexaIntentHandlerBase
    {
     
        public AlexaMultiLanguageText DefaultText { get; set; }

        public override void Process()
        {
            ResponseEnv.SetOutputSpeechText(DefaultText);

            ResponseEnv.ShouldEndSession = true;
            ResponseEnv.IntentHandlerName = this.GetType().Name;

        }

        public DefaultResumeIntentHandler(IAlexaNetCoreMessageLogger log = null) : base(AlexaBuiltInIntents.ResumeIntent, log)
        {
            DefaultText = new AlexaMultiLanguageText("I'm sorry, I don't know how to do that.");
        }

        public DefaultResumeIntentHandler(string txt, IAlexaNetCoreMessageLogger log = null) : base(AlexaBuiltInIntents.ResumeIntent, log)
        {
            DefaultText = new AlexaMultiLanguageText(txt);
        }

        public DefaultResumeIntentHandler(AlexaMultiLanguageText txt, IAlexaNetCoreMessageLogger log = null) : base(AlexaBuiltInIntents.ResumeIntent, log)
        {
            DefaultText = txt;
        }

    }
}