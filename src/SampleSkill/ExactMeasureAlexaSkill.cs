using System;
using AlexaNetCore;

namespace ExactMeasureSkill
{
    public class ExactMeasureAlexaSkill : AlexaSkillBase
    {

        public ExactMeasureAlexaSkill()
        {
            SetSkillVersion("0.9");
            SetDefaultResponseLocale(AlexaLocale.English_US);

            var helloStr = "Hello, what would you like to convert?";
            #if DEBUG
            helloStr = "Hello, what would you like this Debug version 0.9 to convert?";
            #endif

            var txt = new AlexaMultiLanguageText( helloStr, AlexaLocale.English_US)
                    .AddText( "Ciao, cosa vorresti convertire?", AlexaLocale.Italian)
                    .AddText( "Hola, ¿qué te gustaría convertir?", AlexaLocale.Spanish_US);
            RegisterIntentHandler(new DefaultLaunchIntentHandler(txt, MsgLogger));
            RegisterIntentHandler(new DefaultStartOverIntentHandler(txt, MsgLogger));

            txt = new AlexaMultiLanguageText( "Goodbye", AlexaLocale.English_US)
                .AddText( "Ciao", AlexaLocale.Italian)
                .AddText( "Adios", AlexaLocale.Spanish_US);
            RegisterIntentHandler(new DefaultStopIntentHandler(txt, MsgLogger));
            RegisterIntentHandler(new DefaultCancelIntentHandler(txt, MsgLogger));
            RegisterIntentHandler(new DefaultSessionEndRequest(txt, MsgLogger));

            
            RegisterIntentHandler(new DefaultHelpIntentHandler(
                new AlexaMultiLanguageText( "I can help you convert length measurements from ImperialAnswer to MetricAnswer and back.  Just tell me the measure you want to convert, the original units like feet, inches , meters, or millimeters, and the units you want to convert into. I will tell you the conversion up to 4 decimal places.", AlexaLocale.English_US)
                    .AddText( "Posso aiutarti a convertire le misure di lunghezza da Imperiale a Metrico e viceversa. Dimmi solo la misura che vuoi convertire, le unità originali come piedi, pollici, metri o millimetri e le unità in cui vuoi convertire. Ti dirò la conversione fino a 4 cifre decimali.", AlexaLocale.Italian)
                    .AddText("Puedo ayudarlo a convertir medidas de longitud de imperial a métrica y viceversa. Simplemente dígame la medida que desea convertir, las unidades originales como pies, pulgadas, metros o milímetros, y las unidades a las que desea convertir. Te diré la conversión hasta 4 decimales." , AlexaLocale.Spanish_US)
                , MsgLogger));


            RegisterDefaultIntentHandlers(new AlexaMultiLanguageText( "I'm sorry, I don't know how to do that", AlexaLocale.English_US)
                .AddText( "Mi dispiace, non so come farlo", AlexaLocale.Italian)
                .AddText( "Lo siento, no se como hacer eso",AlexaLocale.Spanish_US)
                );
            
            RegisterIntentHandler(new DecimalRequestIntentHandler(MsgLogger));
            RegisterIntentHandler(new WholeNumberIntentHandler(MsgLogger));
            RegisterIntentHandler(new TryAgainIntentHandler(MsgLogger));
        }

        
    }
}
