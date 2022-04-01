using System.Text;
using AlexaNetCore;

namespace SlotChecker.Intents
{
    internal class ActorNameSlotCheckerIntent: AlexaIntentHandlerBase
    {

        public ActorNameSlotCheckerIntent() : base("ActorNameSlotCheckerIntent")
        {
            AddSlot( "actorNameValue",AlexaBuiltInSlotTypes.Lists.ActorName, true);
            AddSampleInvocation("give me actor name values for {actorNameValue}");
        }

        public override void Process()
        {
            try
            {
                var slotVal = RequestEnv.GetAlexaSlot("actorNameValue");
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
