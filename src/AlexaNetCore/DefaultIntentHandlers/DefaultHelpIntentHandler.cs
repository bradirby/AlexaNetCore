using System.Runtime.CompilerServices;
using System.Text;
using AlexaNetCore;
using Amazon.Runtime.Internal;

namespace AlexaNetCore
{
    public class DefaultHelpIntentHandler : AlexaIntentHandlerBase
    {

        public override void Process()
        {
            ResponseEnv.SetOutputSpeech(HelpTxt);
            ResponseEnv.ShouldEndSession = false;
            ResponseEnv.IntentHandlerName = this.GetType().Name;
        }

        public AlexaMultiLanguageText HelpTxt { get; private set; }

        public DefaultHelpIntentHandler(IAlexaNetCoreMessageLogger log = null) : base(AlexaBuiltInIntents.HelpIntent, log)
        {
            HelpTxt = new AlexaMultiLanguageText("I'm sorry you're having trouble.  Please ask again and I'll try harder.");
        }

        public DefaultHelpIntentHandler(string defaultTxt, IAlexaNetCoreMessageLogger log = null) : base(AlexaBuiltInIntents.HelpIntent, log)
        {
            HelpTxt = new AlexaMultiLanguageText(defaultTxt);
        }

        public DefaultHelpIntentHandler(AlexaMultiLanguageText defaultTxt, IAlexaNetCoreMessageLogger log = null) : base(AlexaBuiltInIntents.HelpIntent, log)
        {
            HelpTxt =  defaultTxt;
        }

    
    }
}