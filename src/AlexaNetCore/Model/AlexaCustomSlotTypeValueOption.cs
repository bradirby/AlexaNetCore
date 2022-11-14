using AlexaNetCore.InteractionModel;

namespace AlexaNetCore.Model
{
    public class AlexaCustomSlotTypeValueOption
    {
        public AlexaCustomSlotTypeValueOptionDescriptor SlotTypeValueOptionDescriptor { get; set; }

        public string Id { get; set; }

        public AlexaCustomSlotTypeValueOption(AlexaCustomSlotTypeValueOptionDescriptor model)
        {
            SlotTypeValueOptionDescriptor = model;
        }


        public AlexaCustomSlotTypeValueOption(string id, string val, string[] synonyms = null)
        {
            Id = id;
            SlotTypeValueOptionDescriptor = new AlexaCustomSlotTypeValueOptionDescriptor(val, synonyms);
        }

        public AlexaCustomSlotTypeValueOption(string id, AlexaMultiLanguageText val, AlexaMultiLanguageText[] synonyms = null)
        {
            Id = id;
            SlotTypeValueOptionDescriptor = new AlexaCustomSlotTypeValueOptionDescriptor(val, synonyms);
        }


        public AlexaCustomSlotTypeValueOption AddSynonym(string val)
        {
            SlotTypeValueOptionDescriptor.AddSynonym(val);
            return this;
        }

        public CustomSlotTypeValueOptionInteractionModel GetInteractionModel(AlexaLocale locale = null)
        {
            locale ??= AlexaLocale.English_US;

            return new CustomSlotTypeValueOptionInteractionModel(Id, SlotTypeValueOptionDescriptor.GetInteractionModel(locale));
        }
    }
}