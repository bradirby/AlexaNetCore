using System.Text.Json.Serialization;

namespace AlexaNetCore.Model
{
    public class AlexaViewportConfigurationSize
    {
        [JsonPropertyName("type")]
        public string TypeName { get; set; }

        [JsonPropertyName("pixelWidth")]
        public int PixelWidth { get; set; }

        [JsonPropertyName("pixelHeight")]
        public int PixelHeight { get; set; }
    }
}