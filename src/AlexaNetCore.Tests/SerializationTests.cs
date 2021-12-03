using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.Json;
using NUnit.Framework;

namespace AlexaNetCore.Tests
{
    public class SerializationTests
    {

        [Test]
        public void RequestEnvelope_CanDeserialize()
        {
            
            var jsonStr = AmazonIntentSampleRequests.SessionEndedRequest().Replace("'", "\"");
            var reqEnv = JsonSerializer.Deserialize<AlexaSkillRequestEnvelope>(jsonStr);

            Assert.IsNotNull(reqEnv);
            Assert.IsNotNull(reqEnv.Session);
            Assert.IsNotNull(reqEnv.Request);
            Assert.AreEqual("1.0", reqEnv.Version);
        }




        [Test]
        public void Session_CanDeserialize()
        {
            var jsonStr = @"
{
    'new': false,
    'sessionId': 'session1234',
    'attributes': { },
    'user': {'userId': 'amzn1.ask.account.AFP3ZWPOS2BGJR7OWJZ3DHPKMOMDS7SN3HP3B3GZPDYUVPQUNF65UGMED2LUXUORM5C7PK7RGCTLWN53FR33NJH5OZM4AOYOSJQ64N7QCSWJDZKVFZDWRJKXBDJVWY4TWTLIULKKGJMUEMJSLMBGKMYITAKTCLGRAATLR6KRSGACRCRANGSLPNVLMZC5WJVZXIB4A3EBYBXA5RI'},
    'application': {'applicationId': 'amzn1.echo-sdk-ams.app.[unique-value-here]'}
}";
            jsonStr = jsonStr.Replace("'", "\"");
            var sess = JsonSerializer.Deserialize<AlexaSession>(jsonStr);

            Assert.IsNotNull(sess);
            Assert.IsFalse(sess.New);
            Assert.IsFalse(string.IsNullOrEmpty(sess.SessionId));
            Assert.IsNotNull(sess.User);
            Assert.IsNotNull(sess.Application);
            Assert.IsNotNull(sess.Attributes);
            Assert.AreEqual(0, sess.Attributes.Count);

        }

        [Test]
        public void Application_CanDeserialize()
        {
            var appId = "amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5";
            var appStr = $"{{'applicationId': '{appId}'}}".Replace("'", "\"");
            var app = JsonSerializer.Deserialize<AlexaApplication>(appStr);

            Assert.IsNotNull(app);
            Assert.AreEqual(appId, app.ApplicationId);
        }

        [Test]
        public void User_CanDeserialize()
        {
            var appStr = "{'userId': 'amzn1.ask.account.AFP3ZWPOS2BGJR7OWJZ3DHPKMOMDS7SN3HP3B3GZPDYUVPQUNF65UGMED2LUXUORM5C7PK7RGCTLWN53FR33NJH5OZM4AOYOSJQ64N7QCSWJDZKVFZDWRJKXBDJVWY4TWTLIULKKGJMUEMJSLMBGKMYITAKTCLGRAATLR6KRSGACRCRANGSLPNVLMZC5WJVZXIB4A3EBYBXA5RI'}".Replace("'", "\"");
            var usr = JsonSerializer.Deserialize<AlexaUser>(appStr);
            Assert.IsNotNull(usr);
            Assert.IsTrue(usr.UserID.StartsWith("amzn1.ask"));
            Assert.IsTrue(string.IsNullOrEmpty(usr.AccessToken));
        }

    }
}
