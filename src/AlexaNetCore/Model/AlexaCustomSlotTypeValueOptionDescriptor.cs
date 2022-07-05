using System.Collections.Generic;
using System.Linq;
using AlexaNetCore.InteractionModel;

namespace AlexaNetCore.Model
{
    public class AlexaCustomSlotTypeValueOptionDescriptor
    {
        public AlexaMultiLanguageText Value { get; set; }

        private List<AlexaMultiLanguageText> Synonyms { get; set; } = new List<AlexaMultiLanguageText>();

        public AlexaCustomSlotTypeValueOptionDescriptor AddSynonym(string val)
        {
            Synonyms.Add(new AlexaMultiLanguageText(val));
            return this;
        }


        public AlexaCustomSlotTypeValueOptionDescriptor(string val, string[] synonyms = null)
        {
            Value = new AlexaMultiLanguageText(val);
            if (synonyms != null) Synonyms = synonyms.Select(s => new AlexaMultiLanguageText(s)).ToList();
        }



        public AlexaCustomSlotTypeValueOptionDescriptor(AlexaMultiLanguageText val, AlexaMultiLanguageText[] synonyms = null)
        {
            Value = val;
            if (synonyms != null) Synonyms = synonyms.ToList();
        }

        public CustomSlotTypeValueOptionDescriptorInteractionModel GetInteractionModel(AlexaLocale locale = null)
        {
            locale ??= AlexaLocale.English_US;

            return new CustomSlotTypeValueOptionDescriptorInteractionModel(
                Value.GetText(locale), Synonyms.Select(s => s.GetText(locale)).ToArray());
        }

    }
}