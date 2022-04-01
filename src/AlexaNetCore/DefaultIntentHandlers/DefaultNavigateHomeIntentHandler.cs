using AlexaNetCore;

namespace AlexaNetCore
{
    public class DefaultNavigateHomeIntentHandler : AlexaIntentHandlerBase
    {
     
        public AlexaMultiLanguageText DefaultText { get; set; }

        public override void Process()
        {
            ResponseEnv.SetOutputSpeechText(DefaultText);
            ResponseEnv.ShouldEndSession = true;
        }

        public DefaultNavigateHomeIntentHandler(IAlexaNetCoreMessageLogger log = null) : base(AlexaBuiltInIntents.NavigateHomeIntent, log)
        {
            DefaultText = new AlexaMultiLanguageText("I'm sorry, I don't know how navigate home.");
        }

        public DefaultNavigateHomeIntentHandler(string txt, IAlexaNetCoreMessageLogger log = null) : base(AlexaBuiltInIntents.NextIntent, log)
        {
            DefaultText = new AlexaMultiLanguageText(txt);
        }

        public DefaultNavigateHomeIntentHandler(AlexaMultiLanguageText txt, IAlexaNetCoreMessageLogger log = null) : base(AlexaBuiltInIntents.NextIntent, log)
        {
            DefaultText = txt;
        }

    }
}