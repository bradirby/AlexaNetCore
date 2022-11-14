using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AlexaNetCore.RequestModel
{

    /// <summary>
    /// A descriptor for the recognized and matched value for the slot.  This is only added to the request when the slot has no validations
    /// </summary>
    public class AlexaRequestSlotValueDescriptor
    {

        /// <summary>
        /// This is not the date type of the value.  It is a string with the possible values of "Simple" or ...
        /// </summary>
        [JsonPropertyName("type")]
        public virtual string ValueType { get; set; }


        /// <summary>
        /// This property is populated when the slot can only accept a single value, or when the slot
        /// allows multiple values but the user only provides one.
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
        public virtual List<AlexaRequestSlotValueDescriptor> Values { get; set; }


        [JsonPropertyName("resolutions")]
        public AlexaResolution Resolutions { get; set; }

        /// <summary>
        /// Flag indicating if the user specified multiple values for the slot.  If the slot allows multiple values
        /// but the user only supplied one, this will be false.
        /// </summary>
        [JsonIgnore]
        public bool ContainsMultipleValues => ValueType == "List";
    }
}