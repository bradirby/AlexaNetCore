using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AlexaSkillDotNet
{
    public class AlexaResolutionValue
    {
        [JsonPropertyName("value")]
        public Dictionary<string, string> Value { get; set; } = new Dictionary<string, string>();
    }
}