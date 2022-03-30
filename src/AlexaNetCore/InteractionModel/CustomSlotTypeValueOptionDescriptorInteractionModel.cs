using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace AlexaNetCore.InteractionModel
{
    public class CustomSlotTypeValueOptionDescriptorInteractionModel
    {
        [JsonPropertyName("value")]
        public string Value { get; set; }


        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("synonyms")]
        public string[] SynonymStrings { get; set; }


        internal CustomSlotTypeValueOptionDescriptorInteractionModel(string value, string[] synStrings)
        {
            Value = value;
            if (synStrings.Length == 0) SynonymStrings = null;
            else SynonymStrings = synStrings;
        }
    }


    public class CustomSlotTypeValueOptionDescriptor
    {
        public AlexaMultiLanguageText Value { get; set; }


        private List<AlexaMultiLanguageText> Synonyms { get; set; } = new List<AlexaMultiLanguageText>();

        public void AddSynonym(string val)
        {
            Synonyms.Add(new AlexaMultiLanguageText(val));
        }

        public CustomSlotTypeValueOptionDescriptor(string val)
        {
            Value = new AlexaMultiLanguageText(val);
        }

        public CustomSlotTypeValueOptionDescriptor(string val, string synonym)
        {
            Value = new AlexaMultiLanguageText(val);
            Synonyms.Add( new AlexaMultiLanguageText(synonym));
        }

        public CustomSlotTypeValueOptionDescriptor(AlexaMultiLanguageText val, string synonym)
        {
            Value = val;
            Synonyms.Add( new AlexaMultiLanguageText(synonym));
        }

        public CustomSlotTypeValueOptionDescriptor(AlexaMultiLanguageText val, AlexaMultiLanguageText synonym)
        {
            Value = val;
            Synonyms.Add( synonym);
        }


        public CustomSlotTypeValueOptionDescriptor(string val, string[] synonyms)
        {
            Value = new AlexaMultiLanguageText(val);
            Synonyms = synonyms.Select(s => new AlexaMultiLanguageText(s)).ToList();
        }

        public CustomSlotTypeValueOptionDescriptor(AlexaMultiLanguageText val, string[] synonyms)
        {
            Value = val;
            Synonyms = synonyms.Select(s => new AlexaMultiLanguageText(s)).ToList();
        }

        public CustomSlotTypeValueOptionDescriptor(AlexaMultiLanguageText val, AlexaMultiLanguageText[] synonyms)
        {
            Value = val;
            Synonyms = synonyms.ToList();
        }

        public CustomSlotTypeValueOptionDescriptorInteractionModel GetInteractionModel(AlexaLocale locale = null)
        {
            locale ??= AlexaLocale.English_US;

            return new CustomSlotTypeValueOptionDescriptorInteractionModel(
                Value.GetText(locale), Synonyms.Select(s => s.GetText(locale)).ToArray());
        }

    }
}