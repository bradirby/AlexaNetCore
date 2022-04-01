namespace AlexaNetCore
{
    public class DefaultLaunchIntentHandler : AlexaIntentHandlerBase
    {
        public DefaultLaunchIntentHandler(IAlexaNetCoreMessageLogger log = null) : base(AlexaRequestType.LaunchRequest, log)
        {
            IntentType = AlexaRequestType.LaunchRequest;
            LaunchText = new AlexaMultiLanguageText("Hello, what can I do for you today?");
            IncludeInInteractionModel = false;
        }

        public DefaultLaunchIntentHandler(string defaultTxt, IAlexaNetCoreMessageLogger log = null) : base(AlexaRequestType.LaunchRequest, log)
        {
            IntentType = AlexaRequestType.LaunchRequest;
            IncludeInInteractionModel = false;
            LaunchText = new AlexaMultiLanguageText(defaultTxt);
        }

        public DefaultLaunchIntentHandler(AlexaMultiLanguageText defaultTxt, IAlexaNetCoreMessageLogger log = null) : base(AlexaRequestType.LaunchRequest, log)
        {
            IntentType = AlexaRequestType.LaunchRequest;
            IncludeInInteractionModel = false;
            LaunchText = defaultTxt;
        }

        public AlexaMultiLanguageText LaunchText { get; private set; }


        public override void Process()
        {
            ResponseEnv.SetOutputSpeechText(LaunchText);
            ResponseEnv.ShouldEndSession = false;
        }
    }
}
