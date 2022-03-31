using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlexaNetCore;
using AlexaNetCore.InteractionModel;

namespace AlexaSampleSkill.Intents
{
    internal class BasicIntent: AlexaIntentHandlerBase
    {
        public BasicIntent() : base("BasicIntent")
        {
            AddSlot( new SlotDefinition("inputValue","AMAZON.NUMBER", true));
            AddSlot( new SlotDefinition("sourceType","measureType"));
            AddSlot( new SlotDefinition("destType","measureType"));


            var txt = new AlexaMultiLanguageText( $"Hello, {{inputValue}} is your input value", AlexaLocale.English_US)
                .AddText( $"Ciao, {{inputValue}} è il tuo valore di input", AlexaLocale.Italian)
                .AddText( $"Hola, {{inputValue}} es su valor de entrada", AlexaLocale.Spanish_US);
            AddSampleInvocation(txt);

            txt = new AlexaMultiLanguageText( $"Hello, {{inputValue}} there", AlexaLocale.English_US)
                .AddText( $"Ciao, {{inputValue}} a voi", AlexaLocale.Italian)
                .AddText( $"Hola, {{inputValue}} a ti", AlexaLocale.Spanish_US);
            AddSampleInvocation(txt);
            
            txt = new AlexaMultiLanguageText( $"Hello everyone", AlexaLocale.English_US)
                .AddText( $"Ciao, a tutti", AlexaLocale.Italian)
                .AddText( $"Hola, a todos", AlexaLocale.Spanish_US);
            AddSampleInvocation(txt);
        }


        public override void Process()
        {
            try
            {
                ResponseEnv.SetOutputSpeechText("Hello World");
            }
            catch (Exception exc)
            {
                ResponseEnv.SetOutputSpeechText("I'm sorry, something went wrong.  Can you try again?");
            }

        }


    }
}
