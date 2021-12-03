using System;
using System.Collections.Generic;
using System.Linq;

namespace AlexaSkillDotNet
{
    public class AlexaMultiLanguageText
    {
        public AlexaLocale DefaultLocale { get; private set; }

        public AlexaMultiLanguageText (string txt, AlexaLocale locale = null, AlexaLocale defaultLocale = null)
        {
            DefaultLocale = defaultLocale ?? AlexaLocale.English_US;
            AddText(txt, locale);
        }

        public AlexaMultiLanguageText (AlexaLocale defaultLocale)
        {
            DefaultLocale = defaultLocale ?? AlexaLocale.English_US;
        }

        public void SetDefaultLocale(AlexaLocale locale)
        {
            DefaultLocale = locale ?? throw new ArgumentNullException("Cannot have null Default Locale in MultiLanguage text");
        }

        private Dictionary<string, string> Phrases = new Dictionary<string, string>();

        public bool LanguageExists(AlexaLocale locale)
        {
            return Phrases.ContainsKey(locale.LocaleString);
        }

        public string GetText(AlexaLocale targetLocale = null, IAlexaTranslationService translator = null )
        {
            targetLocale ??= DefaultLocale;

            //look for the specific targetLocale
            if (Phrases.ContainsKey(targetLocale.LocaleString)) return Phrases[targetLocale.LocaleString];

            //look for the same language but diff country
            var entryKey = Phrases.Keys.FirstOrDefault(k => k.StartsWith(targetLocale.LanguageCode));
            if (!string.IsNullOrEmpty(entryKey)) return Phrases[entryKey];

            //try the translator
            if (translator != null)
            {
                //find the text for the language the translator is prepared to handle
                var entryKeyForTranslator = Phrases.Keys.FirstOrDefault(k => k.StartsWith(translator.SourceLanguageCode));
                if (entryKeyForTranslator != null)
                {
                    var srcStr = Phrases[entryKeyForTranslator];
                    return translator.TranslateAsync(srcStr, targetLocale.LanguageCode).GetAwaiter().GetResult();
                }
            }

            //find american english
            if (Phrases.ContainsKey(AlexaLocale.English_US.LocaleString)) return Phrases[AlexaLocale.English_US.LocaleString];

            //find any kind of english
            entryKey = Phrases.Keys.FirstOrDefault(k => k.StartsWith(AlexaLocale.English_US.LanguageCode));
            if (!string.IsNullOrEmpty(entryKey)) return Phrases[entryKey];

            //give up
            if (Phrases.Any()) return Phrases.First().Value;

            return "";
        }


        public AlexaMultiLanguageText AddText(string txt, AlexaLocale locale = null)
        {
            locale ??= DefaultLocale;
            if (Phrases.ContainsKey(locale.LocaleString)) Phrases.Remove(locale.LocaleString);
            Phrases.Add(locale.LocaleString, txt);
            return this;
        }
    }
}