using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AlexaSkillDotNet.Model
{
    public class AlexaVideo
    {
        [JsonPropertyName("codecs")]
        public List<string> Codecs { get; set; }
    }
}