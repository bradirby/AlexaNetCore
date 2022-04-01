using System.Text;
using AlexaNetCore;

namespace SlotChecker.Intents
{
    internal class FourDigitNumberSlotCheckerIntent: AlexaIntentHandlerBase
    {

        public FourDigitNumberSlotCheckerIntent() : base("FourDigitNumberSlotCheckerIntent")
        {
            AddSlot( "fourDigitInputValue",AlexaBuiltInSlotTypes.FourDigitNumber, true);
            AddSampleInvocation("give me four digit number values for {fourDigitInputValue}");
        }

        public override void Process()
        {
            try
            {
                var slotVal = RequestEnv.GetAlexaSlot("fourDigitInputValue");
                if (slotVal.ContainsMultipleValues)
                {
                    var sb = new StringBuilder();
                    var connectorWord = "";
                    foreach (var alexaResponseSlotValue in slotVal.Values)
                    {
                        sb.Append(connectorWord + AddSpaceBetweenEachLetter(alexaResponseSlotValue.Value) );
                        connectorWord = ", and ";
                    }
                    ResponseEnv.SetOutputSpeechText($"got {slotVal.Values.Count} values, {sb.ToString()} ");
                }
                else
                {
                    ResponseEnv.SetOutputSpeechText($"got the single value {AddSpaceBetweenEachLetter(slotVal.Value)}");
                }

            }
            catch (Exception )
            {
                ResponseEnv.SetOutputSpeechText("I'm sorry, something went wrong.  Can you try again?");
            }

            ResponseEnv.ShouldEndSession = false;

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
