using System.Text.Json.Serialization;

namespace AlexaSkillDotNet
{
    public class AlexaRequestMetadata
    {
        [JsonPropertyName("referrer")]
        public bool Metadata { get; set; }
    }
}