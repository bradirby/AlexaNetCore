using System.Text.Json.Serialization;
using AlexaNetCore.Model;

namespace AlexaNetCore.RequestModel
{
    public class AlexaRequestEnvelope : IAlexaRequestEnvelope
    {
        public AlexaRequestEnvelope()
        {

        }

        public string GetUserId()
        {
            return Session.User.UserID;
        }

        /// <summary>
        /// The version specifier for the request with the value defined as: “1.0”
        /// </summary>
        [JsonPropertyName("version")]
        public string Version { get; set; } = "1.0";

        /// <summary>
        /// The session object provides additional context associated with the request.
        /// </summary>
        [JsonPropertyName("session")]
        public AlexaSession Session { get; set; }

        [JsonPropertyName("context")]
        public AlexaContext Context { get; set; }

        /// <summary>
        /// An object that is composed of associated parameters that further describes the user’s request. 
        /// </summary>
        [JsonPropertyName("request")]
        public AlexaRequest Request { get; set; }

        public AlexaLocale GetLocale()
        {
            return Request.Locale;
        }

        public object GetSessionAttribute(string sessionKey, object defaultValue = null)
        {
            return Session.GetAttributeValue(sessionKey, defaultValue);
        }

        public void SetSessionAttribute(string sessionKey, string value )
        {
            Session.SetAttributeValue(sessionKey, value);
        }

        public AlexaRequestSlot GetSlot(string slotName)
        {
            return Request.GetSlot(slotName);
        }


        /// <summary>
        /// Setting a slot value is not normally done but is here to allow setting values for testing
        /// </summary>
        public void SetSlotValue(string slotName, string val)
        {
            Request.SetSlotValue(slotName, val);
        }

        public string GetSSLForUserFirstName(string defaulVal)
        {
            if (Context.System.Person == null) return defaulVal;
            return $"<alexa name:type='first' personId='{Context.System.Person.PersonId}'/> ";
        }

        public string IntentName => Request?.Intent?.Name;
    }


    public interface IAlexaRequestEnvelope
    {
        /// <summary>
        /// Name of the intent the user requested;
        /// </summary>
        string IntentName { get; }

        string GetSSLForUserFirstName(string defaulVal = "");

        string GetUserId();

        /// <summary>
        /// The version specifier for the request with the value defined as: “1.0”
        /// </summary>
        string Version { get; set; }

        /// <summary>
        /// The session object provides additional context associated with the request.
        /// </summary>
        AlexaSession Session { get; set; }

        AlexaContext Context { get; set; }

        /// <summary>
        /// An object that is composed of associated parameters that further describes the user’s request. 
        /// </summary>
        AlexaRequest Request { get; set; }

        AlexaLocale GetLocale();

        object GetSessionAttribute(string sessionKey, object defaultValue = null);


        AlexaRequestSlot GetSlot(string slotName);


        /// <summary>
        /// Setting a slot value is not normally done but is here to allow setting values for testing
        /// </summary>
        void SetSlotValue(string slotName, string val);

    }
}