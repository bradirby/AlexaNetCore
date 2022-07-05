using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AlexaNetCore.RequestModel
{
    public class AlexaRequestSlotValue
    {
        [JsonPropertyName("type")]
        public virtual string ValueType { get; set; }


        /// <summary>
        /// This property is populated when the slot can only accept a single value, or when the slot
        /// allows multiple values but the user only provides one
        /// The ValueType will have the value "Simple".
        /// If the user supplies multiple values, this will be blank
        /// </summary>
        [JsonPropertyName("value")]
        public virtual string Value { get; set; }


        /// <summary>
        /// The Id of the given custom slot value.
        /// This can be blank if you did not specify an ID when you created the slot value.
        /// For dynamic entities, the ID must be set.
        /// </summary>
        [JsonPropertyName("id")]
        public virtual string Id { get; set; }



        /// <summary>
        /// This property is only populated when multiple values are allowed and the user gives more than
        /// one value, otherwise it is null
        /// </summary>
        [JsonPropertyName("values")]
        public virtual List<AlexaRequestSlotValue> Values { get; set; }


        [JsonPropertyName("resolutions")]
        public AlexaResolution Resolutions { get; set; }

        [JsonIgnore]
        public bool ContainsMultipleValues => ValueType == "List";
    }
}