using System.Text.Json.Serialization;

namespace AlexaNetCore.Model
{
    public class AlexaDevice
    {
        [JsonPropertyName("deviceId")]
        public string Id { get; set; }
    }
}