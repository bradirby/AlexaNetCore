using AlexaNetCore;

namespace AlexaNetCore
{
    public class DefaultShuffleOffIntentHandler: AlexaIntentHandlerBase
    {
     
        public AlexaMultiLanguageText DefaultText { get; set; }

        public override void Process()
        {
            ResponseEnv.SetOutputSpeechText(DefaultText);

            ResponseEnv.ShouldEndSession = true;
            ResponseEnv.IntentHandlerName = this.GetType().Name;

        }

        public DefaultShuffleOffIntentHandler(IAlexaNetCoreMessageLogger log = null) : base(AlexaBuiltInIntents.ShuffleOffIntent, log)
        {
            DefaultText = new AlexaMultiLanguageText("I'm sorry, I don't know how to do that.");
        }

        public DefaultShuffleOffIntentHandler(string txt, IAlexaNetCoreMessageLogger log = null) : base(AlexaBuiltInIntents.ShuffleOffIntent, log)
        {
            DefaultText = new AlexaMultiLanguageText(txt);
        }

        public DefaultShuffleOffIntentHandler(AlexaMultiLanguageText txt, IAlexaNetCoreMessageLogger log = null) : base(AlexaBuiltInIntents.ShuffleOffIntent, log)
        {
            DefaultText = txt;
        }

    }
}