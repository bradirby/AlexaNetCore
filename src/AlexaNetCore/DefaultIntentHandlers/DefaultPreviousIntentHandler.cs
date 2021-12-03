using AlexaNetCore;

namespace AlexaNetCore
{
    public class DefaultPreviousIntentHandler: AlexaIntentHandlerBase
    {
     
        public AlexaMultiLanguageText DefaultText { get; set; }

        public override void Process()
        {
            ResponseEnv.Response.OutputSpeech.SetText(DefaultText);

            ResponseEnv.Response.ShouldEndSession = true;
            ResponseEnv.IntentHandlerName = this.GetType().Name;

        }

        public DefaultPreviousIntentHandler(IAlexaSkillMessageLogger log = null) : base(AlexaBuiltInIntents.PreviousIntent, log)
        {
            DefaultText = new AlexaMultiLanguageText("I'm sorry, I don't know how to do that.");
        }

        public DefaultPreviousIntentHandler(string txt, IAlexaSkillMessageLogger log = null) : base(AlexaBuiltInIntents.PreviousIntent, log)
        {
            DefaultText = new AlexaMultiLanguageText(txt);
        }

        public DefaultPreviousIntentHandler(AlexaMultiLanguageText txt, IAlexaSkillMessageLogger log = null) : base(AlexaBuiltInIntents.PreviousIntent, log)
        {
            DefaultText = txt;
        }

    }
}