using AlexaNetCore;
using System;
using System.Security.Cryptography;
using DistanceLibrary;
using ExactMeasureSkill.Intents;
using Amazon.Runtime.Internal.Util;

namespace ExactMeasureSkill
{
    public class DecimalRequestIntentHandler: ConversionRequestIntentHandlerBase
    {
        public DecimalRequestIntentHandler(IAlexaSkillMessageLogger log) : base(IntentNames.WithDecimalIntent, log)
        {
        }


        protected override double ParseInputVal()
        {
            string inputValueStr = GetSlotValue(SlotNames.InputValueSlotName, "");
            inputValueStr += "." + GetSlotValue(SlotNames.DecimalValueSlotName, "");

            if (inputValueStr == ".")
            {
                //look at the attributes to see if we still have a source type from last request
                inputValueStr = GetSessionValue("OrigVal","");
            }

            if (!double.TryParse(inputValueStr, out var inputVal))
            {
                //handle error
            }
            return inputVal;
        }

       

    }
}