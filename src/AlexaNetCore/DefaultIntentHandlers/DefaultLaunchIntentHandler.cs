﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlexaSkillDotNet;

namespace AlexaSkillDotNet
{
    public class DefaultLaunchIntentHandler : AlexaIntentHandlerBase
    {
        public DefaultLaunchIntentHandler(IAlexaSkillMessageLogger log) : base(AlexaBuiltInIntents.LaunchRequest, log)
        {
            LaunchText = new AlexaMultiLanguageText("Hello, what can I do for you today?");
        }

        public DefaultLaunchIntentHandler(string defaultTxt, IAlexaSkillMessageLogger log) : base(AlexaBuiltInIntents.LaunchRequest, log)
        {
            LaunchText = new AlexaMultiLanguageText(defaultTxt);
        }

        public DefaultLaunchIntentHandler(AlexaMultiLanguageText defaultTxt, IAlexaSkillMessageLogger log) : base(AlexaBuiltInIntents.LaunchRequest, log)
        {
            LaunchText = defaultTxt;
        }

        public AlexaMultiLanguageText LaunchText { get; private set; }


        public override void Process()
        {
            ResponseEnv.Response.OutputSpeech.SetText(LaunchText);

            ResponseEnv.Response.ShouldEndSession = false;
            ResponseEnv.IntentHandlerName = this.GetType().Name;

        }
    }
}
