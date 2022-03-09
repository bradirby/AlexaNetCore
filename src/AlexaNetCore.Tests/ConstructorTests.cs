using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            public TestAlexaSkill(IAlexaNetCoreMessageLogger log) : base(log)
            {

            }

            public TestAlexaSkill(ILambdaLogger log) : base(log)
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
            var skill = new TestAlexaSkill((IAlexaNetCoreMessageLogger) null);
            Assert.IsNull( skill.MsgLogger);

            skill = new TestAlexaSkill((ILambdaLogger) null);
            Assert.IsNull( skill.MsgLogger);
        }

        [Test]
        public void AlexaSkillBase_BuiltInLogger()
        {
            var mockLogger = new Mock<IAlexaNetCoreMessageLogger>();
            var skill = new TestAlexaSkill(mockLogger.Object);
            Assert.AreEqual(mockLogger.Object, skill.MsgLogger);
        }

        [Test]
        public void AlexaSkillBase_ILambdaLogger()
        {
            var mockLogger = new Mock<ILambdaLogger>();
            var skill = new TestAlexaSkill(mockLogger.Object);
            Assert.AreNotEqual(mockLogger.Object, skill.MsgLogger);

        }
    }
}
