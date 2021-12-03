using AlexaSkillDotNet;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExactMeasureSkill.Tests
{
    public class SessionMgmtAndFallBackRequestTests
    {

        [Test]
        public void LaunchRequest_ShouldNotEndSession()
        {
            var skill = new ExactMeasureAlexaSkill();
            skill.LoadRequest(GenericSkillRequests.LaunchRequest()).ProcessRequest();

            Assert.AreEqual(false, skill.ResponseEnv.Response.ShouldEndSession);
            Assert.AreEqual("Hello, what would you like this Debug version 0.9 to convert?", skill.ResponseEnv.Response.OutputSpeech.GetText(AlexaLocale.English_US));
        }

        [Test]
        public void EndSession_ShouldEndSession()
        {
            var skill = new ExactMeasureAlexaSkill();
            skill.LoadRequest(GenericSkillRequests.EndSession()).ProcessRequest();

            Assert.AreEqual(true, skill.ResponseEnv.Response.ShouldEndSession);
            Assert.AreEqual("Goodbye", skill.ResponseEnv.Response.OutputSpeech.GetText(AlexaLocale.English_US));
        }

        [Test]
        public void MetricToImperial_ShouldNotEndSession()
        {
            var skill = new ExactMeasureAlexaSkill();
            skill.LoadRequest(MetricToImperialSampleRequests.OneMeterInYards()).ProcessRequest();

            Assert.AreEqual(false, skill.ResponseEnv.Response.ShouldEndSession);
        }

    }
}
