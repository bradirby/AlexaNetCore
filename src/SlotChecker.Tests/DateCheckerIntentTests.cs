
using AlexaNetCore;
using NUnit.Framework;

namespace SlotChecker.Tests
{
    /// <summary>
    /// These tests attempt to cover the skills submission tests that are listed here:
    /// https://developer.amazon.com/public/solutions/alexa/alexa-skills-kit/docs/alexa-skills-kit-voice-interface-and-user-experience-testing?ref_=pe_679090_102923190
    /// </summary>
    public class DateCheckerIntentTests 
    {

        [Test]
        public void SingleStandardDate()
        {
            //what date values do you get for april 4 as your input value
            var skill = new SlotCheckerSkill();
            skill.LoadRequest(DateSlotCheckerQueries.AskForAprilFourth()).ProcessRequest();

            var expectedVal = "got the single value 2 0 2 2 - 0 4 - 0 4";
            Assert.AreEqual(expectedVal, skill.ResponseEnv.GetOutputSpeechText());
        }

        [Test]
        public void MultipleStandardDates()
        {
            //what date values do you get for april 4 as your input value
            var skill = new SlotCheckerSkill();
            skill.LoadRequest(DateSlotCheckerQueries.AskForAprilFirstAndSeptemberFifth()).ProcessRequest();

            var expectedVal = "got 2 values, 2 0 2 2 - 0 4 - 0 1 and 2 0 2 2 - 0 9 - 0 5 ";
            Assert.AreEqual(expectedVal, skill.ResponseEnv.GetOutputSpeechText());
        }

    }
}

