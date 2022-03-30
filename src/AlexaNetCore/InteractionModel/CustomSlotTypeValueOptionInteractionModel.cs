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

        public CustomSlotTypeValueOptionInteractionModel(string val)
        {
            SlotTypeValueOptionDescriptorInteractionModel = new CustomSlotTypeValueOptionDescriptorInteractionModel(val) ;
        }

        public CustomSlotTypeValueOptionInteractionModel(string val, string synonym)
        {
            SlotTypeValueOptionDescriptorInteractionModel = new CustomSlotTypeValueOptionDescriptorInteractionModel(val, synonym) ;
        }

        public CustomSlotTypeValueOptionInteractionModel(string val, List<string> synonyms)
        {
            SlotTypeValueOptionDescriptorInteractionModel = new CustomSlotTypeValueOptionDescriptorInteractionModel(val, synonyms) ;
        }

        public CustomSlotTypeValueOptionInteractionModel(string val, string[] synonyms)
        {
            SlotTypeValueOptionDescriptorInteractionModel = new CustomSlotTypeValueOptionDescriptorInteractionModel(val, synonyms.ToList()) ;
        }
        
        public void AddSynonym(string val)
        {
            SlotTypeValueOptionDescriptorInteractionModel.AddSynonym(val);
        }
    }
}