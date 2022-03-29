using System;
using System.Text.Json;
using NUnit.Framework;

namespace AlexaNetCore.Tests
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
            Assert.IsTrue(str.Contains($"{dblQuote}name{dblQuote}:{dblQuote}ModelGenIntent{dblQuote}"));
        }

        [Test]
        public void Intent_NoSampleInvocations_GeneratesEmptyCollection()
        {
            var intent = new ModelGenIntent();
            var obj = intent.GetInteractionModel();
            var str = JsonSerializer.Serialize(obj);
            Assert.IsTrue(str.Contains($"{dblQuote}samples{dblQuote}:[]"));
        }

        [Test]
        public void Intent_OneSampleInvocations_GeneratesProperCollection()
        {
            var intent = new ModelGenIntent();
            intent.AddSampleInvocation("find this invocation");
            var obj = intent.GetInteractionModel();
            var str = JsonSerializer.Serialize(obj);
            Assert.IsTrue(str.Contains($"{dblQuote}samples{dblQuote}:[{dblQuote}find this invocation{dblQuote}]"));
        }

        [Test]
        public void Intent_TwoSampleInvocations_GeneratesProperCollection()
        {
            var intent = new ModelGenIntent();
            intent.AddSampleInvocation("find this invocation");
            intent.AddSampleInvocation("and this one");
            var obj = intent.GetInteractionModel();
            var str = JsonSerializer.Serialize(obj);
            Assert.IsTrue(str.Contains($"{dblQuote}samples{dblQuote}:[{dblQuote}find this invocation{dblQuote},{dblQuote}and this one{dblQuote}]"));
        }

        [Test]
        public void Skill_NoInvocationName_Throws()
        {
            var skill = new ModelGenSkill();
            Assert.Throws<ArgumentNullException>(() => skill.GetInteractionModel());
        }

        [Test]
        public void Skill_NoIntents_Throws()
        {
            var skill = new ModelGenSkill();
            skill.InvocationName = "unimportant string";
            Assert.Throws<ArgumentNullException>(() => skill.GetInteractionModel());
        }


        [Test]
        public void Skill_OneIntent_HasInvocationName()
        {
            var skill = new ModelGenSkill();
            skill.InvocationName = "newSkill";
            skill.RegisterIntentHandler(new DefaultFallbackIntentHandler());
            var obj= skill.GetInteractionModel();
            var str = JsonSerializer.Serialize(obj);
            Assert.IsTrue(str.Contains($"{dblQuote}invocationName{dblQuote}:{dblQuote}newSkill{dblQuote},"));
        }

        [Test]
        public void Skill_OneIntentWithNoSamples_HasIntentName()
        {
            var skill = new ModelGenSkill();
            var fallbackIntent = new DefaultFallbackIntentHandler();
            skill.InvocationName = "newSkill";
            skill.RegisterIntentHandler(fallbackIntent);
            var obj= skill.GetInteractionModel();
            var str = JsonSerializer.Serialize(obj);
            var expectedVal = $"{{\"interactionModel\":{{\"languageModel\":{{\"invocationName\":\"newSkill\",\"intents\":[{{\"name\":\"AMAZON.FallbackIntent\",\"slots\":[],\"samples\":[]}}],\"types\":[]}}}}}}";
            Assert.IsTrue(str.Contains(expectedVal));
        }

        [Test]
        public void Skill_TwoIntentsWithNoSamples_HasIntentName()
        {
            var skill = new ModelGenSkill();
            var fallbackIntent = new DefaultFallbackIntentHandler();
            var cancelIntent = new DefaultCancelIntentHandler();
            skill.InvocationName = "newSkill";
            skill.RegisterIntentHandler(fallbackIntent);
            skill.RegisterIntentHandler(cancelIntent);
            var obj= skill.GetInteractionModel();
            var str = JsonSerializer.Serialize(obj);

            var expectedVal = $"\"intents\":[{{\"name\":\"AMAZON.FallbackIntent\",\"slots\":[],\"samples\":[]";
            Assert.IsTrue(str.Contains(expectedVal));

            expectedVal = $"{{\"name\":\"AMAZON.CancelIntent\",\"slots\":[],\"samples\":[]";
            Assert.IsTrue(str.Contains(expectedVal));
        }

        [Test]
        public void Skill_OneIntentsWithSamples_HasIntentName()
        {
            var skill = new ModelGenSkill();
            var modelIntent = new ModelGenIntent();
            modelIntent.AddSampleInvocation("find sample invocation");
            skill.InvocationName = "newSkill";
            skill.RegisterIntentHandler(modelIntent);
            var obj= skill.GetInteractionModel();
            var str = JsonSerializer.Serialize(obj);

            var expectedVal = $"{{\"interactionModel\":{{\"languageModel\":{{\"invocationName\":\"newSkill\",\"intents\":[{{\"name\":\"ModelGenIntent\",\"slots\":[],\"samples\":[\"find sample invocation\"]}}],\"types\":[]}}}}}}";
            Assert.IsTrue(str.Contains(expectedVal));
        }

        private class ModelGenSkill : AlexaSkillBase
        {

        }


        private class ModelGenIntent : AlexaIntentHandlerBase
        {
            public ModelGenIntent() : base("ModelGenIntent")
            {
            }

            public override void Process()
            {
                throw new NotImplementedException();
            }
        }
    }
}
