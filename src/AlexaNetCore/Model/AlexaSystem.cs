using System.Text.Json.Serialization;

namespace AlexaSkillDotNet.Model
{
    public class AlexaSystem
    {
        [JsonPropertyName("application")]
        public AlexaApplication Application { get; set; }

        [JsonPropertyName("user")]
        public AlexaUser User { get; set; }

        [JsonPropertyName("device")]
        public AlexaDevice Device { get; set; }

        [JsonPropertyName("apiEndpoint")]
        public string ApiEndpoint { get; set; }

        [JsonPropertyName("apiAccessToken")]
        public string ApiAccessToken { get; set; }
    }
}