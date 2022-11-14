using System;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using AlexaNetCore.Model;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace AlexaNetCore.Tests.InteractionModelTests
{

    internal class InteractionModelGenerationTests
    {
        private string dblQuote => "\"";

        [Test]
        public void Intent_GeneratesNameCorrectly()
        {
            var intent = new ModelGenIntent();
            var obj = intent.GetInteractionModel();
            var str = JsonSerializer.Serialize(obj);
            Assert.IsTrue(str.Contains($"\"name\":\"ModelGenIntent\""));
        }

        [Test]
        public void Intent_NoSampleInvocations_DoesNotShowOption()
        {
            var intent = new ModelGenIntent();
            var obj = intent.GetInteractionModel();
            var str = JsonSerializer.Serialize(obj);
            Assert.IsTrue(str.Contains($"{dblQuote}samples{dblQuote}"));
        }

        [Test]
        public void Intent_OneSampleInvocations_GeneratesProperCollection()
        {
            var intent = new ModelGenIntent().AddSampleInvocation("find this invocation");
            var obj = intent.GetInteractionModel();
            var str = JsonSerializer.Serialize(obj);
            Assert.IsTrue(str.Contains($"{dblQuote}samples{dblQuote}:[{dblQuote}find this invocation{dblQuote}]"));
        }

        [Test]
        public void Intent_TwoSampleInvocations_GeneratesProperCollection()
        {
            var intent = new ModelGenIntent()
                .AddSampleInvocation("find this invocation")
                .AddSampleInvocation("and this one");
            var obj = intent.GetInteractionModel();
            var str = JsonSerializer.Serialize(obj);
            Assert.IsTrue(str.Contains($"{dblQuote}samples{dblQuote}:[{dblQuote}find this invocation{dblQuote},{dblQuote}and this one{dblQuote}]"));
        }

        [Test]
        public void Skill_NoInvocationName_Throws()
        {
            var skill = new TestSkill(new Mock<ILoggerFactory>().Object);
            Assert.Throws<ArgumentException>(() => skill.ValidateInteractionModel(AlexaLocale.English_US).GetInteractionModel(AlexaLocale.English_US));
        }

        [Test]
        public void Skill_NoIntents_Throws()
        {
            var skill = new TestSkill(new Mock<ILoggerFactory>().Object);
            skill.SetInvocationName("unimportant string");
            Assert.Throws<ArgumentException>(() => skill.ValidateInteractionModel(AlexaLocale.English_US).GetInteractionModel(AlexaLocale.English_US));
        }


        [Test]
        public void Skill_OneIntent_HasInvocationName()
        {
            var skill = new TestSkill(new Mock<ILoggerFactory>().Object)
                .SetInvocationName("newskill")
                .RegisterIntentHandler(new ModelGenIntent().AddSampleInvocation("hello"))
                .RegisterIntentHandler(new DefaultFallbackIntentHandler())
                .RegisterIntentHandler(new DefaultNavigateHomeIntentHandler())
                .RegisterIntentHandler(new DefaultSessionEndRequest())
                .RegisterIntentHandler(new DefaultStopIntentHandler())
                .RegisterIntentHandler(new DefaultCancelIntentHandler())
                .RegisterIntentHandler(new DefaultHelpIntentHandler());

            skill.RegisterIntentHandler(new DefaultLaunchIntentHandler());

            var obj = skill.GetInteractionModel(AlexaLocale.English_US);
            var str = JsonSerializer.Serialize(obj);
            Assert.IsTrue(str.Contains($"{dblQuote}invocationName{dblQuote}:{dblQuote}newskill{dblQuote},"));
        }


        private class TestSkill : AlexaSkillBase
        {
            public TestSkill(ILoggerFactory loggerFactory) : base(loggerFactory)
            {

            }
        }


        private class ModelGenIntent : AlexaIntentHandlerBase
        {
            public ModelGenIntent() : base(AlexaIntentType.Custom, "ModelGenIntent")
            {
            }

            public override Task ProcessAsync()
            {
                throw new NotImplementedException();
            }
        }
    }
}
