using System;
using System.Text;
using System.Text.Json.Serialization;

namespace AlexaNetCore.InteractionModel
{
    public class SlotDefinition
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }



        [JsonPropertyName("type")]
        public string SlotType { get; set; }


        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("multipleValues")]
        public MultiValueSlotInteractionModel Enabled { get; set; }


        public SlotDefinition(string name, string typ, bool allowMultipleValues )
        {
            Name = name;
            SlotType = typ;
            if (allowMultipleValues) Enabled = new MultiValueSlotInteractionModel();
        }

    }
}
