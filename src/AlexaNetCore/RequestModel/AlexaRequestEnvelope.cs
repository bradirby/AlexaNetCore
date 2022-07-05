using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using AlexaNetCore.Model;

namespace AlexaNetCore.RequestModel
{
    public class AlexaRequestEnvelope
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

        public AlexaRequestEnvelope SetSessionAttributeValue(string sessionKey, string val)
        {
            Session.SetAttributeValue(sessionKey, val);
            return this;
        }


        public AlexaRequestSlotValue GetAlexaSlot(string slotKey)
        {
            return Request.Intent.Slots[slotKey]?.RequestSlotValue;
        }

        public Dictionary<int, string> GetIntentHistory()
        {

            var dict = new Dictionary<int, string>();
            try
            {
                var history = Session.GetAttributeValue("IntentHistory", "").ToString();
                if (!string.IsNullOrWhiteSpace(history))
                {
                    var entries = history.Split(';');
                    foreach (var entry in entries)
                    {
                        if (string.IsNullOrWhiteSpace(entry)) continue;
                        var colon = entry.IndexOf(":");
                        var order = entry.Substring(0, colon);
                        var intentName = entry.Substring(colon + 1);
                        dict.Add(int.Parse(order), intentName);
                    }
                }
            }
            catch (Exception)
            {
            }
            return dict;
        }


        public AlexaRequestSlot GetSlot(string slotName)
        {
            return Request.GetSlot(slotName);
        }

        public void SetSlotValue(string slotName, string val)
        {
            Request.SetSlotValue(slotName, val);
        }

        public string GetSlotValue(string slotName, string defaultVal = "")
        {
            var slot = Request.GetSlot(slotName);
            if (slot == null) return defaultVal;
            return slot.GetValueOrDefault(defaultVal);
        }
    }
}