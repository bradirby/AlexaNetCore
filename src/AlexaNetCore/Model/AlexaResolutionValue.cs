using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AlexaNetCore
{
    /// <summary>
    /// One of the possibly multiple slot values matched by an authority
    /// </summary>
    public class AlexaResolutionValue
    {
        [JsonPropertyName("value")]
        public AlexaResolutionValueProperties Value { get; set; }
    }


    /// <summary>
    /// The name and (optional) id of the slot value this authority matched to what the user said
    /// </summary>
    public class AlexaResolutionValueProperties
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}