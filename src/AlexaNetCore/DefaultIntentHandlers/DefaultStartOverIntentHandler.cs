﻿using AlexaNetCore;

namespace AlexaNetCore
{
    public class DefaultStartOverIntentHandler: AlexaIntentHandlerBase
    {
        public override void Process()
        {
            ResponseEnv.SetOutputSpeechText(CustomStartOverText);
            ResponseEnv.ShouldEndSession = true;
        }

        public AlexaMultiLanguageText CustomStartOverText { get; set; }

        public DefaultStartOverIntentHandler(IAlexaNetCoreMessageLogger log = null) : base(AlexaBuiltInIntents.StartOverIntent, log)
        {
            CustomStartOverText = new AlexaMultiLanguageText("I'm sorry, I don't know how to do that.");
        }

        public DefaultStartOverIntentHandler(string txt, IAlexaNetCoreMessageLogger log = null) : base(AlexaBuiltInIntents.StartOverIntent, log)
        {
            CustomStartOverText = new AlexaMultiLanguageText(txt);
        }

        public DefaultStartOverIntentHandler(AlexaMultiLanguageText txt, IAlexaNetCoreMessageLogger log = null) : base(AlexaBuiltInIntents.StartOverIntent, log)
        {
            CustomStartOverText =  txt;
        }

    }
}