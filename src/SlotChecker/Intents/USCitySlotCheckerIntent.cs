using System.Text;
using AlexaNetCore;

namespace SlotChecker.Intents
{
    internal class USCitySlotCheckerIntent: AlexaIntentHandlerBase
    {

        public USCitySlotCheckerIntent() : base("USCitySlotCheckerIntent")
        {
            AddSlot( "usCityNameValue",AlexaBuiltInSlotTypes.Lists.USCity, true);
            AddSampleInvocation("give me City name values for {usCityNameValue}");
        }

        public override void Process()
        {
            try
            {
                var slotVal = RequestEnv.GetAlexaSlot("usCityNameValue");
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
