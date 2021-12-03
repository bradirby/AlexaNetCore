using AlexaNetCore;

namespace AlexaNetCore
{
    public class DefaultStopIntentHandler : AlexaIntentHandlerBase
    {
     
        public AlexaMultiLanguageText DefaultText { get; set; }

        public override void Process()
        {
            ResponseEnv.Response.OutputSpeech.SetText(DefaultText);

            ResponseEnv.Response.ShouldEndSession = true;
            ResponseEnv.IntentHandlerName = this.GetType().Name;

        }

        public DefaultStopIntentHandler(IAlexaNetCoreMessageLogger log = null) : base(AlexaBuiltInIntents.StopIntent, log)
        {
            DefaultText = new AlexaMultiLanguageText("Goodbye.");
        }

        public DefaultStopIntentHandler(string txt, IAlexaNetCoreMessageLogger log = null) : base(AlexaBuiltInIntents.StopIntent, log)
        {
            DefaultText = new AlexaMultiLanguageText(txt);
        }

        public DefaultStopIntentHandler(AlexaMultiLanguageText txt, IAlexaNetCoreMessageLogger log = null) : base(AlexaBuiltInIntents.StopIntent, log)
        {
            DefaultText = txt;
        }

    }
}