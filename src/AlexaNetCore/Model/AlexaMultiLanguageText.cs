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
            _phrases = new Dictionary<string, string>();
        }

        [DebuggerStepThrough]
        public AlexaMultiLanguageText (string txt, AlexaLocale locale = null )
        {
            _phrases = new Dictionary<string, string>();
            AddText(txt, locale ?? AlexaLocale.English_US);
        }


        private readonly Dictionary<string, string> _phrases;

        public int NumLanguages => _phrases.Count;


        public string GetText(AlexaLocale targetLocale = null)
        {
            targetLocale ??= AlexaLocale.English_US;
            
            //look for the specific targetLocale
            if (_phrases.ContainsKey(targetLocale.LocaleString)) return _phrases[targetLocale.LocaleString];

            //look for the same language but diff country
            var entryKey = _phrases.Keys.FirstOrDefault(k => k.StartsWith(targetLocale.LanguageCode));
            if (!string.IsNullOrEmpty(entryKey)) return _phrases[entryKey];


            //find american english
            if (_phrases.ContainsKey(AlexaLocale.English_US.LocaleString)) return _phrases[AlexaLocale.English_US.LocaleString];

            //find any kind of english
            entryKey = _phrases.Keys.FirstOrDefault(k => k.StartsWith(AlexaLocale.English_US.LanguageCode));
            if (!string.IsNullOrEmpty(entryKey)) return _phrases[entryKey];

            //give up
            if (_phrases.Any()) return _phrases.First().Value;

            return "";
        }

        public bool Contains(string str)
        {
            return _phrases.ContainsValue(str);
        }


        public AlexaMultiLanguageText AddText(string txt, AlexaLocale locale )
        {
            locale ??= AlexaLocale.English_US;
            if (_phrases.ContainsKey(locale.LocaleString)) _phrases.Remove(locale.LocaleString);
            _phrases.Add(locale.LocaleString, txt);
            return this;
        }
    }
}