﻿using AlexaNetCore;
using AlexaSampleSkill.Intents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.Lambda.Core;
using AlexaNetCore.InteractionModel;
using static System.Net.Mime.MediaTypeNames;

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
            measureSlotType.AddValueOption("millimeters","millimeter");
            measureSlotType.AddValueOption("centimeters","centimeter");
            measureSlotType.AddValueOption("meters","meter");
            measureSlotType.AddValueOption("kilometers","kilometer");

            AddCustomSlotType(measureSlotType);


            SetSkillVersion("0.1");

                 
            measure = new AlexaMultiLanguageText( $"birthday echo", AlexaLocale.English_US)
                .AddText( $"tanti aguri", AlexaLocale.Italian)
                .AddText( $"cumpleano grita", AlexaLocale.Spanish_US);

            SetInvocationName(measure);
            RegisterIntentHandler(new DefaultCancelIntentHandler());
            RegisterIntentHandler(new DefaultStopIntentHandler());
            RegisterIntentHandler(new DefaultHelpIntentHandler());
            RegisterIntentHandler(new BasicIntent());
        }
    }
}
