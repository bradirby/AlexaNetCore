using System.Collections.Generic;
using System.Dynamic;

namespace AlexaNetCore.Model
{
    public class AlexaDynamicEntitySlotOptionValue
    {

        public string Value { get; set; }

        public List<string> Synonyms { get; set; }

        public AlexaDynamicEntitySlotOptionValue()
        {

        }

        public AlexaDynamicEntitySlotOptionValue(string value, List<string> synonyms)
        {
            Value = value;
            Synonyms = synonyms;
        }

        public AlexaDynamicEntitySlotOptionValue AddSynonym(string syn)
        {
            Synonyms ??= new List<string>();
            Synonyms.Add(syn);
            return this;
        }

        public object GetJson(AlexaLocale locale)
        {
            dynamic obj = new ExpandoObject();
            obj.value = Value;
            if (Synonyms != null) obj.synonyms = Synonyms.ToArray();
            return obj;
        }

    }
}