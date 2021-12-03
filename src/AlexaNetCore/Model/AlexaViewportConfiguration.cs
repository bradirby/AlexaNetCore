using System.Text.Json.Serialization;

namespace AlexaSkillDotNet.Model
{
    public class AlexaViewportConfiguration
    {
        [JsonPropertyName("current")]
        public AlexaViewportConfigurationInstance Current { get; set; }
    }
}