using AlexaNetCore;

namespace AlexaNetCore
{
    public class DefaultYesIntentHandler: AlexaIntentHandlerBase
    {
     
        public AlexaMultiLanguageText DefaultText { get; set; }

        public override void Process()
        {
            ResponseEnv.SetOutputSpeechText(DefaultText);
            ResponseEnv.ShouldEndSession = true;
        }

        public DefaultYesIntentHandler(IAlexaNetCoreMessageLogger log = null) : base(AlexaBuiltInIntents.YesIntent, log)
        {
            DefaultText = new AlexaMultiLanguageText("I'm not sure what you are saying Yes to.");
        }

        public DefaultYesIntentHandler(string txt, IAlexaNetCoreMessageLogger log = null) : base(AlexaBuiltInIntents.YesIntent, log)
        {
            DefaultText = new AlexaMultiLanguageText(txt);
        }

        public DefaultYesIntentHandler(AlexaMultiLanguageText txt, IAlexaNetCoreMessageLogger log = null) : base(AlexaBuiltInIntents.YesIntent, log)
        {
            DefaultText = txt;
        }

    }
}