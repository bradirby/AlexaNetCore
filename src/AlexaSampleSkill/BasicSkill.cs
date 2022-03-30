using AlexaNetCore;
using AlexaSampleSkill.Intents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.Lambda.Core;
using AlexaNetCore.InteractionModel;

namespace AlexaSampleSkill
{
    public class BasicSkill: AlexaSkillBase
    {

        public BasicSkill() : base()
        {
            Init();
        }

        public BasicSkill(ILambdaLogger log) : base(log)
        {
            Init();
        }
        
        public BasicSkill(IAlexaNetCoreMessageLogger log) : base(log)
        {
            Init();
        }

        private void Init()
        {
            var measureSlotType = new CustomSlotTypeInteractionModel("measureType");
            measureSlotType.AddValueOption("inches","inch");
            measureSlotType.AddValueOption("feet",new[] {"foot", "feetsies"});
            measureSlotType.AddValueOption("yards");
            measureSlotType.AddValueOption("miles","mile");
            measureSlotType.AddValueOption("millimeters","millimeter");
            measureSlotType.AddValueOption("centimeters","centimeter");
            measureSlotType.AddValueOption("meters","meter");
            measureSlotType.AddValueOption("kilometers","kilometer");

            AddCustomSlotType(measureSlotType);


            SetSkillVersion("0.1");
            SetInvocationName("my basic skill");
            RegisterIntentHandler(new DefaultCancelIntentHandler());
            RegisterIntentHandler(new DefaultStopIntentHandler());
            RegisterIntentHandler(new BasicIntent());
        }
    }
}
