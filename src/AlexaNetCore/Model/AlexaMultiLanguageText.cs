using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AlexaNetCore.Model
{
    public class AlexaMultiLanguageText
    {

        [DebuggerStepThrough]
        public AlexaMultiLanguageText()
        {
            Phrases = new Dictionary<string, string>();
        }

        [DebuggerStepThrough]
        public AlexaMultiLanguageText (string txt, AlexaLocale locale = null )
        {
            Phrases = new Dictionary<string, string>();
            AddText(txt, locale ?? AlexaLocale.English_US);
        }


        private Dictionary<string, string> Phrases;

        public int NumLanguages => Phrases.Count;


        public string GetText(AlexaLocale targetLocale = null)
        {
            targetLocale ??= AlexaLocale.English_US;
            
            //look for the specific targetLocale
            if (Phrases.ContainsKey(targetLocale.LocaleString)) return Phrases[targetLocale.LocaleString];

            //look for the same language but diff country
            var entryKey = Phrases.Keys.FirstOrDefault(k => k.StartsWith(targetLocale.LanguageCode));
            if (!string.IsNullOrEmpty(entryKey)) return Phrases[entryKey];


            //find american english
            if (Phrases.ContainsKey(AlexaLocale.English_US.LocaleString)) return Phrases[AlexaLocale.English_US.LocaleString];

            //find any kind of english
            entryKey = Phrases.Keys.FirstOrDefault(k => k.StartsWith(AlexaLocale.English_US.LanguageCode));
            if (!string.IsNullOrEmpty(entryKey)) return Phrases[entryKey];

            //give up
            if (Phrases.Any()) return Phrases.First().Value;

            return "";
        }


        public AlexaMultiLanguageText AddText(string txt, AlexaLocale locale )
        {
            locale ??= AlexaLocale.English_US;
            if (Phrases.ContainsKey(locale.LocaleString)) Phrases.Remove(locale.LocaleString);
            Phrases.Add(locale.LocaleString, txt);
            return this;
        }
    }
}