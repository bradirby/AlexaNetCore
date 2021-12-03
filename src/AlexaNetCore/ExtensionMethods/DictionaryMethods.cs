using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace AlexaNetCore
{
    public static class DictionaryMethods
    {
        public static ExpandoObject ToExpando(this Dictionary<string, string> dictionary)
        {
            var eo = new ExpandoObject();
            var eoColl = (ICollection<KeyValuePair<string, object>>)eo;

            foreach (var kvp in dictionary)
            {
                var newItem = new KeyValuePair<string, object>(kvp.Key, kvp.Value);
                eoColl.Add(newItem);
            }

            dynamic eoDynamic = eo;

            return eoDynamic;
        }

        public static ExpandoObject ToExpando(this Dictionary<string, object> dictionary)
        {
            var eo = new ExpandoObject();
            var eoColl = (ICollection<KeyValuePair<string, object>>)eo;

            foreach (var kvp in dictionary)
            {
                var newItem = new KeyValuePair<string, object>(kvp.Key, kvp.Value);
                eoColl.Add(newItem);
            }

            dynamic eoDynamic = eo;

            return eoDynamic;
        }

        
        public static string ToJson(this Dictionary<string, string> dictionary)
        {
            var kvs = dictionary.Select(kvp => string.Format("\"{0}\":\"{1}\"", kvp.Key, string.Concat(",", kvp.Value)));
            return string.Concat("{", string.Join(",", kvs), "}");
        }

        public static Dictionary<string, string> FromJson(this string json)
        {
            string[] keyValueArray =
                json.Replace("{", string.Empty).Replace("}", string.Empty).Replace("\"", string.Empty).Split(',');
            return keyValueArray.ToDictionary(item => item.Split(':')[0], item => item.Split(':')[1]);
        }



    }
}
