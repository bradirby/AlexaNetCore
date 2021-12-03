using System.Text.Json.Serialization;

namespace AlexaNetCore
{
    public class AlexaRequestMetadata
    {
        [JsonPropertyName("referrer")]
        public bool Metadata { get; set; }
    }
}