
using AlexaNetCore;
using NUnit.Framework;

namespace AlexaNetCore.Tests
{
    public class BuiltInIntentsTests 
    {
        [Test]
        public void LoopOffIntent()
        {
            var skill = new SkillWithAllBuiltInIntents();
            skill.LoadRequest(BuildInIntentsRequests.LoopOffIntent).ProcessRequest();
            Assert.AreEqual(AlexaBuiltInIntents.LoopOffIntent, skill.ResponseEnv.IntentHandlerName);
        }

        [Test]
        public void LoopOnIntent()
        {
            var skill = new SkillWithAllBuiltInIntents();
            skill.LoadRequest(BuildInIntentsRequests.LoopOnIntent).ProcessRequest();
            Assert.AreEqual(AlexaBuiltInIntents.LoopOnIntent, skill.ResponseEnv.IntentHandlerName);
        }

        [Test]
        public void CancelIntent()
        {
            var skill = new SkillWithAllBuiltInIntents();
            skill.LoadRequest(BuildInIntentsRequests.CancelIntent).ProcessRequest();
            Assert.AreEqual(AlexaBuiltInIntents.CancelIntent, skill.ResponseEnv.IntentHandlerName);
        }

        [Test]
        public void StopIntent()
        {
            var skill = new SkillWithAllBuiltInIntents();
            skill.LoadRequest(BuildInIntentsRequests.StopIntent).ProcessRequest();
            Assert.AreEqual(AlexaBuiltInIntents.StopIntent, skill.ResponseEnv.IntentHandlerName);
        }

        [Test]
        public void HelpIntent()
        {
            var skill = new SkillWithAllBuiltInIntents();
            skill.LoadRequest(BuildInIntentsRequests.HelpIntent).ProcessRequest();
            Assert.AreEqual(AlexaBuiltInIntents.HelpIntent, skill.ResponseEnv.IntentHandlerName);
        }

        [Test]
        public void FallbackIntent()
        {
            var skill = new SkillWithAllBuiltInIntents();
            skill.LoadRequest(BuildInIntentsRequests.FallbackIntent).ProcessRequest();
            Assert.AreEqual(AlexaBuiltInIntents.FallbackIntent, skill.ResponseEnv.IntentHandlerName);
        }

        [Test]
        public void NextIntent()
        {
            var skill = new SkillWithAllBuiltInIntents();
            skill.LoadRequest(BuildInIntentsRequests.NextIntent).ProcessRequest();
            Assert.AreEqual(AlexaBuiltInIntents.NextIntent, skill.ResponseEnv.IntentHandlerName);
        }

        [Test]
        public void PreviousIntent()
        {
            var skill = new SkillWithAllBuiltInIntents();
            skill.LoadRequest(BuildInIntentsRequests.PreviousIntent).ProcessRequest();
            Assert.AreEqual(AlexaBuiltInIntents.PreviousIntent, skill.ResponseEnv.IntentHandlerName);
        }
        
        [Test]
        public void PauseIntent()
        {
            var skill = new SkillWithAllBuiltInIntents();
            skill.LoadRequest(BuildInIntentsRequests.PauseIntent).ProcessRequest();
            Assert.AreEqual(AlexaBuiltInIntents.PauseIntent, skill.ResponseEnv.IntentHandlerName);
        }
        
        [Test]
        public void RepeatIntent()
        {
            var skill = new SkillWithAllBuiltInIntents();
            skill.LoadRequest(BuildInIntentsRequests.RepeatIntent).ProcessRequest();
            Assert.AreEqual(AlexaBuiltInIntents.RepeatIntent, skill.ResponseEnv.IntentHandlerName);
        }
        
        [Test]
        public void ResumeIntent()
        {
            var skill = new SkillWithAllBuiltInIntents();
            skill.LoadRequest(BuildInIntentsRequests.ResumeIntent).ProcessRequest();
            Assert.AreEqual(AlexaBuiltInIntents.ResumeIntent, skill.ResponseEnv.IntentHandlerName);
        }
        
        [Test]
        public void ShuffleOffIntent()
        {
            var skill = new SkillWithAllBuiltInIntents();
            skill.LoadRequest(BuildInIntentsRequests.ShuffleOffIntent).ProcessRequest();
            Assert.AreEqual(AlexaBuiltInIntents.ShuffleOffIntent, skill.ResponseEnv.IntentHandlerName);
        }
        
        [Test]
        public void ShuffleOnIntent()
        {
            var skill = new SkillWithAllBuiltInIntents();
            skill.LoadRequest(BuildInIntentsRequests.ShuffleOnIntent).ProcessRequest();
            Assert.AreEqual(AlexaBuiltInIntents.ShuffleOnIntent, skill.ResponseEnv.IntentHandlerName);
        }
        
        [Test]
        public void StartOverIntent()
        {
            var skill = new SkillWithAllBuiltInIntents();
            skill.LoadRequest(BuildInIntentsRequests.StartOverIntent).ProcessRequest();
            Assert.AreEqual(AlexaBuiltInIntents.StartOverIntent, skill.ResponseEnv.IntentHandlerName);
        }
        
        [Test]
        public void YesIntent()
        {
            var skill = new SkillWithAllBuiltInIntents();
            skill.LoadRequest(BuildInIntentsRequests.YesIntent).ProcessRequest();
            Assert.AreEqual(AlexaBuiltInIntents.YesIntent, skill.ResponseEnv.IntentHandlerName);
        }
        
        [Test]
        public void NoIntent()
        {
            var skill = new SkillWithAllBuiltInIntents();
            skill.LoadRequest(BuildInIntentsRequests.NoIntent).ProcessRequest();
            Assert.AreEqual(AlexaBuiltInIntents.NoIntent, skill.ResponseEnv.IntentHandlerName);
        }
        
        private class SkillWithAllBuiltInIntents : AlexaSkillBase
        {
            public SkillWithAllBuiltInIntents()
            {
                RegisterDefaultIntentHandlers();
            }
        }
    }

    
}

