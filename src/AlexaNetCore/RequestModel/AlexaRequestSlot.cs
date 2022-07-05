using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace AlexaNetCore.RequestModel
{

    /// <summary>
    /// An instance of a slot returned to your intent via the Request Envelope.  If you are looking for how to
    /// define a slot, check <see cref="Model.AlexaSlot"/>
    /// </summary>
    public class AlexaRequestSlot
    {

        [JsonPropertyName("name")]
        public virtual string Name { get; set; }


        /// <summary>
        /// This is the value the AI engine recognized for the slot.  It may or may not be in the list of valid values for the slot.
        /// If you want a value from the list of valid options, use MatchedValues
        /// </summary>
        [JsonPropertyName("value")]
        public virtual string SpokenValue { get; set; }


        /// <summary>
        /// List of valid values that match the utterance from the user.  All these values come from the list of valid values that as provided at Slot Definition time.
        /// There is typically only one, but can be more if the match was inconclusive.
        /// </summary>
        [JsonIgnore]
        public IEnumerable<AlexaResolutionValue> MatchedValues
        {
            get
            {
                if (Resolutions?.ResolutionsPerAuthority == null) return null;
                var valueObj = Resolutions.ResolutionsPerAuthority.FirstOrDefault();
                if (valueObj?.Values == null) return null;
                return valueObj.Values;
            }
        }



        [JsonPropertyName("resolutions")]
        public AlexaResolution Resolutions { get; set; }

        [JsonPropertyName("confirmationStatus")]
        public virtual string ConfirmationStatus { get; set; }

        [JsonPropertyName("source")]
        public virtual string Source { get; set; }

        [JsonPropertyName("slotValue")]
        public AlexaRequestSlotValue RequestSlotValue { get; set; }

        public string GetValueOrDefault(string defaultVal = "")
        {
            if (string.IsNullOrEmpty(SpokenValue)) return defaultVal;
            return SpokenValue;
        }
    }
}