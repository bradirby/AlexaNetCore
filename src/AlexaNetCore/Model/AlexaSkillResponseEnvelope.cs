using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace AlexaSkillDotNet
{

    public class AlexaSkillResponseEnvelope  : AlexaObjectBase
    {
        private IAlexaSkillMessageLogger MsgLogger;

        private AlexaLocale RequestLocale { get; set; }

        internal AlexaSkillResponseEnvelope(AlexaSkillRequestEnvelope req, IAlexaSkillMessageLogger log)
        {
            MsgLogger = log;
            Response  = new AlexaResponse(req.Request.Locale, MsgLogger);
            RequestLocale = req.Request.Locale;

            //set the default reprompt text.  This can be overridden.  
            SetRepromptSpeech("Is there anything else I can do?");

            try
            {
                Version = req.Version;

                //copy attributes
                if (req.Session.Attributes != null)
                    foreach (var attribute in req.Session.Attributes)
                        SessionAttributes.Add(attribute.Key, attribute.Value);
            }
            catch (Exception exc)
            {
                MsgLogger?.Error(exc);
                Debugger.Break();
            }
        }

       
        public bool? ShouldEndSession
        {
            get => Response.ShouldEndSession;
            set => Response.ShouldEndSession = value;
        }

       
        /// <summary>
        /// The version specifier for the response with the value to be defined as: “1.0”
        /// </summary>
        public string Version { get; set; }


        /// <summary>
        /// A map of key-value pairs to persist in the session.
        /// </summary>
        private Dictionary<string, object> SessionAttributes { get; set; } = new Dictionary<string, object>();


        /// <summary>
        /// This is not sent to the device but is helpful during debugging
        /// </summary>
        public string IntentHandlerName { get; internal set; }

        public AlexaResponse Response { get; set; }

        public bool IsRepromptSet => Response.IsRepromptSet;


        /// <summary>
        /// Creates a JSON response appropriate for consumption by an Echo
        /// </summary>
        public string CreateAlexaResponse(IAlexaTranslationService translator = null)
        {
            dynamic obj = new ExpandoObject();
            obj.version = Version;

            //session attributes are optional
            if (SessionAttributes.Count > 0) obj.sessionAttributes = SessionAttributes.ToExpando();

            obj.response = Response.GetJson(RequestLocale, translator);

            var outputStr = Serialize(obj);
            return outputStr;
        }

        public void ValidateResponse()
        {
            //https://developer.amazon.com/en-US/docs/alexa/custom-skills/request-and-response-json-reference.html
            //When using the <audio> SSML tag:
            //  The combined total time for all audio files in the outputSpeech property of the response can't be more than 240 seconds.
            //  The combined total time for all audio files in the reprompt property of the response can't be more than 90 seconds.
            //  The token included in an audioItem.stream for the AudioPlayer.Play directive can't exceed 1024 characters.
            //  The url included in an audioItem.stream for the AudioPlayer.Play directive can't exceed 8000 characters.
            //  The payload of a CustomInterfaceController.SendDirective directive can't exceed 1000 bytes. For details about this directive, see Respond to Alexa with a directive targeted to a gadget.
            //The total size of your response can't exceed 120 kilobytes.

            Response.Card?.Validate();

        }

        internal T GetSessionValue<T>(string sessionKey, T defaultVal)
        {
            if (SessionAttributes.ContainsKey(sessionKey))
                return (T)SessionAttributes[sessionKey];
            return defaultVal;
        }

        public void SetSessionValue(string sessionKey, string value)
        {
            SessionAttributes.Remove(sessionKey);
            SessionAttributes.Add(sessionKey, value);
        }

        public void AddToIntentHistory(string intentName, Dictionary<int, string> history, int historySize = 10)
        {
            history ??= new Dictionary<int, string>();
            var newHistory = new Dictionary<int, string>();
            int counter = 1;
            newHistory.Add(counter, intentName);
            foreach (var entry in history.OrderBy(h => h.Key))
                newHistory.Add(++counter, entry.Value);
            SetIntentHistory(newHistory, historySize);

        }

        internal string GetIntentHistoryString(Dictionary<int, string> history, int historySize = 10)
        {
            if (history == null) history = new Dictionary<int, string>();
            var sb = new StringBuilder();
            for (int n = 1; n <= historySize; n++)
            {
                if (history.ContainsKey(n)) sb.Append($"{n}:{history[n]};");
            }

            return sb.ToString();

        }

        public void SetIntentHistory(Dictionary<int, string> history, int historySize = 10)
        {
            var str = GetIntentHistoryString(history, historySize);
            SetSessionValue("IntentHistory", str);

        }

        public void SetOutputSpeech(string txt)
        {
            Response.SetOutputSpeech(txt);
        }

        public void SetOutputSpeech(AlexaMultiLanguageText txt)
        {
            Response.SetOutputSpeech(txt);
        }

        public void SetRepromptSpeech(AlexaMultiLanguageText txt)
        {
            Response.SetRepromptSpeech(txt);
        }

        public void SetRepromptSpeech(string txt)
        {
            Response.SetRepromptSpeech(txt);
        }

        public string GetOutputSpeach(AlexaLocale locale, IAlexaTranslationService translator = null)
        {
            return Response.GetOutputSpeach(locale, translator);
        }

        public void SetDefaultResponseLocale(AlexaLocale locale)
        {
            Response.SetDefaultResponseLocale(locale);
        }


        /// <summary>
        /// Sets an attribute value to be sent back to AWS Servers.  These values will be returned via the
        /// session attributes if the user continues the same session
        /// </summary>
        public void SetAttributeValue(string valueName, string val)
        {
            if (SessionAttributes.ContainsKey(valueName)) SessionAttributes.Remove(valueName);
            SessionAttributes.Add(valueName, val);
        }
    }
}