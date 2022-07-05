using System;
using System.Collections.Generic;
using System.Dynamic;
using AlexaNetCore.Interfaces;
using AlexaNetCore.RequestModel;

namespace AlexaNetCore.Model
{

    public class AlexaResponseEnvelope : AlexaObjectBase
    {
        private IAlexaMessageLogger MsgLogger;

        private AlexaLocale RequestLocale { get; set; }




        /// <summary>
        /// The version specifier for the response with the value to be defined in this format: “1.0”
        /// </summary>
        public string Version { get; set; }


        /// <summary>
        /// A map of key-value pairs to persist in the session.
        /// </summary>
        private Dictionary<string, object> SessionAttributes { get; set; } = new Dictionary<string, object>();


        private AlexaResponse Response { get; set; }



        /// <summary>
        /// Tells the device if it should end the session immediately or wait for more interaction.
        /// </summary>
        public bool? ShouldEndSession
        {
            get => Response.ShouldEndSession;
            set => Response.ShouldEndSession = value;
        }





        internal AlexaResponseEnvelope(AlexaRequestEnvelope req, IAlexaMessageLogger log = null)
        {
            MsgLogger = log;
            Response = new AlexaResponse(req.Request.Locale, MsgLogger);
            RequestLocale = req.Request.Locale;

            try
            {
                Version = req.Version;

                //copy attributes from request into response
                if (req.Session.Attributes != null)
                    foreach (var attribute in req.Session.Attributes)
                        SessionAttributes.Add(attribute.Key, attribute.Value);
            }
            catch (Exception exc)
            {
                MsgLogger?.Error(exc);
            }
        }

        public AlexaResponseEnvelope AddDirective(IAlexaDirective dir)
        {
            Response.AddDirective(dir);
            return this;
        }

        public AlexaResponseEnvelope RemoveDirective(IAlexaDirective dir)
        {
            Response.RemoveDirective(dir);
            return this;
        }

        /// <summary>
        /// This is not sent to the device but is helpful during debugging
        /// </summary>
        public string IntentHandlerName { get; internal set; }

        public IList<string> Validate()
        {
            var errLst = new List<string>();
            if (Response == null) errLst.Add("ResponseEnvelope cannot find the Response object");
            else errLst.AddRange(Response.Validate());
            return errLst;
        }

        /// <summary>
        /// Returns true if the Reprompt is set
        /// </summary>
        public bool IsRepromptSet => Response.IsRepromptSet;


        /// <summary>
        /// Creates a JSON response appropriate for consumption by an Echo
        /// </summary>
        public string CreateAlexaResponse()
        {
            dynamic obj = new ExpandoObject();
            obj.version = Version;

            //session attributes are optional
            if (SessionAttributes.Count > 0) obj.sessionAttributes = SessionAttributes.ToExpando();

            obj.response = Response.CreateAlexaResponse(RequestLocale);

            var outputStr = Serialize(obj);
            return outputStr;
        }


        public T GetSessionValue<T>(string sessionKey, T defaultVal)
        {
            if (SessionAttributes.ContainsKey(sessionKey))
                return (T)SessionAttributes[sessionKey];
            return defaultVal;
        }

        /// <summary>
        /// Sets an attribute value to be sent back to AWS Servers.  These values will be returned via the
        /// session attributes if the user continues the same session
        /// </summary>
        public void SetSessionValue(string valueName, string val)
        {
            if (SessionAttributes.ContainsKey(valueName)) SessionAttributes.Remove(valueName);
            SessionAttributes.Add(valueName, val);
        }


        public void Speak(string txt, AlexaOutputSpeechType typ = AlexaOutputSpeechType.PlainText)
        {
            Response.SetOutputSpeechText(txt, typ);
        }

        public void Speak(AlexaMultiLanguageText txt, AlexaOutputSpeechType typ = AlexaOutputSpeechType.PlainText)
        {
            Response.SetOutputSpeechText(txt, typ);
        }


        public void Reprompt(AlexaMultiLanguageText txt, AlexaOutputSpeechType typ = AlexaOutputSpeechType.PlainText)
        {
            Response.SetRepromptSpeechText(txt, typ);
        }

        public void Reprompt(string txt, AlexaOutputSpeechType typ = AlexaOutputSpeechType.PlainText)
        {
            Response.SetRepromptSpeechText(txt, typ);
        }

        public string GetOutputSpeechText(AlexaLocale locale)
        {
            return Response.GetOutputSpeachText(locale);
        }

        public AlexaCard AddCard(AlexaMultiLanguageText title, AlexaMultiLanguageText txt, AlexaImageLink urlLink = null)
        {
            return Response.AddCard(title, txt, urlLink);
        }

        public AlexaCard AddCard(string title, string txt, AlexaImageLink urlLink = null)
        {
            return Response.AddCard(title, txt, urlLink);
        }

        public AlexaCard AddCard(AlexaCard card)
        {
            return Response.AddCard(card);
        }
        
        public AlexaOutputSpeech GetOutputSpeech()
        {
            return Response.OutputSpeech;
        }


        public string GetRepromptSpeechText(AlexaLocale locale)
        {
            if (Response?.Reprompt?.OutputSpeech == null) return "";
            return Response.Reprompt.OutputSpeech.GetText(locale);
        }

        public bool HasCard => Response.Card != null;

        public AlexaCard GetCard()
        {
            return Response.Card;
        }

    }
}