using AlexaSkillDotNet;
using System;
using System.Security.Cryptography;
using DistanceLibrary;
using ExactMeasureSkill.Intents;
using Amazon.Runtime;

namespace ExactMeasureSkill
{
    public class WholeNumberIntentHandler : ConversionRequestIntentHandlerBase
    {
        public WholeNumberIntentHandler(IAlexaSkillMessageLogger log) : base(IntentNames.WholeNumberIntent, log)
        {
        }


        protected override double ParseInputVal()
        {
            var val = GetSlotValue(SlotNames.InputValueSlotName, "");
            if (!string.IsNullOrEmpty(val)) return double.Parse(val);

            //look at the attributes to see if we still have a source type from last request
            var prevVal = GetSessionValue("OrigVal","");
            if (!string.IsNullOrEmpty(prevVal)) return double.Parse(prevVal);

            return 0;
        }


    }
}