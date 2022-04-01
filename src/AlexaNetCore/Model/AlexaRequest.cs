using System;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace AlexaNetCore
{
    public class AlexaRequest
    {

        /// <summary>
        /// Describes the request type with possible values of "LaunchRequest", "IntentRequest", "SessionEndedRequest"
        /// </summary>
        [JsonPropertyName("type")]
        public string RequestType { get; set; } 

        [JsonPropertyName("locale")]
        public string LocaleString { get; set; }

        [JsonIgnore]
        public AlexaLocale Locale => AlexaLocale.Parse(LocaleString);

        /// <summary>
        /// Provides the date and time when Alexa sent the request. Use this to verify that the request is current and not part of a “replay” attack.
        /// </summary>
        [JsonPropertyName("timestamp")]
        public DateTime TimeStamp { get; set; }

        /// <summary>
        /// Represents a unique identifier for the specific request.
        /// </summary>
        [JsonPropertyName("requestId")]
        public string RequestId { get; set; }

        /// <summary>
        /// Null unless ActionType = IntentRequest
        /// </summary>
        [JsonPropertyName("intent")]
        public AlexaIntent Intent { get; set; }


        [JsonPropertyName("targetURI")]
        public string TargetUri{ get; set; }

        [JsonPropertyName("target")]
        public AlexaRequestTarget Target { get; set; }

        [JsonPropertyName("metadata")]
        public AlexaRequestMetadata Metadata{ get; set; }

        
        /// <summary>
        /// Describes why the session ended (blank if not a SessionEnded request. Possible values:
        ///   USER_INITIATED: The user explicitly ended the session.
        ///   ERROR: An error occurred that caused the session to end.
        ///   EXCEEDED_MAX_REPROMPTS: The user either did not respond or responded with an utterance that did not match any of the intents defined in your voice interface.
        /// </summary>
        [JsonPropertyName("reason")]
        public string Reason { get; set; }

        [JsonPropertyName("shouldLinkResultBeReturned")]
        public bool ShouldLinkResultBeReturned { get; set; }

        
        [DebuggerStepThrough]
        public T GetSlotValue<T>(string slotName,T defaultVal)
        {
            return Intent.GetSlotValue(slotName, defaultVal);
        }

    }
}