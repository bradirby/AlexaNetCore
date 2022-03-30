using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlexaNetCore;
using AlexaNetCore.InteractionModel;

namespace AlexaSampleSkill.Intents
{
    internal class BasicIntent: AlexaIntentHandlerBase
    {
        public BasicIntent() : base("BasicIntent")
        {
            AddSlotOption( new SlotInteractionModel("inputValue","AMAZON.NUMBER"));
            AddSlotOption( new SlotInteractionModel("sourceType","measureType"));
            AddSlotOption( new SlotInteractionModel("destType","measureType"));

            AddSampleInvocation($"Hello {{inputValue}} ");
            AddSampleInvocation($"hello {{sourceType}} there");
            AddSampleInvocation("Hi Everybody");
        }

        public override void Process()
        {
            try
            {
                ResponseEnv.SetOutputSpeechText("Hello World");
            }
            catch (Exception exc)
            {
                ResponseEnv.SetOutputSpeechText("I'm sorry, something went wrong.  Can you try again?");
            }

        }


    }
}
