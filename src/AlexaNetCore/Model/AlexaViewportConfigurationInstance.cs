using System.Text.Json.Serialization;

namespace AlexaNetCore.Model
{
    public class AlexaViewportConfigurationInstance
    {

        [JsonPropertyName("mode")]
        public string Mode { get; set; }

        [JsonPropertyName("video")]
        public AlexaVideo Video { get; set; }

        [JsonPropertyName("size")]
        public AlexaViewportConfigurationSize Size { get; set; }
    }
}