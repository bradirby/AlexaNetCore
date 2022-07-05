using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace AlexaNetCore.Model
{
    public class AlexaSlotUpdate
    {
        public string Name { get; set; }

        public IList<AlexaSlotUpdateOption> Values { get; set; } = new List<AlexaSlotUpdateOption>();

        public AlexaSlotUpdate()
        {

        }

        public AlexaSlotUpdate(string name, IList<AlexaSlotUpdateOption> values = null)
        {
            Name = name;
            if (values != null) Values = values;
        }

        public AlexaSlotUpdate AddSlotOption(AlexaSlotUpdateOption updateOption)
        {
            Values.Add(updateOption);
            return this;
        }

        public object GetJson(AlexaLocale locale)
        {
            dynamic obj = new ExpandoObject();
            obj.name = Name;
            obj.values = Values.Select(v => v.GetJson(locale)).ToArray();
            return obj;
        }
    }
}
