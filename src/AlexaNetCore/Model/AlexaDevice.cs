using System.Text.Json.Serialization;

namespace AlexaSkillDotNet.Model
{
    public class AlexaDevice
    {
        [JsonPropertyName("deviceId")]
        public string Id { get; set; }
    }
}