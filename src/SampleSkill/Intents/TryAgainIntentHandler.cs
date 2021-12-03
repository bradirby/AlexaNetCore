using AlexaNetCore;
using ExactMeasureSkill.Intents;

namespace ExactMeasureSkill
{
    public class TryAgainIntentHandler : ConversionRequestIntentHandlerBase
    {
        public TryAgainIntentHandler(IAlexaSkillMessageLogger log) : base(IntentNames.TryAgainIntent, log)
        {
        }


        protected override double ParseInputVal()
        {
            //in a retry the value must come from the previous request
            var prevVal = GetSessionValue("OrigVal","");
            if (!string.IsNullOrEmpty(prevVal)) return double.Parse(prevVal);
            return 0;
        }


    }
}