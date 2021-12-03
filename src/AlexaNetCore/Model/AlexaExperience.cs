using System.Text.Json.Serialization;

namespace AlexaNetCore.Model
{
    public class AlexaExperience
    {
        [JsonPropertyName("arcMinuteWidth")]
        public int ArcMinuteWidth { get; set; }

        [JsonPropertyName("arcMinuteHeight")]
        public int ArcMinuteHeight { get; set; }

        [JsonPropertyName("canRotate")]
        public bool CanRotate{ get; set; }

        [JsonPropertyName("canResize")]
        public bool CanResize{ get; set; }


    }
}