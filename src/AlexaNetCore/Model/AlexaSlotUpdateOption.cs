using System.Collections.Generic;
using System.Dynamic;

namespace AlexaNetCore.Model
{
    public class AlexaSlotUpdateOption
    {
        public string ID { get; set; }
        public AlexaDynamicEntitySlotOptionValue Name { get; set; }

        public AlexaSlotUpdateOption()
        {

        }

        public AlexaSlotUpdateOption(string id, string name, List<string> synonyms = null)
        {
            ID = id;
            Name = new AlexaDynamicEntitySlotOptionValue(name, synonyms);
        }

        public AlexaSlotUpdateOption(string name, List<string> synonyms = null)
        {
            Name = new AlexaDynamicEntitySlotOptionValue(name, synonyms);
        }

        public AlexaSlotUpdateOption AddSynonym(string syn)
        {
            Name.AddSynonym(syn);
            return this;
        }
        public object GetJson(AlexaLocale locale)
        {
            dynamic obj = new ExpandoObject();
            if (!string.IsNullOrEmpty(ID)) obj.id = ID;
            obj.name = Name.GetJson(locale);
            return obj;
        }

    }
}