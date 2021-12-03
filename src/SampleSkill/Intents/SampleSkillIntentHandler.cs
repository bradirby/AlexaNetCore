﻿using AlexaNetCore;
using DistanceLibrary;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace AlexaNetCoreSampleSkill.Intents
{
    public class SampleSkillIntentHandler : AlexaIntentHandlerBase
    {

        public SampleSkillIntentHandler(IAlexaNetCoreMessageLogger log) : base(IntentNames.SampleIntent, log)
        {
        }

        public override void Process()
        {
            try
            {
                ResponseEnv.Response.OutputSpeech.SetText("Hello World");
            }
            catch (Exception exc)
            {
                MsgLogger.Error(exc, $"Exception: {exc.Message}");
                ResponseEnv.Response.OutputSpeech.SetText($"I'm sorry, something went wrong.  Can you try again?");
            }

        }


    }
}
