using AlexaNetCore;

namespace AlexaNetCore
{
    public class DefaultNoIntentHandler: AlexaIntentHandlerBase
    {
        public AlexaMultiLanguageText DefaultText { get; set; }

        public override void Process()
        {
            ResponseEnv.SetOutputSpeechText(DefaultText);
            ResponseEnv.ShouldEndSession = true;
        }

        public DefaultNoIntentHandler(IAlexaNetCoreMessageLogger log = null) : base(AlexaBuiltInIntents.NoIntent, log)
        {
            DefaultText = new AlexaMultiLanguageText("I'm not sure what you are saying No to.");
        }

        public DefaultNoIntentHandler(string txt, IAlexaNetCoreMessageLogger log = null) : base(AlexaBuiltInIntents.NoIntent, log)
        {
            DefaultText = new AlexaMultiLanguageText(txt);
        }

        public DefaultNoIntentHandler(AlexaMultiLanguageText txt, IAlexaNetCoreMessageLogger log = null) : base(AlexaBuiltInIntents.NoIntent, log)
        {
            DefaultText = txt;
        }

    }
}