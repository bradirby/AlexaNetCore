using System.Threading.Tasks;
using AlexaNetCore.Interfaces;
using AlexaNetCore.Model;
using Microsoft.Extensions.Logging;

namespace AlexaNetCore
{
    public class DefaultSessionEndRequest : AlexaIntentHandlerBase
    {
        public static string intentName = "SessionEndRequest";

        public override Task ProcessAsync()
        {
            Speak(CancelText.GetText(GetLocale()));
            EndSessionAfterResponse();
            return Task.CompletedTask;

        }

        public AlexaMultiLanguageText CancelText { get; private set; } 

        public DefaultSessionEndRequest(ILogger log = null) : base(AlexaIntentType.SessionEnded,intentName, log)
        {
            Init(new AlexaMultiLanguageText("OK, Ending the session"));
        }

        public DefaultSessionEndRequest(string txt, ILogger log = null) : base(AlexaIntentType.SessionEnded,intentName , log)
        {
            Init(new AlexaMultiLanguageText(txt));
        }
        public DefaultSessionEndRequest(AlexaMultiLanguageText txt, ILogger log = null) : base(AlexaIntentType.SessionEnded,intentName, log)
        {
            Init(txt);
        }

        private void Init(AlexaMultiLanguageText txt)
        {
            CancelText=txt;
        }
    }
}