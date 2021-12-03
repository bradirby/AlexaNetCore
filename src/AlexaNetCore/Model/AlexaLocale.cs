using System.IO.Enumeration;

namespace AlexaNetCore
{
    public class AlexaLocale
    {

        private AlexaLocale(string val)
        {
            LocaleString = val;
        }
        public string LocaleString { get; private set; }

        public string LanguageCode => LocaleString.Substring(0, 2);
        public string Country => LocaleString.Substring(3, 2);

        public override string ToString()
        {
            return LocaleString;
        }

        public static AlexaLocale Parse(string localStr)
        {
            if (localStr == Arabic.LocaleString) return Arabic;
            if (localStr == German.LocaleString) return German;

            if (localStr == English_US.LocaleString) return English_US;
            if (localStr == English_AU.LocaleString) return English_AU;
            if (localStr == English_UK.LocaleString) return English_UK;
            if (localStr == English_IN.LocaleString) return English_IN;
            if (localStr == English_CA.LocaleString) return English_CA;

            if (localStr == Spanish_ES.LocaleString) return Spanish_ES;
            if (localStr == Spanish_MX.LocaleString) return Spanish_MX;
            if (localStr == Spanish_US.LocaleString) return Spanish_US;

            if (localStr == French_FR.LocaleString) return French_FR;
            if (localStr == French_CA.LocaleString) return French_CA;

            if (localStr == Hindi.LocaleString) return Hindi;
            if (localStr == Italian.LocaleString) return Italian;
            if (localStr == Japanese.LocaleString) return Japanese;
            if (localStr == Portuguese.LocaleString) return Portuguese;

            return English_US;
        }


        public static AlexaLocale Arabic=> new AlexaLocale("ar-SA");
        public static AlexaLocale German=> new AlexaLocale("de-DE");

        public static AlexaLocale English_US =>  new AlexaLocale("en-US");
        public static AlexaLocale English_AU =>  new AlexaLocale("en-AU");
        public static AlexaLocale English_UK =>  new AlexaLocale("en-UK");
        public static AlexaLocale English_IN =>  new AlexaLocale("en-IN");
        public static AlexaLocale English_CA =>  new AlexaLocale("en-CA");

        public static AlexaLocale Spanish_ES =>  new AlexaLocale("es-ES");
        public static AlexaLocale Spanish_MX =>  new AlexaLocale("es-MX");
        public static AlexaLocale Spanish_US =>  new AlexaLocale("es-US");

        public static AlexaLocale French_FR =>  new AlexaLocale("fr-FR");
        public static AlexaLocale French_CA =>  new AlexaLocale("fr-CA");

        public static AlexaLocale Hindi =>  new AlexaLocale("hi-IN");
        public static AlexaLocale Italian =>  new AlexaLocale("it-IT");
        public static AlexaLocale Japanese=>  new AlexaLocale("ja-JP");
        public static AlexaLocale Portuguese =>  new AlexaLocale("pt-BR");

    }
}