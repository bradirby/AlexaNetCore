using System;
using System.Collections.Generic;
using System.Dynamic;

namespace AlexaNetCore
{
    public static class ExtensionMethods
    {

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


        public static string ToWords(this int value)
        {
            if (value == 0)
                return "Zero";

            if (value < 0)
                return "minus " + ToWords(Math.Abs(value));

            string words = "";

            if ((value / 1000000) > 0)
            {
                words += ToWords(value / 1000000) + " Million ";
                value %= 1000000;
            }

            if ((value / 1000) > 0)
            {
                words += ToWords(value / 1000) + " Thousand ";
                value %= 1000;
            }

            if ((value / 100) > 0)
            {
                words += ToWords(value / 100) + " Hundred ";
                value %= 100;
            }

            if (value > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
                var tensMap = new[] { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

                if (value < 20)
                    words += unitsMap[value];
                else
                {
                    words += tensMap[value / 10];
                    if ((value % 10) > 0)
                        words += "-" + unitsMap[value % 10];
                }
            }

            return words;
        }


    }
}
