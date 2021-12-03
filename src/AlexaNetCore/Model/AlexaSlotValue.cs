using System.Text.Json.Serialization;

namespace AlexaNetCore
{
    public class AlexaSlotValue
    {
        [JsonPropertyName("type")]
        public virtual string ValueType{ get; set; }

        [JsonPropertyName("value")]
        public virtual string Value{ get; set; }

    }
}