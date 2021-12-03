using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AlexaSkillDotNet.Model
{
    public class AlexaViewport
    {
        [JsonPropertyName("id")]
        public string Id{ get; set; }

        [JsonPropertyName("type")]
        public string ViewportType { get; set; }

        [JsonPropertyName("canRotate")]
        public bool CanRotate { get; set; }

        [JsonPropertyName("configuration")]
        public AlexaViewportConfiguration Configuration { get; set; }

        [JsonPropertyName("presentationType")]
        public string PresentationType { get; set; }

        [JsonPropertyName("experiences")]
        public List<AlexaExperience> Experiences { get; set; }

        [JsonPropertyName("mode")]
        public string Mode { get; set; }

        [JsonPropertyName("shape")]
        public string Shape { get; set; }

        [JsonPropertyName("pixelWidth")]
        public int PixelWidth { get; set; }

        [JsonPropertyName("pixelHeight")]
        public int PixelHeight { get; set; }

        [JsonPropertyName("dpi")]
        public int DPI { get; set; }

        [JsonPropertyName("currentPixelWidth")]
        public int CurrentPixelWidth { get; set; }

        [JsonPropertyName("currentPixelHeight")]
        public int CurrentPixelHeight { get; set; }

        [JsonPropertyName("touch")]
        public List<string> Touch { get; set; }

        [JsonPropertyName("video")]
        public AlexaVideo Video { get; set; }
    }
}