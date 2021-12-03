using System.Runtime.CompilerServices;
using System.Text;
using AlexaNetCore;

namespace AlexaNetCore
{
    public class DefaultFallbackIntentHandler : AlexaIntentHandlerBase
    {
        public AlexaMultiLanguageText HelpText { get; private set; }

        public override void Process()
        {
            ResponseEnv.Response.OutputSpeech.SetText(HelpText);
            ResponseEnv.Response.ShouldEndSession = false;         
            ResponseEnv.IntentHandlerName = this.GetType().Name;
        }

        public DefaultFallbackIntentHandler(IAlexaSkillMessageLogger log) : base(AlexaBuiltInIntents.FallbackIntent, log)
        {
            HelpText = new AlexaMultiLanguageText("I'm sorry, I didn't quite get that.  Can you try again?");
        }
 
        public DefaultFallbackIntentHandler(string helpText, IAlexaSkillMessageLogger log) : base(AlexaBuiltInIntents.FallbackIntent, log)
        {
            HelpText = new AlexaMultiLanguageText(helpText);
        }
 
        public DefaultFallbackIntentHandler(AlexaMultiLanguageText helpText, IAlexaSkillMessageLogger log) : base(AlexaBuiltInIntents.FallbackIntent, log)
        {
            HelpText =  helpText;
        }
    }
}