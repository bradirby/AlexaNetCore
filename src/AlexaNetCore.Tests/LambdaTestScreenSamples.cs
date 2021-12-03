using System;
using System.Text.Json;
using AlexaNetCore;
using NUnit.Framework;

namespace AlexaNetCore.Tests
{

    public class LambdaTestScreenSamples
    {
        [Test]
        public void LambdaTestScreen_AlexaStartSession()
        {
            var reqEnv =
                JsonSerializer.Deserialize<AlexaSkillRequestEnvelope>(AmazonIntentSampleRequests
                    .LambdaTestScreen_AlexaStartSession());

            Assert.AreEqual("1.0", reqEnv.Version);
            Assert.AreEqual(true, reqEnv.Session.New);
            Assert.AreEqual("amzn1.echo-api.session.[unique-value-here]", reqEnv.Session.SessionId);
        }

        [Test]
        public void LambdaTestScreen_AlexaIntent_Answer()
        {
            var reqEnv = JsonSerializer.Deserialize<AlexaSkillRequestEnvelope>(AmazonIntentSampleRequests
                    .LambdaTestScreen_AlexaIntent_Answer());

            Assert.AreEqual("1.0", reqEnv.Version);

            var sess = reqEnv.Session;
            Assert.IsNotNull(sess);
            Assert.AreEqual(false, sess.New);
            Assert.AreEqual("amzn1.echo-api.session.[unique-value-here]", sess.SessionId);
            Assert.AreEqual(8, sess.Attributes.Count);

            var attr = sess.Attributes["score"];
            Assert.IsNotNull(attr);
            Assert.AreEqual(4, int.Parse(attr.ToString()));
            Assert.AreEqual(4, int.Parse(sess.GetAttributeValue("score", "0").ToString()));

            Assert.AreEqual("Donner", sess.GetAttributeValue("correctAnswerText", "").ToString());
        }



    }

}
