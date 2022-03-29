using System;
using System.Collections.Generic;
using System.Linq;
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

    }


    public class CustomSlotTypeInteractionModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("values")]
        public CustomSlotTypeValueOptionInteractionModel[] Values => OptionValues.ToArray();


        private List<CustomSlotTypeValueOptionInteractionModel> OptionValues { get; set; } 

        public CustomSlotTypeInteractionModel(string name)
        {
            Name = name;
            OptionValues = new List<CustomSlotTypeValueOptionInteractionModel>();
        }

        public CustomSlotTypeInteractionModel(string name, List<CustomSlotTypeValueOptionInteractionModel> optionModels)
        {
            Name = name;
            OptionValues = optionModels;
        }

        public CustomSlotTypeInteractionModel(string name, CustomSlotTypeValueOptionInteractionModel[] optionModels)
        {
            Name = name;
            OptionValues = optionModels.ToList();
        }

        public void AddOption(CustomSlotTypeValueOptionInteractionModel opt)
        {
            OptionValues.Add(opt);
        }


    }

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



    public class CustomSlotTypeValueOptionDescriptorInteractionModel
    {
        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("synonyms")] public string[] SynonymStrings => Synonyms.ToArray();

        private List<string> Synonyms { get; set; } = new List<string>();

        public void AddSynonym(string val)
        {
            Synonyms.Add(val);
        }

        public CustomSlotTypeValueOptionDescriptorInteractionModel(string val)
        {
            Value = val;
        }

        public CustomSlotTypeValueOptionDescriptorInteractionModel(string val, List<string> synonyms)
        {
            Value = val;
            Synonyms = synonyms;
        }

        public CustomSlotTypeValueOptionDescriptorInteractionModel(string val, string[] synonyms)
        {
            Value = val;
            Synonyms = synonyms.ToList();
        }

    }
}
