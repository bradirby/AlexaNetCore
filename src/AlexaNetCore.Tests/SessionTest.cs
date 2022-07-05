using System.Threading.Tasks;
using AlexaNetCore.Model;
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
                SetResponseSessionValue("MySessionKey", "FindThisValue");
                return Task.CompletedTask;

            }
        }

        internal class SessionTestAlexaSkill : AlexaSkillBase
        {
            public SessionTestAlexaSkill()
            {
                RegisterIntentHandler(new IntentThatSaveSession());
            }
        }


        [Test]
        public async Task SessionValueSet_ShowsUpInJson()
        {
            var skill = new SessionTestAlexaSkill();
            skill.LoadRequest(BuiltInIntentRequests.LaunchRequest);
            await skill.ProcessRequestAsync();

            Assert.AreEqual("FindThisValue", skill.GetResponseSessionValue("MySessionKey", ""));

            var json = skill.GetResponse();
            Assert.IsTrue(json.Contains("FindThisValue"));
        }

    }
    
}
