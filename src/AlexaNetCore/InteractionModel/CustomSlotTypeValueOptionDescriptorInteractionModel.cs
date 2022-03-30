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
        public string[] SynonymStrings => !Synonyms.Any() ? null : Synonyms.ToArray();


        private List<string> Synonyms { get; set; } = new List<string>();

        public void AddSynonym(string val)
        {
            Synonyms.Add(val);
        }

        public CustomSlotTypeValueOptionDescriptorInteractionModel(string val)
        {
            Value = val;
        }
        public CustomSlotTypeValueOptionDescriptorInteractionModel(string val, string synonym)
        {
            Value = val;
            Synonyms.Add( synonym);
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