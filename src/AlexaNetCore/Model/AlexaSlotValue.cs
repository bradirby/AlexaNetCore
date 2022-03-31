using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AlexaNetCore
{
    public class AlexaSlotValue
    {
        [JsonPropertyName("type")]
        public virtual string ValueType{ get; set; }


        /// <summary>
        /// This property is only populated when the slot can only accept a single value.
        /// The ValueType will have the value "Simple".
        /// If the slot allows multiple values but the user only selects one, this property will not contain that one
        /// </summary>
        [JsonPropertyName("value")]
        public virtual string Value{ get; set; }


        /// <summary>
        /// This property is only populated when multiple values are allowed, otherwise it is null
        /// </summary>
        [JsonPropertyName("values")]
        public virtual List<AlexaSlotValue> Values{ get; set; }


        [JsonPropertyName("resolutions")]
        public AlexaResolution Resolutions { get; set; }


        public bool SupportsMultipleValues => ValueType == "List";
    }
}