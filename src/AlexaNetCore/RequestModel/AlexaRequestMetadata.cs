using System.Text.Json.Serialization;

namespace AlexaNetCore.RequestModel
{
    public class AlexaRequestMetadata
    {
        [JsonPropertyName("referrer")]
        public bool Metadata { get; set; }
    }
}