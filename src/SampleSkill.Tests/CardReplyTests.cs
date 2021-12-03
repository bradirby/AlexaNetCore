using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using AlexaNetCore;

namespace AlexaNetCoreSampleSkill.Tests
{
    public class CardReplyTests
    {

        [Test]
        public void LaunchRequest_ShouldNotReturnCard()
        {
            var skill = new SampleSkill();
            skill.LoadRequest(GenericSkillRequests.LaunchRequest()).ProcessRequest();

            Assert.IsNull(skill.ResponseEnv.Response.Card);
        }

        [Test]
        public void EndSession_ShouldNotReturnCard()
        {
            var skill = new SampleSkill();
            skill.LoadRequest(GenericSkillRequests.EndSession()).ProcessRequest();

            Assert.IsNull(skill.ResponseEnv.Response.Card);
        }

        [Test]
        public void MetricToImperial_NoDecimals_ShouldNotEndSession()
        {
            var skill = new SampleSkill();
            skill.LoadRequest(MetricToImperialSampleRequests.OneMeterInYards());
            skill.ProcessRequest();

            Assert.IsNotNull(skill.ResponseEnv.Response.Card);
            Assert.AreEqual("meters to yards",skill.ResponseEnv.Response.Card.Title.GetText(AlexaLocale.English_US));
            Assert.AreEqual("1 meter\r\n = 1.0936 yards\r\n = 3 feet 3 3/8 inches\r\n",skill.ResponseEnv.Response.Card.Content.GetText(AlexaLocale.English_US));
        }

        [Test]
        public void MetricToImperial_Decimals_ShouldNotEndSession()
        {
            var skill = new SampleSkill();
            skill.LoadRequest(MetricToImperialSampleRequests.OnePointTwoMetersInYards()).ProcessRequest();

            Assert.IsNotNull(skill.ResponseEnv.Response.Card);
            Assert.AreEqual("meters to yards",skill.ResponseEnv.Response.Card.Title.GetText(AlexaLocale.English_US));
            Assert.AreEqual("1.2 meters\r\n = 1.3123 yards\r\n = 3 feet 11 1/4 inches\r\n",skill.ResponseEnv.Response.Card.Content.GetText(AlexaLocale.English_US));
        }

        
        [Test]
        public void MetricToImperial_DecimalNumber_ShouldNotEndSession()
        {
            var skill = new SampleSkill();
            skill.LoadRequest(MetricToImperialSampleRequests.OnePointTwoMetersInYards()).ProcessRequest();

            Assert.IsNotNull(skill.ResponseEnv.Response.Card);
        }

    }
}
