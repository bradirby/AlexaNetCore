
using System.Threading.Tasks;
using NUnit.Framework;

namespace AlexaNetCore.Tests.DefaultIntentHandlerTests
{
    public class BuiltInIntentsTests
    {


        [Test]
        public async Task CancelIntent()
        {
            var skill = await new SkillWithAllBuiltInIntents()
                .LoadRequest(BuiltInIntentRequests.CancelIntent)
                .ProcessRequestAsync();
            Assert.AreEqual(AlexaBuiltInIntents.CancelIntent, skill.ChosenIntent.IntentName);
        }

        [Test]
        public async Task StopIntent()
        {
            var skill = await new SkillWithAllBuiltInIntents()
                .LoadRequest(BuiltInIntentRequests.StopIntent)
                .ProcessRequestAsync();
            Assert.AreEqual(AlexaBuiltInIntents.StopIntent, skill.ChosenIntent.IntentName);
        }

        [Test]
        public async Task FallbackIntent()
        {
            var skill = await new SkillWithAllBuiltInIntents()
                .LoadRequest(BuiltInIntentRequests.FallbackIntent)
                .ProcessRequestAsync();
            Assert.AreEqual(AlexaBuiltInIntents.FallbackIntent, skill.ChosenIntent.IntentName);
        }


        [Test]
        public async Task StartOverIntent()
        {
            var skill = await new SkillWithAllBuiltInIntents()
                .LoadRequest(BuiltInIntentRequests.StartOverIntent)
                .ProcessRequestAsync();
            Assert.AreEqual(AlexaBuiltInIntents.StartOverIntent, skill.ChosenIntent.IntentName);
        }


        private class SkillWithAllBuiltInIntents : AlexaSkillBase
        {
            public SkillWithAllBuiltInIntents()
            {
                RegisterIntentHandler(new DefaultCancelIntentHandler());
                RegisterIntentHandler(new DefaultHelpIntentHandler());
                RegisterIntentHandler(new DefaultFallbackIntentHandler());
                RegisterIntentHandler(new DefaultLaunchIntentHandler());
                RegisterIntentHandler(new DefaultSessionEndRequest());
                RegisterIntentHandler(new DefaultStartOverIntentHandler());
                RegisterIntentHandler(new DefaultStopIntentHandler());
            }
        }
    }


}

