
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
        public void Spring()
        {
            //what date value do you get for this week
            var skill = new SlotCheckerSkill();
            skill.LoadRequest(DateSlotCheckerQueries.Spring()).ProcessRequest();

            var expectedVal = "got the single value 2 0 2 2 dash S P";  //asked on 1 april 2022
            Assert.AreEqual(expectedVal, skill.ResponseEnv.GetOutputSpeechText());
        }

        [Test]
        public void NineteenNineties()
        {
            //what date value do you get for this week
            var skill = new SlotCheckerSkill();
            skill.LoadRequest(DateSlotCheckerQueries.NineteenNineties()).ProcessRequest();

            var expectedVal = "got the single value 1 9 9 X";  //asked on 1 april 2022
            Assert.AreEqual(expectedVal, skill.ResponseEnv.GetOutputSpeechText());
        }

        [Test]
        public void ThisYear()
        {
            //what date value do you get for this week
            var skill = new SlotCheckerSkill();
            skill.LoadRequest(DateSlotCheckerQueries.ThisYear()).ProcessRequest();

            var expectedVal = "got the single value 2 0 2 2";  //asked on 1 april 2022
            Assert.AreEqual(expectedVal, skill.ResponseEnv.GetOutputSpeechText());
        }

        [Test]
        public void January()
        {
            //what date value do you get for this week
            var skill = new SlotCheckerSkill();
            skill.LoadRequest(DateSlotCheckerQueries.January()).ProcessRequest();

            var expectedVal = "got the single value 2 0 2 3 dash 0 1";  //asked on 1 april 2022
            Assert.AreEqual(expectedVal, skill.ResponseEnv.GetOutputSpeechText());
        }

        [Test]
        public void NextWeekend()
        {
            //what date value do you get for this week
            var skill = new SlotCheckerSkill();
            skill.LoadRequest(DateSlotCheckerQueries.NextWeekEnd()).ProcessRequest();

            var expectedVal = "got the single value 2 0 2 2 dash W 1 4 dash W E";  //asked on 1 april 2022
            Assert.AreEqual(expectedVal, skill.ResponseEnv.GetOutputSpeechText());
        }

        [Test]
        public void ThisWeek()
        {
            //what date value do you get for this week
            var skill = new SlotCheckerSkill();
            skill.LoadRequest(DateSlotCheckerQueries.AskForThisWeek()).ProcessRequest();

            var expectedVal = "got the single value 2 0 2 2 dash W 1 3";  //asked on 1 april 2022
            Assert.AreEqual(expectedVal, skill.ResponseEnv.GetOutputSpeechText());
        }

        [Test]
        public void SingleStandardDate()
        {
            //what date values do you get for april 4 as your input value
            var skill = new SlotCheckerSkill();
            skill.LoadRequest(DateSlotCheckerQueries.AskForAprilFourth()).ProcessRequest();

            var expectedVal = "got the single value 2 0 2 2 dash 0 4 dash 0 4";
            Assert.AreEqual(expectedVal, skill.ResponseEnv.GetOutputSpeechText());
        }

        [Test]
        public void MultipleStandardDates()
        {
            //what date values do you get for april 4 as your input value
            var skill = new SlotCheckerSkill();
            skill.LoadRequest(DateSlotCheckerQueries.AskForAprilFirstAndSeptemberFifth()).ProcessRequest();

            var expectedVal = "got 2 values, 2 0 2 2 dash 0 4 dash 0 1 and 2 0 2 2 dash 0 9 dash 0 5 ";
            Assert.AreEqual(expectedVal, skill.ResponseEnv.GetOutputSpeechText());
        }

    }
}

