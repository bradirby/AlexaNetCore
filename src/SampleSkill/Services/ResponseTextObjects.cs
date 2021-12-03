using System;
using System.Collections.Generic;
using System.Text;
using AlexaSkillDotNet;

namespace ExactMeasureSkill.Intents
{
    public class ResponseTextObjects
    {
        public static readonly AlexaMultiLanguageText BadUnitOfMeasure = 
            new AlexaMultiLanguageText("Sorry, I don't recognize that unit of measure.");

        public static readonly AlexaMultiLanguageText Reprompt = 
            new AlexaMultiLanguageText("Did you want to convert anything else?");

        public static readonly AlexaMultiLanguageText ErrorTryAgain = 
            new AlexaMultiLanguageText("I'm sorry, something went wrong. Can you try again?");
    }
}
