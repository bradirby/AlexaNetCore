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

    public class CustomSlotTypeValueOption
    {
        public CustomSlotTypeValueOptionDescriptor SlotTypeValueOptionDescriptor { get; set; }

        public CustomSlotTypeValueOption(CustomSlotTypeValueOptionDescriptor model)
        {
            SlotTypeValueOptionDescriptor = model;
        }

        public CustomSlotTypeValueOption(string val)
        {
            SlotTypeValueOptionDescriptor = new CustomSlotTypeValueOptionDescriptor(val) ;
        }

        public CustomSlotTypeValueOption(string val, string synonym)
        {
            SlotTypeValueOptionDescriptor = new CustomSlotTypeValueOptionDescriptor(val, synonym) ;
        }

        public CustomSlotTypeValueOption(AlexaMultiLanguageText val, string synonym)
        {
            SlotTypeValueOptionDescriptor = new CustomSlotTypeValueOptionDescriptor(val, synonym) ;
        }

        public CustomSlotTypeValueOption(AlexaMultiLanguageText val, AlexaMultiLanguageText synonym)
        {
            SlotTypeValueOptionDescriptor = new CustomSlotTypeValueOptionDescriptor(val, synonym) ;
        }

        public CustomSlotTypeValueOption(string val, string[] synonyms)
        {
            SlotTypeValueOptionDescriptor = new CustomSlotTypeValueOptionDescriptor(val, synonyms) ;
        }
        
        public CustomSlotTypeValueOption(AlexaMultiLanguageText val, AlexaMultiLanguageText[] synonyms)
        {
            SlotTypeValueOptionDescriptor = new CustomSlotTypeValueOptionDescriptor(val, synonyms) ;
        }

        public CustomSlotTypeValueOption(AlexaMultiLanguageText val, string[] synonyms)
        {
            SlotTypeValueOptionDescriptor = new CustomSlotTypeValueOptionDescriptor(val, synonyms) ;
        }

        public void AddSynonym(string val)
        {
            SlotTypeValueOptionDescriptor.AddSynonym(val);
        }

        public CustomSlotTypeValueOptionInteractionModel GetInteractionModel(AlexaLocale locale = null)
        {
            locale ??= AlexaLocale.English_US;
            
            return new CustomSlotTypeValueOptionInteractionModel(  SlotTypeValueOptionDescriptor.GetInteractionModel(locale));
        }
    }
}