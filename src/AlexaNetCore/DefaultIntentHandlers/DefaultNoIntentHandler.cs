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
            ResponseEnv.IntentHandlerName = this.GetType().Name;

        }

        public DefaultNoIntentHandler(IAlexaNetCoreMessageLogger log = null) : base(AlexaBuiltInIntents.NoIntent, log)
        {
            DefaultText = new AlexaMultiLanguageText("I'm sorry, I don't know how to do that.");
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