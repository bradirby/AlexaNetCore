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


    }
}
