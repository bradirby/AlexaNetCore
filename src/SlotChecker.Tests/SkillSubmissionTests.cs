
using AlexaNetCore;
using NUnit.Framework;

namespace SlotChecker.Tests
{
    /// <summary>
    /// These tests attempt to cover the skills submission tests that are listed here:
    /// https://developer.amazon.com/public/solutions/alexa/alexa-skills-kit/docs/alexa-skills-kit-voice-interface-and-user-experience-testing?ref_=pe_679090_102923190
    /// </summary>
    public class SkillSubmissionTests 
    {

        [Test]
        public void LaunchRequest()
        {
            var skill = new SlotCheckerSkill();
            skill.LoadRequest(GenericSkillRequests.LaunchRequest()).ProcessRequest();

            Assert.AreEqual(false, skill.ResponseEnv.ShouldEndSession);
            Assert.AreEqual("Welcome to slot value checker", skill.ResponseEnv.GetOutputSpeechText());
        }

      
        
        [Test]
        public void CancelRequest()
        {
            var s = new SlotCheckerSkill();
            s.LoadRequest(GenericSkillRequests.CancelRequest()).ProcessRequest();

            Assert.AreEqual(true, s.ResponseEnv.ShouldEndSession);
            Assert.AreEqual(AlexaOutputSpeechType.PlainText, s.ResponseEnv.GetOutputSpeech().SpeechType);
            Assert.IsFalse(string.IsNullOrEmpty(s.ResponseEnv.GetOutputSpeechText()));
            Assert.AreEqual("slot checker cancel intent", s.ResponseEnv.GetOutputSpeechText());
        }


        
        [Test]
        public void StopRequest()
        {
            var s = new SlotCheckerSkill();
            s.LoadRequest(GenericSkillRequests.StopRequest()).ProcessRequest();

            Assert.AreEqual(true, s.ResponseEnv.ShouldEndSession);
            Assert.AreEqual(AlexaOutputSpeechType.PlainText, s.ResponseEnv.GetOutputSpeech().SpeechType);
            Assert.IsFalse(string.IsNullOrEmpty(s.ResponseEnv.GetOutputSpeechText()));
            Assert.AreEqual("slot checker stop", s.ResponseEnv.GetOutputSpeechText());

        }


        [Test]
        public void InvalidIntentName()
        {
            var s = new SlotCheckerSkill();
            s.LoadRequest(GenericSkillRequests.InvalidIntentName()).ProcessRequest();

            Assert.AreEqual(false, s.ResponseEnv.ShouldEndSession);
            Assert.AreEqual(AlexaOutputSpeechType.PlainText, s.ResponseEnv.GetOutputSpeech().SpeechType);
            Assert.IsFalse(string.IsNullOrEmpty(s.ResponseEnv.GetOutputSpeechText()));
        }

        [Test]
        public void InvalidIntentType()
        {
            var s = new SlotCheckerSkill();
            s.LoadRequest(GenericSkillRequests.InvalidIntentType()).ProcessRequest();

            Assert.AreEqual(false, s.ResponseEnv.ShouldEndSession);
            Assert.AreEqual(AlexaOutputSpeechType.PlainText, s.ResponseEnv.GetOutputSpeech().SpeechType);
            Assert.IsFalse(string.IsNullOrEmpty(s.ResponseEnv.GetOutputSpeechText()));
            Assert.AreEqual("you got slot checker help", s.ResponseEnv.GetOutputSpeechText());
        }

      

    }
}

