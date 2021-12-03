using System;

namespace AlexaNetCore
{
    public static class DateTimeExtensionMethods
    {

        public static string ToEnglishWords(this DateTime dateRequested)
        {
            var dateStr = dateRequested.ToString("D");
            return dateStr.Substring(0, dateStr.Length - 6);  //remove the year
        }

        public static string ToItalianWords(this DateTime dateRequested)
        {
            var englishStr = dateRequested.ToEnglishWords().ToLower();
            englishStr = englishStr.Replace("january", "gennaio");
            englishStr = englishStr.Replace("february", "febbraio");
            englishStr = englishStr.Replace("march", "marzo");
            englishStr = englishStr.Replace("april", "aprile");
            englishStr = englishStr.Replace("may", "Maggio");
            englishStr = englishStr.Replace("june", "giugno");
            englishStr = englishStr.Replace("july", "luglio");
            englishStr = englishStr.Replace("august", "agosto");
            englishStr = englishStr.Replace("september", "settembre");
            englishStr = englishStr.Replace("october", "ottobre");
            englishStr = englishStr.Replace("november", "novembre");
            englishStr = englishStr.Replace("december", "dicembre");

            englishStr = englishStr.Replace("monday", "lunedì");
            englishStr = englishStr.Replace("tuesday", "Martedì");
            englishStr = englishStr.Replace("wednesday", "mercoledì");
            englishStr = englishStr.Replace("thursday", "giovedi");
            englishStr = englishStr.Replace("friday", "venerdì");
            englishStr = englishStr.Replace("saturday", "sabato");
            englishStr = englishStr.Replace("sunday", "domenica");


            return englishStr;
        }
        public static string ToSpanishWords(this DateTime dateRequested)
        {
            var englishStr = dateRequested.ToEnglishWords().ToLower();
            englishStr = englishStr.Replace("january", "enery");
            englishStr = englishStr.Replace("february", "fevrero");
            englishStr = englishStr.Replace("march", "marzo");
            englishStr = englishStr.Replace("april", "abril");
            englishStr = englishStr.Replace("may", "mayo");
            englishStr = englishStr.Replace("june", "junio");
            englishStr = englishStr.Replace("july", "julio");
            englishStr = englishStr.Replace("august", "agosto");
            englishStr = englishStr.Replace("september", "septiembre");
            englishStr = englishStr.Replace("october", "octubre");
            englishStr = englishStr.Replace("november", "noviembre");
            englishStr = englishStr.Replace("december", "diciembre");

            englishStr = englishStr.Replace("monday", "lunes");
            englishStr = englishStr.Replace("tuesday", "martes");
            englishStr = englishStr.Replace("wednesday", "miercoles");
            englishStr = englishStr.Replace("thursday", "jueves");
            englishStr = englishStr.Replace("friday", "viernes");
            englishStr = englishStr.Replace("saturday", "sabado");
            englishStr = englishStr.Replace("sunday", "domingo");

            return englishStr;
        }

    }
}
