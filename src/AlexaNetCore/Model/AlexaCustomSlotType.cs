using System;
using System.Collections.Generic;
using System.Linq;
using AlexaNetCore.InteractionModel;

namespace AlexaNetCore.Model
{

    /// <summary>
    /// Custom slot types are defined at the Skill level, then referenced at the intent level
    /// </summary>
    public class AlexaCustomSlotType
    {

        /// <summary>
        /// the name of the custom slot type.  this is always the same regardless of language
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Options allowed for this slot
        /// </summary>
        private List<AlexaCustomSlotTypeValueOption> OptionValues { get; set; } = new List<AlexaCustomSlotTypeValueOption>();

        public AlexaCustomSlotType(string slotTypeName)
        {
            Name = slotTypeName;
        }

        public AlexaCustomSlotType(string slotTypeName, List<AlexaCustomSlotTypeValueOption> optionModels)
        {
            Name = slotTypeName;
            OptionValues = optionModels;
        }

        public AlexaCustomSlotType(string slotTypeName, AlexaCustomSlotTypeValueOption[] optionModels)
        {
            Name = slotTypeName;
            OptionValues = optionModels.ToList();
        }

        public AlexaCustomSlotType AddValueOption(AlexaCustomSlotTypeValueOption opt)
        {
            OptionValues.Add(opt);
            return this;
        }

        public AlexaCustomSlotType AddValueOption(string id, string name, string[] synonyms = null)
        {
            OptionValues.Add(new AlexaCustomSlotTypeValueOption(id, name, synonyms));
            return this;
        }

        public AlexaCustomSlotType AddValueOption(string name, string[] synonyms = null)
        {
            OptionValues.Add(new AlexaCustomSlotTypeValueOption("", name, synonyms));
            return this;
        }


        public AlexaCustomSlotType AddValueOption(AlexaMultiLanguageText name, AlexaMultiLanguageText[] synonyms = null)
        {
            OptionValues.Add(new AlexaCustomSlotTypeValueOption("", name, synonyms));
            return this;
        }

        public AlexaCustomSlotType AddValueOption(string id, AlexaMultiLanguageText name, AlexaMultiLanguageText[] synonyms = null)
        {
            OptionValues.Add(new AlexaCustomSlotTypeValueOption(id, name, synonyms));
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