using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace AlexaNetCore.InteractionModel
{


    public class CustomSlotTypeValueOptionInteractionModel
    {
        [JsonPropertyName("name")]
        public CustomSlotTypeValueOptionDescriptorInteractionModel SlotTypeValueOptionDescriptorInteractionModel { get; set; }

        public CustomSlotTypeValueOptionInteractionModel(CustomSlotTypeValueOptionDescriptorInteractionModel model)
        {
            SlotTypeValueOptionDescriptorInteractionModel = model;
        }
    }
}