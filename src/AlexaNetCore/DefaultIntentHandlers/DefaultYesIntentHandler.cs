using AlexaNetCore;

namespace AlexaNetCore
{
    public class DefaultYesIntentHandler: AlexaIntentHandlerBase
    {
     
        public AlexaMultiLanguageText DefaultText { get; set; }

        public override void Process()
        {
            ResponseEnv.Response.OutputSpeech.SetText(DefaultText);

            ResponseEnv.Response.ShouldEndSession = true;
            ResponseEnv.IntentHandlerName = this.GetType().Name;

        }

        public DefaultYesIntentHandler(IAlexaNetCoreMessageLogger log = null) : base(AlexaBuiltInIntents.YesIntent, log)
        {
            DefaultText = new AlexaMultiLanguageText("I'm sorry, I don't know how to do that.");
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