using System;
using System.Collections.Generic;
using System.Linq;

namespace AlexaNetCore.InteractionModel
{
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

        public CustomSlotType AddValueOption(CustomSlotTypeValueOption opt)
        {
            OptionValues.Add(opt);
            return this;
        }

        public CustomSlotType AddValueOption(string name)
        {
            OptionValues.Add(new CustomSlotTypeValueOption(name));
            return this;
        }

        public CustomSlotType AddValueOption(string name, string synonym)
        {
            OptionValues.Add(new CustomSlotTypeValueOption(name, synonym));
            return this;

        }

        public CustomSlotType AddValueOption(AlexaMultiLanguageText name, string synonym)
        {
            OptionValues.Add(new CustomSlotTypeValueOption(name, synonym));
            return this;
        }

        public CustomSlotType AddValueOption(AlexaMultiLanguageText name, AlexaMultiLanguageText synonym)
        {
            OptionValues.Add(new CustomSlotTypeValueOption(name, synonym));
            return this;
        }

        public CustomSlotType AddValueOption(string name, string[] synonym)
        {
            OptionValues.Add(new CustomSlotTypeValueOption(name, synonym));
            return this;
        }

        public CustomSlotType AddValueOption(AlexaMultiLanguageText name, string[] synonym)
        {
            OptionValues.Add(new CustomSlotTypeValueOption(name, synonym));
            return this;
        }

        public CustomSlotType AddValueOption(AlexaMultiLanguageText name, AlexaMultiLanguageText[] synonym)
        {
            OptionValues.Add(new CustomSlotTypeValueOption(name, synonym));
            return this;
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