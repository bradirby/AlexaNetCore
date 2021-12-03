using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AlexaSkillDotNet
{
    public class AlexaResolutionPerAuthority
    {
        [JsonPropertyName("authority")]
        public string Authority { get; set; }

        [JsonPropertyName("status")]
        public Dictionary<string, string> Status { get; private set; } = new Dictionary<string, string>();

        [JsonPropertyName("values")]
        public List<AlexaResolutionValue> Values { get; private set; } 
    }
}