using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AlexaNetCore.Interfaces;
using AlexaNetCore.Model;

namespace AlexaNetCore
{

    public interface IFallbackIntentHandler
    {
        public string Sensitivity { get; }
    }


    public class DefaultFallbackIntentHandler : AlexaIntentHandlerBase, IFallbackIntentHandler
    {
        public AlexaMultiLanguageText HelpText { get; private set; }

        public string Sensitivity { get; private set; } = "RECOMMENDED";


        public override Task ProcessAsync()
        {
            Speak(HelpText.GetText(RequestEnv.GetLocale()));
            KeepSessionActiveAfterResponse();
            return Task.CompletedTask;

        }


        public DefaultFallbackIntentHandler(IAlexaMessageLogger log = null) : base(AlexaIntentType.Custom, AlexaBuiltInIntents.FallbackIntent, log)
        {
            HelpText = new AlexaMultiLanguageText("I'm sorry, I didn't quite get that.  Can you try again?");
        }
 
        public DefaultFallbackIntentHandler(string helpText, IAlexaMessageLogger log = null) : base(AlexaIntentType.Custom, AlexaBuiltInIntents.FallbackIntent, log)
        {
            HelpText = new AlexaMultiLanguageText(helpText);
        }
 
        public DefaultFallbackIntentHandler(AlexaMultiLanguageText helpText, IAlexaMessageLogger log = null) : base(AlexaIntentType.Custom, AlexaBuiltInIntents.FallbackIntent, log)
        {
            HelpText =  helpText;
}

        public DefaultFallbackIntentHandler SetSensitivityHigh()
        {
            Sensitivity = "HIGH";
            return this;
        }

        public DefaultFallbackIntentHandler SetSensitivityMedium()
        {
            Sensitivity = "MEDIUM";
            return this;
        }

        public DefaultFallbackIntentHandler SetSensitivityLow()
        {
            Sensitivity = "LOW";
            return this;
        }

        public DefaultFallbackIntentHandler SetSensitivityRecommended()
        {
            Sensitivity = "RECOMMENDED";
            return this;
        }
    }
}