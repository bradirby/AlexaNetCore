using AlexaNetCore;

namespace AlexaNetCore
{
    public class DefaultLoopOnIntentHandler : AlexaIntentHandlerBase
    {
     
        public AlexaMultiLanguageText DefaultText { get; set; }

        public override void Process()
        {
            ResponseEnv.SetOutputSpeechText(DefaultText);
            ResponseEnv.ShouldEndSession = true;
        }

        public DefaultLoopOnIntentHandler(IAlexaNetCoreMessageLogger log = null) : base(AlexaBuiltInIntents.LoopOnIntent, log)
        {
            DefaultText = new AlexaMultiLanguageText("I'm sorry, I don't know how to do that.");
        }

        public DefaultLoopOnIntentHandler(string txt, IAlexaNetCoreMessageLogger log = null) : base(AlexaBuiltInIntents.LoopOnIntent, log)
        {
            DefaultText = new AlexaMultiLanguageText(txt);
        }

        public DefaultLoopOnIntentHandler(AlexaMultiLanguageText txt, IAlexaNetCoreMessageLogger log = null) : base(AlexaBuiltInIntents.LoopOnIntent, log)
        {
            DefaultText = txt;
        }

    }
}