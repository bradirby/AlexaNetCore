using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlexaNetCore;
using AlexaNetCore.InteractionModel;

namespace SlotChecker.Intents
{
    internal class DateSlotCheckerIntent: AlexaIntentHandlerBase
    {
        private string dateSlotName => "inputValue";

        public DateSlotCheckerIntent() : base("DateSlotCheckerIntent")
        {
            DefineSlots();
            DefineSampleInvocations();           
        }

        private void DefineSampleInvocations()
        {
            var txt = new AlexaMultiLanguageText( $"what date values do you get for {{{dateSlotName}}} as your input value", AlexaLocale.English_US)
                .AddText( $"quali valori di data ottieni per {{{dateSlotName}}} come valore di input", AlexaLocale.Italian)
                .AddText( $"que valores de fecha obtienes para {{{dateSlotName}}} como valor de entrada", AlexaLocale.Spanish_US);
            AddSampleInvocation(txt);

        }

        private void DefineSlots()
        {
            AddSlot( dateSlotName,"AMAZON.DATE");
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
