using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlexaNetCore.Interfaces;
using Amazon.Lambda.Core;
using Moq;
using NUnit.Framework;

namespace AlexaNetCore.Tests
{
    public class ConstructorTests
    {
        private class TestAlexaSkill : AlexaSkillBase
        {
            public TestAlexaSkill()
            {
            }

            public TestAlexaSkill(IAlexaMessageLogger log) : base(log)
            {

            }


        }

        [Test]
        public void AlexaSkillBase_EmptyConstructor()
        {
            var skill = new TestAlexaSkill();
        }

        [Test]
        public void AlexaSkillBase_NullLogger()
        {
            var skill = new TestAlexaSkill((IAlexaMessageLogger) null);
            Assert.IsNull( skill.MsgLogger);

            skill = new TestAlexaSkill(null);
            Assert.IsNull( skill.MsgLogger);
        }

        [Test]
        public void AlexaSkillBase_BuiltInLogger()
        {
            var mockLogger = new Mock<IAlexaMessageLogger>();
            var skill = new TestAlexaSkill(mockLogger.Object);
            Assert.AreEqual(mockLogger.Object, skill.MsgLogger);
        }

    }
}
