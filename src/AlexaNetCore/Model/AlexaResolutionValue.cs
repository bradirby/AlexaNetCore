using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AlexaNetCore
{
    public class AlexaResolutionValue
    {
        [JsonPropertyName("value")]
        public AlexaResolutionValueProperties Value { get; set; }
    }


    public class AlexaResolutionValueProperties
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}