using System.Text.Json.Serialization;

namespace AlexaNetCore.InteractionModel
{
    public class CustomSlotTypeInteractionModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("values")]
        public CustomSlotTypeValueOptionInteractionModel[] Values { get; set; }

        public CustomSlotTypeInteractionModel(string name, CustomSlotTypeValueOptionInteractionModel[] values)
        {
            Name = name;
            Values = values;
        }
    }
}