using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AlexaSkillDotNet
{
    /// <summary>
    /// A map of key-value pairs to persist in the session.  This is one of the few objects that is in the
    /// request and the response
    /// </summary>
    public class AlexaSession
    {
        public object GetAttributeValue(string sessionKey, object defaultValue = null)
        {
            if (Attributes.ContainsKey(sessionKey)) return Attributes[sessionKey];
            return  defaultValue;
        }

        public void SetAttributeValue(string sessionKey, string val )
        {
            if (Attributes.ContainsKey(sessionKey)) Attributes.Remove(sessionKey);
            Attributes.Add(sessionKey, val);
        }

        /// <summary>
        /// A boolean value indicating whether this is a new session.Returns true for a new session or false for an existing session.
        /// </summary>
        [JsonPropertyName("new")]
        public bool New { get; set; }

        /// <summary>
        /// A string that represents a unique identifier per a user’s active session. Note: A sessionId is consistent for multiple subsequent 
        /// requests for a user and session. If the session ends for a user, then a new unique sessionId value is provided for 
        /// subsequent requests for the same user.
        /// </summary>
        [JsonPropertyName("sessionId")]
        public string SessionId { get; set; }

        /// <summary>
        /// A map of key-value pairs. The attributes map is empty for requests where a new session has started with the attribute new set to true.
        /// We assume this is a simple list of key-value pairs.  The logic will not support complex objects in the session (though Amazon does support this)
        /// </summary>
        [JsonPropertyName("attributes")]
        public Dictionary<string,object> Attributes { get; set; } = new Dictionary<string,object>();

        /// <summary>
        /// An object containing an application ID. This is used to verify that the request was intended for your service.
        /// </summary>
        [JsonPropertyName("application")]
        public AlexaApplication Application { get; set; }

        /// <summary>
        /// An object that describes the user making the request. 
        /// </summary>
        [JsonPropertyName("user")]
        public AlexaUser User { get; set; }
    }
}