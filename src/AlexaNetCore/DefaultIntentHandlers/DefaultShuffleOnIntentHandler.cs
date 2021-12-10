using AlexaNetCore;

namespace AlexaNetCore
{
    public class DefaultShuffleOnIntentHandler: AlexaIntentHandlerBase
    {
     
        public AlexaMultiLanguageText DefaultText { get; set; }

        public override void Process()
        {
            ResponseEnv.SetOutputSpeechText(DefaultText);

            ResponseEnv.ShouldEndSession = true;
            ResponseEnv.IntentHandlerName = this.GetType().Name;

        }

        public DefaultShuffleOnIntentHandler(IAlexaNetCoreMessageLogger log = null) : base(AlexaBuiltInIntents.ShuffleOnIntent, log)
        {
            DefaultText = new AlexaMultiLanguageText("I'm sorry, I don't know how to do that.");
        }

        public DefaultShuffleOnIntentHandler(string txt, IAlexaNetCoreMessageLogger log = null) : base(AlexaBuiltInIntents.ShuffleOnIntent, log)
        {
            DefaultText = new AlexaMultiLanguageText(txt);
        }

        public DefaultShuffleOnIntentHandler(AlexaMultiLanguageText txt, IAlexaNetCoreMessageLogger log = null) : base(AlexaBuiltInIntents.ShuffleOnIntent, log)
        {
            DefaultText = txt;
        }

    }
}