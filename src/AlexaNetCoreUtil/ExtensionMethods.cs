using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexaNetCore.Util
{
    public static class ExtensionMethods
    {
        public static string AddSpacesBetweenLetters(this string str)
        {
            var cArray = str.ToCharArray();
            return string.Join(" ", cArray);
        }
    }
}
