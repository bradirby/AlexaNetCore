using AlexaNetCore;
using Amazon.Lambda.Core;
using AlexaNetCore.InteractionModel;
using SlotChecker.Intents;

namespace SlotChecker
{
    public class SlotCheckerSkill: AlexaSkillBase
    {

        public SlotCheckerSkill() : base()
        {
            Init();
        }

        public SlotCheckerSkill(ILambdaLogger log) : base(log)
        {
            Init();
        }
        
        public SlotCheckerSkill(IAlexaNetCoreMessageLogger log) : base(log)
        {
            Init();
        }

        private void DefineCustomSlots()
        {

            AddCustomSlotType(new CustomSlotType("measureType")
                .AddValueOption("Inches", "inch")
                .AddValueOption("feet","foot")
                .AddValueOption("yards", "yard")
                .AddValueOption("miles","mile"));
        }

        private void Init()
        {
            DefineCustomSlots();
            SetSkillVersion("0.1");
            SetInvocationName("slot value checker");

            RegisterIntentHandler(new DefaultCancelIntentHandler("OK, Canceling"));
            RegisterIntentHandler(new DefaultStopIntentHandler("OK, Stopping"));
            RegisterIntentHandler(new DefaultHelpIntentHandler("you got slot checker help"));
            RegisterIntentHandler(new DefaultLaunchIntentHandler("Welcome to slot value checker"));
            RegisterIntentHandler(new DefaultStartOverIntentHandler("From the top; Welcome to slot value checker"));
            RegisterIntentHandler(new DefaultNavigateHomeIntentHandler());
            RegisterIntentHandler(new DefaultFallbackIntentHandler("I didn't quite get that.  Can you try again?"));

            RegisterIntentHandler(new DateSlotCheckerIntent());
            RegisterIntentHandler(new DurationSlotCheckerIntent());
            RegisterIntentHandler(new FourDigitNumberSlotCheckerIntent());
            RegisterIntentHandler(new NumberSlotCheckerIntent());
            RegisterIntentHandler(new OrdinalSlotCheckerIntent());
            RegisterIntentHandler(new PhoneNumberSlotCheckerIntent());
            RegisterIntentHandler(new TimeSlotCheckerIntent());

            RegisterIntentHandler(new ActorNameSlotCheckerIntent());
            RegisterIntentHandler(new AnimalSlotCheckerIntent());
            RegisterIntentHandler(new USCitySlotCheckerIntent());
            RegisterIntentHandler(new USStateSlotCheckerIntent());
        }
    }
}
