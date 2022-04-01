using AlexaNetCore;

namespace AlexaNetCore
{
    public class DefaultPauseIntentHandler: AlexaIntentHandlerBase
    {
        public AlexaMultiLanguageText DefaultText { get; set; }

        public override void Process()
        {
            ResponseEnv.SetOutputSpeechText(DefaultText);
            ResponseEnv.ShouldEndSession = true;
        }

        public DefaultPauseIntentHandler(IAlexaNetCoreMessageLogger log = null) : base(AlexaBuiltInIntents.PauseIntent, log)
        {
            DefaultText = new AlexaMultiLanguageText("I'm sorry, I don't know how to do that.");
        }

        public DefaultPauseIntentHandler(string txt, IAlexaNetCoreMessageLogger log = null) : base(AlexaBuiltInIntents.PauseIntent, log)
        {
            DefaultText = new AlexaMultiLanguageText(txt);
        }

        public DefaultPauseIntentHandler(AlexaMultiLanguageText txt, IAlexaNetCoreMessageLogger log = null) : base(AlexaBuiltInIntents.PauseIntent, log)
        {
            DefaultText = txt;
        }

    }
}