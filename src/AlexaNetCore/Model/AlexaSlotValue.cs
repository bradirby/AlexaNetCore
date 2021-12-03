using System.Text.Json.Serialization;

namespace AlexaSkillDotNet
{
    public class AlexaSlotValue
    {
        [JsonPropertyName("type")]
        public virtual string ValueType{ get; set; }

        [JsonPropertyName("value")]
        public virtual string Value{ get; set; }

    }
}