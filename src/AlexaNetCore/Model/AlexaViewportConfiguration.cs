using System.Text.Json.Serialization;

namespace AlexaNetCore.Model
{
    public class AlexaViewportConfiguration
    {
        [JsonPropertyName("current")]
        public AlexaViewportConfigurationInstance Current { get; set; }
    }
}