using System;
using System.Text;
using System.Text.Json.Serialization;

namespace AlexaNetCore.InteractionModel
{
    public class SlotInteractionModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("type")]
        public string SlotType { get; set; }

        public SlotInteractionModel(string name, string typ)
        {
            Name = name;
            SlotType = typ;
        }

    }
}
