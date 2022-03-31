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
}