using System;
using System.Text.Json;
using System.Xml.Linq;
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
            skill.SetInvocationName(  "unimportant string");
            Assert.Throws<ArgumentNullException>(() => skill.GetInteractionModel());
        }


        [Test]
        public void Skill_OneIntent_HasInvocationName()
        {
            var skill = new ModelGenSkill();
            skill.SetInvocationName(  "newskill");
            skill.RegisterIntentHandler(new DefaultFallbackIntentHandler());
            skill.RegisterIntentHandler(new DefaultHelpIntentHandler());
            var obj= skill.GetInteractionModel();
            var str = JsonSerializer.Serialize(obj);
            Assert.IsTrue(str.Contains($"{dblQuote}invocationName{dblQuote}:{dblQuote}newskill{dblQuote},"));
        }

        [Test]
        public void Skill_OneIntentWithNoSamples_HasIntentName()
        {
            var skill = new ModelGenSkill();
            skill.SetInvocationName(  "newskill");
            skill.RegisterIntentHandler(new DefaultHelpIntentHandler());
            var obj= skill.GetInteractionModel();
            var str = JsonSerializer.Serialize(obj);
            var expectedVal = $"{{\"interactionModel\":{{\"languageModel\":{{\"invocationName\":\"newskill\",\"intents\":[{{\"name\":\"AMAZON.HelpIntent\",\"samples\":[]}}]}}}}}}";
            Assert.IsTrue(str.Contains(expectedVal));
        }

        [Test]
        public void Skill_TwoIntentsWithNoSamples_HasIntentName()
        {
            var skill = new ModelGenSkill();
            skill.SetInvocationName(  "newskill");
            skill.RegisterIntentHandler(new DefaultCancelIntentHandler());
            skill.RegisterIntentHandler(new DefaultHelpIntentHandler());
            var obj= skill.GetInteractionModel();
            var str = JsonSerializer.Serialize(obj);

            var expectedVal = $"\"intents\":[{{\"name\":\"AMAZON.CancelIntent\"";
            Assert.IsTrue(str.Contains(expectedVal));

            expectedVal = $"{{\"name\":\"AMAZON.HelpIntent\"";
            Assert.IsTrue(str.Contains(expectedVal));
        }

        [Test]
        public void Skill_OneIntentsWithSamples_HasIntentName()
        {
            var skill = new ModelGenSkill();
            skill.RegisterIntentHandler(new DefaultHelpIntentHandler());
            var modelIntent = new ModelGenIntent();
            modelIntent.AddSampleInvocation("find sample invocation");
            skill.SetInvocationName(  "newskill");
            skill.RegisterIntentHandler(modelIntent);
            var obj= skill.GetInteractionModel();
            var str = JsonSerializer.Serialize(obj);

            var expectedVal = $"{{\"interactionModel\":{{\"languageModel\":{{\"invocationName\":\"newskill\",\"intents\":[{{\"name\":\"AMAZON.HelpIntent\",\"samples\":[]}},{{\"name\":\"ModelGenIntent\",\"samples\":[\"find sample invocation\"]}}]}}}}}}";
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
