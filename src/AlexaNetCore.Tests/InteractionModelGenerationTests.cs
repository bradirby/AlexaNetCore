using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AlexaNetCore.Tests
{
    internal class InteractionModelGenerationTests
    {
        private string dblQuote => "\"";
        private string curlyBraceOpen => "{";
        private string curlyBraceClose = "}";
        
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
            Assert.IsTrue(str.Contains($"{dblQuote}intents{dblQuote}:[{curlyBraceOpen}{dblQuote}name{dblQuote}:{dblQuote}{fallbackIntent.IntentName}{dblQuote},{dblQuote}samples{dblQuote}:[]"));
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

            Assert.IsTrue(str.Contains($"{dblQuote}intents{dblQuote}:[{curlyBraceOpen}{dblQuote}name{dblQuote}:{dblQuote}{fallbackIntent.IntentName}{dblQuote},{dblQuote}samples{dblQuote}:[]"));
            Assert.IsTrue(str.Contains($"{curlyBraceOpen}{dblQuote}name{dblQuote}:{dblQuote}{cancelIntent.IntentName}{dblQuote},{dblQuote}samples{dblQuote}:[]"));
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

            Assert.IsTrue(str.Contains($"{dblQuote}intents{dblQuote}:[{curlyBraceOpen}{dblQuote}name{dblQuote}:{dblQuote}{modelIntent.IntentName}{dblQuote},{dblQuote}samples{dblQuote}:[{dblQuote}find sample invocation{dblQuote}]"));
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
