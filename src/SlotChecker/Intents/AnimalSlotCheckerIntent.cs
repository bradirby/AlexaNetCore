using System.Text;
using AlexaNetCore;

namespace SlotChecker.Intents
{
    internal class AnimalSlotCheckerIntent: AlexaIntentHandlerBase
    {

        public AnimalSlotCheckerIntent() : base("AnimalSlotCheckerIntent")
        {
            AddSlot( "animalNameValue",AlexaBuiltInSlotTypes.Lists.Animal, true);
            AddSampleInvocation("give me animal name values for {animalNameValue}");
        }

        public override void Process()
        {
            try
            {
                var slotVal = RequestEnv.GetAlexaSlot("animalNameValue");
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
