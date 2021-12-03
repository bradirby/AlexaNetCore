using AlexaNetCore;
using AlexaNetCoreSampleSkill.Intents;
using AlexaNetCoreSampleSkill.Tests;
using NUnit.Framework;

namespace AlexaNetCoreSampleSkill.Tests
{
    /// <summary>
    /// These tests attempt to cover the skills submission tests that are listed here:
    /// https://developer.amazon.com/public/solutions/alexa/alexa-skills-kit/docs/alexa-skills-kit-voice-interface-and-user-experience-testing?ref_=pe_679090_102923190
    /// </summary>
    public class GenericSkillRequestTests 
    {

        [Test]
        public void LaunchRequest_InvokeWithNoIntent_SaysHello()
        {
            var skill = new SampleSkill().LoadRequest(GenericSkillRequests.LaunchRequest()).ProcessRequest();

            Assert.AreEqual(AlexaOutputSpeechType.PlainText, skill.ResponseEnv.Response.OutputSpeech.SpeechType);
            Assert.AreEqual("Hello, what can this SampleSkill do for you today?", skill.ResponseEnv.Response.OutputSpeech.GetText());
        }

        [Test]
        public void LaunchRequest_InvokeWithNoIntent_DoesNotEndSession()
        {
            var skill = new SampleSkill().LoadRequest(GenericSkillRequests.LaunchRequest()).ProcessRequest();
            Assert.AreEqual(false, skill.ResponseEnv.Response.ShouldEndSession);
        }

        
        [Test]
        public void CancelRequest_SaysGoodbye()
        {
            var skill = new SampleSkill().LoadRequest(GenericSkillRequests.CancelRequest()).ProcessRequest();
            Assert.AreEqual(AlexaOutputSpeechType.PlainText, skill.ResponseEnv.Response.OutputSpeech.SpeechType);
            Assert.AreEqual("Goodbye", skill.ResponseEnv.Response.OutputSpeech.GetText());
        }

        [Test]
        public void CancelRequest_EndsSession()
        {
            var skill = new SampleSkill().LoadRequest(GenericSkillRequests.CancelRequest()).ProcessRequest();
            Assert.AreEqual(true, skill.ResponseEnv.Response.ShouldEndSession);
        }

        
        [Test]
        public void LaunchRequest_ShouldNotReturnCard()
        {
            var skill = new SampleSkill().LoadRequest(GenericSkillRequests.LaunchRequest()).ProcessRequest();
            Assert.IsNull(skill.ResponseEnv.Response.Card);
        }

        [Test]
        public void EndSession_ShouldNotReturnCard()
        {
            var skill = new SampleSkill().LoadRequest(GenericSkillRequests.EndSession()).ProcessRequest();
            Assert.IsNull(skill.ResponseEnv.Response.Card);
        }

        [Test]
        public void EmptyRequest_AsksIfUserNeedsHelp()
        {
            var skill = new SampleSkill().LoadRequest(GenericSkillRequests.EmptyRequest()).ProcessRequest();

            Assert.AreEqual(AlexaOutputSpeechType.PlainText, skill.ResponseEnv.Response.OutputSpeech.SpeechType);
            Assert.AreEqual("I can help you with that", skill.ResponseEnv.Response.OutputSpeech.GetText());
        }

        [Test]
        public void EmptyRequest_DoesNotEndSession()
        {
            var skill = new SampleSkill().LoadRequest(GenericSkillRequests.EmptyRequest()).ProcessRequest();
            Assert.AreEqual(false, skill.ResponseEnv.Response.ShouldEndSession);
        }

        [Test]
        public void EmptyRequest_DoesNotReturnCard()
        {
            var skill = new SampleSkill().LoadRequest(GenericSkillRequests.EmptyRequest()).ProcessRequest();
            Assert.IsNull( skill.ResponseEnv.Response.Card);
        }

        [Test]
        public void StopRequest_EndsSession()
        {
            var skill = new SampleSkill().LoadRequest(GenericSkillRequests.StopRequest()).ProcessRequest();
            Assert.IsTrue( skill.ResponseEnv.Response.ShouldEndSession);

        }
        
        [Test]
        public void StopRequest_SaysGoodbye()
        {
            var skill = new SampleSkill().LoadRequest(GenericSkillRequests.StopRequest()).ProcessRequest();
            Assert.AreEqual(AlexaOutputSpeechType.PlainText, skill.ResponseEnv.Response.OutputSpeech.SpeechType);

            //Note the period in the string, this is coming from the default Stop handler, not the Cancel handler defined in the SampleSkill
            Assert.AreEqual("Goodbye.", skill.ResponseEnv.Response.OutputSpeech.GetText());
        }


    

        [Test]
        public void InvalidIntentName_ReturnsHelpText()
        {
            var s = new SampleSkill().LoadRequest(GenericSkillRequests.InvalidIntentName()).ProcessRequest();

            Assert.AreEqual(false, s.ResponseEnv.Response.ShouldEndSession);
            Assert.AreEqual(AlexaOutputSpeechType.PlainText, s.ResponseEnv.Response.OutputSpeech.SpeechType);
            Assert.AreEqual("I can help you with that", s.ResponseEnv.Response.OutputSpeech.GetText());
        }

        [Test]
        public void InvalidIntentName_DoesNotEndSession()
        {
            var skill = new SampleSkill().LoadRequest(GenericSkillRequests.InvalidIntentType()).ProcessRequest();

            Assert.AreEqual(false, skill.ResponseEnv.Response.ShouldEndSession);
        }

       

    }
}

