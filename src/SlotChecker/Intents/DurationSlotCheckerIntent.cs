using System.Text;
using AlexaNetCore;

namespace SlotChecker.Intents
{
    internal class DurationSlotCheckerIntent: AlexaIntentHandlerBase
    {

        public DurationSlotCheckerIntent() : base("DurationSlotCheckerIntent")
        {
            AddSlot( "durationInputValue","AMAZON.DURATION", true);
            AddSampleInvocation("give me duration values for {durationInputValue}");
        }

        public override void Process()
        {
            try
            {
                var slotVal = RequestEnv.GetAlexaSlot("durationInputValue");
                if (slotVal.ContainsMultipleValues)
                {
                    var sb = new StringBuilder();
                    var connectorWord = "";
                    foreach (var alexaResponseSlotValue in slotVal.Values)
                    {
                        sb.Append(connectorWord + AddSpaceBetweenEachLetter(alexaResponseSlotValue.Value) );
                        connectorWord = " and ";
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
