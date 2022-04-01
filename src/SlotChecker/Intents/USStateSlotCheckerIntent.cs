using System.Text;
using AlexaNetCore;

namespace SlotChecker.Intents
{
    internal class USStateSlotCheckerIntent: AlexaIntentHandlerBase
    {

        public USStateSlotCheckerIntent() : base("USStateSlotCheckerIntent")
        {
            AddSlot( "stateNameValue",AlexaBuiltInSlotTypes.Lists.USState, true);
            AddSampleInvocation("give me State name values for {stateNameValue}");
        }

        public override void Process()
        {
            try
            {
                var slotVal = RequestEnv.GetAlexaSlot("stateNameValue");
                if (slotVal.ContainsMultipleValues)
                {
                    var sb = new StringBuilder();
                    var connectorWord = "";
                    foreach (var alexaResponseSlotValue in slotVal.Values)
                    {
                        sb.Append(connectorWord + alexaResponseSlotValue.Value);
                        connectorWord = ", and ";
                    }
                    ResponseEnv.SetOutputSpeechText($"got {slotVal.Values.Count} values, {sb.ToString()} ");
                }
                else
                {
                    ResponseEnv.SetOutputSpeechText($"got the single value {slotVal.Value}");
                }

            }
            catch (Exception )
            {
                ResponseEnv.SetOutputSpeechText("I'm sorry, something went wrong.  Can you try again?");
            }

            ResponseEnv.ShouldEndSession = false;

        }


    }
}
