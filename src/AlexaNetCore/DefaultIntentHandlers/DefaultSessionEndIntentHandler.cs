using System.Threading.Tasks;
using AlexaNetCore.Interfaces;
using AlexaNetCore.Model;

namespace AlexaNetCore
{
    public class DefaultSessionEndRequest : AlexaIntentHandlerBase
    {
        public static string intentName = "SessionEndRequest";

        public override Task ProcessAsync()
        {
            Speak(CancelText.GetText(RequestEnv.GetLocale()));
            EndSessionAfterResponse();
            return Task.CompletedTask;

        }

        public AlexaMultiLanguageText CancelText { get; private set; } 

        public DefaultSessionEndRequest(IAlexaMessageLogger log = null) : base(AlexaIntentType.SessionEnded,intentName, log)
        {
            Init(new AlexaMultiLanguageText("OK, Ending the session"));
        }

        public DefaultSessionEndRequest(string txt, IAlexaMessageLogger log = null) : base(AlexaIntentType.SessionEnded,intentName , log)
        {
            Init(new AlexaMultiLanguageText(txt));
        }
        public DefaultSessionEndRequest(AlexaMultiLanguageText txt, IAlexaMessageLogger log = null) : base(AlexaIntentType.SessionEnded,intentName, log)
        {
            Init(txt);
        }

        private void Init(AlexaMultiLanguageText txt)
        {
            CancelText=txt;
        }
    }
}