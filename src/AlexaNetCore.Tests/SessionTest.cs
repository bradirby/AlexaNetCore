using System.Threading.Tasks;
using AlexaNetCore.Model;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace AlexaNetCore.Tests
{
    public class SessionTest
    {

        internal class IntentThatSaveSession : AlexaIntentHandlerBase
        {
            internal  IntentThatSaveSession() : base(AlexaIntentType.Launch,"IntentThatSavesSession", null) { }

            public override Task ProcessAsync()
            {
                SetSessionValue("MySessionKey", "FindThisValue");
                return Task.CompletedTask;

            }
        }

        internal class TestSkill : AlexaSkillBase
        {
            public TestSkill(ILoggerFactory loggerFactory) : base(loggerFactory)
            {
                RegisterIntentHandler(new IntentThatSaveSession());
            }
        }


        [Test]
        public async Task SessionValueSet_ShowsUpInJson()
        {
            var skill = new TestSkill(new LoggerFactory());
            skill.LoadRequest(GenericSkillRequests.LaunchRequest());
            await skill.ProcessRequestAsync();

            Assert.AreEqual("FindThisValue", skill.GetResponseSessionValue("MySessionKey", ""));

            var json = skill.GetResponse();
            Assert.IsTrue(json.Contains("FindThisValue"));
        }

    }
    
}
