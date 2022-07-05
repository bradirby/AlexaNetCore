using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace AlexaNetCore.InteractionModel
{


    public class CustomSlotTypeValueOptionInteractionModel
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public CustomSlotTypeValueOptionDescriptorInteractionModel SlotTypeValueOptionDescriptorInteractionModel { get; set; }


        public CustomSlotTypeValueOptionInteractionModel(string id, CustomSlotTypeValueOptionDescriptorInteractionModel model)
        {
            Id = string.IsNullOrEmpty(id) ? null : id;
            SlotTypeValueOptionDescriptorInteractionModel = model;
        }
    }
}