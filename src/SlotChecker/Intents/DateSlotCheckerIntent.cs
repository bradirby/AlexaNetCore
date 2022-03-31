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
            AddSlot( dateSlotName,"AMAZON.DATE", true);
        }


        public override void Process()
        {
            try
            {
                var slotVal = RequestEnv.GetAlexaSlot(dateSlotName);
                if (slotVal.ContainsMultipleValues)
                {
                    var sb = new StringBuilder();
                    var connector = "";
                    foreach (var alexaResponseSlotValue in slotVal.Values)
                    {
                        sb.Append(connector + AddSpaceBetweenEachLetter(alexaResponseSlotValue.Value) );
                        connector = " and ";
                    }
                    ResponseEnv.SetOutputSpeechText($"got {slotVal.Values.Count} values, {sb.ToString()} ");
                }
                else
                {
                    ResponseEnv.SetOutputSpeechText($"got the single value {AddSpaceBetweenEachLetter(slotVal.Value)}");
                }

            }
            catch (Exception exc)
            {
                ResponseEnv.SetOutputSpeechText("I'm sorry, something went wrong.  Can you try again?");
            }

        }

        private string AddSpaceBetweenEachLetter(string str)
        {
            var arr = str.ToCharArray();
            var result = String.Join(" ", arr);
            result = result.Replace(" - ", " dash ");  //this reads better coming from the Echo
            return result;
        }


    }
}
