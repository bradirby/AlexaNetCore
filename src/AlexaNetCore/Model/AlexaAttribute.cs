using System.Dynamic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AlexaSkillDotNet
{
    public class AlexaAttribute
    {

        [JsonPropertyName("name")]
        public string Name{get;set;}

        [JsonPropertyName("value")]
        public bool Value{get;set;}


        public object GetJson()
        {
            dynamic obj = new ExpandoObject();
            obj.name = Name;
            obj.value = Value;
            return obj;

        }
    }
}