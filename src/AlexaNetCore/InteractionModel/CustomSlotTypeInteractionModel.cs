using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace AlexaNetCore.InteractionModel
{
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

        public void AddValueOption(CustomSlotTypeValueOptionInteractionModel opt)
        {
            OptionValues.Add(opt);
        }

        public void AddValueOption(string name)
        {
            OptionValues.Add(new CustomSlotTypeValueOptionInteractionModel(name));
        }

        public void AddValueOption(string name, string synonym)
        {
            OptionValues.Add(new CustomSlotTypeValueOptionInteractionModel(name, synonym));
        }

        public void AddValueOption(string name, List<string> synonym)
        {
            OptionValues.Add(new CustomSlotTypeValueOptionInteractionModel(name, synonym));
        }
        public void AddValueOption(string name, string[] synonym)
        {
            OptionValues.Add(new CustomSlotTypeValueOptionInteractionModel(name, synonym));
        }

    }
}