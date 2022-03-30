using System;
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
        public CustomSlotTypeValueOptionInteractionModel[] Values { get; set; }

        public CustomSlotTypeInteractionModel(string name, CustomSlotTypeValueOptionInteractionModel[] values)
        {
            Name = name;
            Values = values;
        }
    }

    public class CustomSlotType
    {

        /// <summary>
        /// the name of the custom slot type.  this is always the same regardless of language
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Options allowed for this slot
        /// </summary>
        private List<CustomSlotTypeValueOption> OptionValues { get; set; } 

        public CustomSlotType(string name)
        {
            Name = name;
            OptionValues = new List<CustomSlotTypeValueOption>();
        }

        public CustomSlotType(string name, List<CustomSlotTypeValueOption> optionModels)
        {
            Name = name;
            OptionValues = optionModels;
        }

        public CustomSlotType(string name, CustomSlotTypeValueOption[] optionModels)
        {
            Name = name;
            OptionValues = optionModels.ToList();
        }

        public void AddValueOption(CustomSlotTypeValueOption opt)
        {
            OptionValues.Add(opt);
        }

        public void AddValueOption(string name)
        {
            OptionValues.Add(new CustomSlotTypeValueOption(name));
        }

        public void AddValueOption(string name, string synonym)
        {
            OptionValues.Add(new CustomSlotTypeValueOption(name, synonym));
        }

        public void AddValueOption(string name, List<string> synonym)
        {
            OptionValues.Add(new CustomSlotTypeValueOption(name, synonym));
        }
        public void AddValueOption(string name, string[] synonym)
        {
            OptionValues.Add(new CustomSlotTypeValueOption(name, synonym));
        }

        public CustomSlotTypeInteractionModel GetInteractionModel(AlexaLocale locale = null)
        {
            locale ??= AlexaLocale.English_US;
            var valuesForLang = OptionValues.Select(ov => ov.GetInteractionModel(locale)).ToList();

            if (!valuesForLang.Any()) throw new ArgumentException("Custom slots require at least one option value");

            return new CustomSlotTypeInteractionModel(Name, valuesForLang.ToArray());
        }
    }
}