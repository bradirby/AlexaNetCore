using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json.Serialization;
using AlexaNetCore.Model;

namespace AlexaNetCore
{
    public class AlexaSkillRequestEnvelope
    {

        public AlexaSkillRequestEnvelope()
        {

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


        public AlexaSlotValue GetAlexaSlot(string slotKey)
        {
            return Request.Intent.Slots[slotKey]?.SlotValue;
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
            catch (Exception )
            {
            }
            return dict;
        }



        [DebuggerStepThrough]
        public T GetSlotValue<T>(string slotName,T defaultVal)
        {
            return Request.GetSlotValue(slotName, defaultVal);
        }
    }
}