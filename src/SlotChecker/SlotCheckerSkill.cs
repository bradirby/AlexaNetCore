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
            var measureSlotType = new CustomSlotType("measureType");


            var measure = new AlexaMultiLanguageText( $"inches", AlexaLocale.English_US)
                .AddText( $"pollici", AlexaLocale.Italian)
                .AddText( $"pulgadas", AlexaLocale.Spanish_US);
            var synonyms= new AlexaMultiLanguageText( $"inch", AlexaLocale.English_US)
                .AddText( $"pollice", AlexaLocale.Italian)
                .AddText( $"pulgada", AlexaLocale.Spanish_US);
            measureSlotType.AddValueOption(measure,synonyms);

            var synLst = new List<AlexaMultiLanguageText>();
            measure = new AlexaMultiLanguageText( $"feet", AlexaLocale.English_US)
                .AddText( $"piedi", AlexaLocale.Italian)
                .AddText( $"pies", AlexaLocale.Spanish_US);
            synLst.Add( new AlexaMultiLanguageText( $"foot", AlexaLocale.English_US)
                .AddText( $"piede", AlexaLocale.Italian)
                .AddText( $"pie", AlexaLocale.Spanish_US));
            synLst.Add(new AlexaMultiLanguageText( $"footsies", AlexaLocale.English_US)
                .AddText( $"piedies", AlexaLocale.Italian)
                .AddText( $"piesies", AlexaLocale.Spanish_US));
            measureSlotType.AddValueOption(measure,synLst.ToArray());
            
            measureSlotType.AddValueOption("yards");
            measureSlotType.AddValueOption("miles","mile");

            AddCustomSlotType(measureSlotType);
        }

        private void Init()
        {
            DefineCustomSlots();
            SetSkillVersion("0.1");

                 
            var invocationName = new AlexaMultiLanguageText( $"slot value checker", AlexaLocale.English_US)
                .AddText( $"tanti aguri", AlexaLocale.Italian)
                .AddText( $"cumpleano grita", AlexaLocale.Spanish_US);

            SetInvocationName(invocationName);
            RegisterIntentHandler(new DefaultCancelIntentHandler("slot checker cancel intent"));
            RegisterIntentHandler(new DefaultStopIntentHandler("slot checker stop"));
            RegisterIntentHandler(new DefaultHelpIntentHandler("you got slot checker help"));
            RegisterIntentHandler(new DefaultLaunchIntentHandler("welcome to slot checker"));

            RegisterIntentHandler(new DateSlotCheckerIntent());
        }
    }
}
