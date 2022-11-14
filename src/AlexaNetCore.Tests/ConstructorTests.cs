using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlexaNetCore.Interfaces;
using Amazon.Lambda.Core;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace AlexaNetCore.Tests
{
    public class ConstructorTests
    {
        private class TestAlexaSkill : AlexaSkillBase
        {
            public TestAlexaSkill(ILoggerFactory log) : base(log)
            {

            }


        }

        [Test]
        public void AlexaSkillBase_EmptyConstructor()
        {
            var skill = new TestAlexaSkill(new LoggerFactory());
        }

        [Test]
        public void AlexaSkillBase_NullLogger()
        {
            var skill = new TestAlexaSkill(new LoggerFactory());
            Assert.IsNotNull( skill.MsgLogger);

            skill = new TestAlexaSkill(new LoggerFactory());
            Assert.IsNotNull( skill.MsgLogger);
        }

      

    }
}
