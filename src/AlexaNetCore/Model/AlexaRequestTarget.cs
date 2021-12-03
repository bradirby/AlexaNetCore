using System.Text.Json.Serialization;

namespace AlexaSkillDotNet
{
    public class AlexaRequestTarget
    {
        [JsonPropertyName("path")]
        public string Path{ get; set; }

        [JsonPropertyName("address")]
        public string Address{ get; set; }

    }
}