using System;
using System.Runtime.CompilerServices;
using System.Text.Json;
using AlexaSkillDotNet;
using NUnit.Framework;

namespace AlexaSkillDotNet.Tests
{
    public class SessionTest
    {

        private class IntentThatSaveSession : AlexaIntentHandlerBase
        {
            public static string IntentName => "IntentThatSavesSession";
            public IntentThatSaveSession() : base(IntentName, null) { }

            public override void Process()
            {
                ResponseEnv.SetSessionValue("MySessionKey", "FindThisValue");
                ResponseEnv.SetOutputSpeech("Hello World");
            }
        }

        private class SessionTestAlexaSkill : AlexaSkillBase
        {
            public SessionTestAlexaSkill()
            {
                RegisterIntentHandler(new IntentThatSaveSession());
                RegisterDefaultIntentHandlers();
            }
        }


        [Test]
        public void SessionValueSet_ShowsUpInJson()
        {
            var skill = new SessionTestAlexaSkill();
            skill.LoadRequest(AirportInfoRequests.AirportInfoSFO_GoodRequest());
            skill.RequestEnv.Request.Intent.Name = IntentThatSaveSession.IntentName;
            skill.ProcessRequest();

            Assert.AreEqual("Hello World", skill.ResponseEnv.GetOutputSpeach(AlexaLocale.English_US));
            Assert.AreEqual("FindThisValue", skill.ResponseEnv.GetSessionValue("MySessionKey",""));
            var json = skill.CreateAlexaResponse();

            Assert.IsTrue(json.Contains("FindThisValue"));
        }

    }
    
}
