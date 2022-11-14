using System;
using System.Linq;
using System.Text.Json;
using AlexaNetCore.RequestModel;
using NUnit.Framework;

namespace AlexaNetCore.Tests
{
    public class RequestEnvelope_DeserializationTests
    {
        [Test]
        public void LaunchRequestTest()
        {
            var req = JsonSerializer.Deserialize<AlexaRequestEnvelope>(GenericSkillRequests.LaunchRequest());

            Assert.AreEqual(req.Version, "1.0");

            var sess = req.Session;
            Assert.IsNotNull(sess);
            Assert.AreEqual(true, sess.New);

            Assert.AreEqual("amzn1.echo-api.session.XXXXXXXXXXXXXXXXXX", sess.SessionId);
            Assert.AreEqual("amzn1.ask.skill.XXXXXXXXXXXXXXXXXX", sess.Application.ApplicationId);
            Assert.AreEqual(0, sess.Attributes.Count);
            Assert.AreEqual("amzn1.ask.account.XXXXXXXXXXXXXXXXXX", sess.User.UserID);
            Assert.AreEqual(null, sess.User.AccessToken);

            Assert.AreEqual("amzn1.echo-api.request.XXXXXXXXXXXXXXXXXX", req.Request.RequestId);
            Assert.AreEqual(DateTime.Parse("2021-09-24T10:52:31Z").ToUniversalTime(), req.Request.TimeStamp.ToUniversalTime());
        }

        [Test]
        [Ignore("need better test data")]
        public void IntentRequestTest()
        {
            //https://developer.amazon.com/public/solutions/alexa/alexa-skills-kit/docs/alexa-skills-kit-interface-reference

            // Act
            var req = JsonSerializer.Deserialize<AlexaRequestEnvelope>(GenericSkillRequests.EndSession());

            // Assert
            Assert.AreEqual(req.Version, "1.0");
            Assert.AreEqual(req.Session.New, false);
            Assert.AreEqual("session1234", req.Session.SessionId);
            Assert.AreEqual("amzn1.echo-sdk-ams.app.[unique-value-here]", req.Session.Application.ApplicationId);
            Assert.AreEqual(null, req.Session.User.UserID);
            Assert.AreEqual("request5678", req.Request.RequestId);
            Assert.AreEqual(DateTime.Parse("2015-05-13T12:34:56Z").ToUniversalTime(), req.Request.TimeStamp.ToUniversalTime());
            Assert.AreEqual(req.Request.Intent.Name, "GetZodiacHoroscopeIntent");

            //check attributes
            Assert.AreEqual(3 , req.Session.Attributes.Count);
            var attr = req.Session.Attributes.First();
            Assert.AreEqual(attr.Key, "HoroscopePeriod-daily");

            var attrSettings = attr.Value;
            //Assert.AreEqual(3, attrSettings.Count);
            //Assert.IsTrue(attrSettings.Keys.Contains("daily"));
            //Assert.IsTrue(attrSettings.Keys.Contains("weekly"));
            //Assert.IsTrue(attrSettings.Keys.Contains("monthly"));

            //Assert.AreEqual("True", attrSettings["daily"]);
            //Assert.AreEqual("False", attrSettings["weekly"]);
            //Assert.AreEqual("False", attrSettings["monthly"]);

            //check slots
            Assert.AreEqual(req.Request.Intent.Slots.Count, 1);
            var slotEntry = req.Request.Intent.Slots.First();
            Assert.AreEqual(slotEntry.Key, "ZodiacSign");

            var slot = slotEntry.Value;
            Assert.AreEqual("ZodiacSign", slot.Name);
            Assert.AreEqual("virgo", slot.Value);
        }


        [Test]
        [Ignore("need better test data")]
        public void SessionEndRequestTest()
        {
            // Act
            var req = JsonSerializer.Deserialize<AlexaRequestEnvelope>(GenericSkillRequests.EndSession());

            // Assert
            Assert.AreEqual(req.Version, "1.0");
            Assert.AreEqual(req.Session.New, false);
            Assert.AreEqual("session1234", req.Session.SessionId);
            Assert.AreEqual("amzn1.echo-sdk-ams.app.[unique-value-here]", req.Session.Application.ApplicationId);
            //Assert.AreEqual("amzn1.account.AM3B00000000000000000000000", req.SessionAttributes.User.UserID);
            Assert.AreEqual("request5678", req.Request.RequestId);
            //Assert.AreEqual(DateTime.Parse("2015-05-13T12:34:56Z").ToUniversalTime(), req.Request.TimeStamp.ToUniversalTime());
            //Assert.AreEqual(req.Request.Reason, "USER_INITIATED");


            //check attributes
            Assert.AreEqual(3, req.Session.Attributes.Count);
            var attr = req.Session.Attributes.First();
            Assert.AreEqual(attr.Key, "HoroscopePeriod-daily");

            var attrSettings = attr.Value;
            //Assert.AreEqual(3, attrSettings.Count);
            //Assert.IsTrue(attrSettings.Keys.Contains("daily"));
            //Assert.IsTrue(attrSettings.Keys.Contains("weekly"));
            //Assert.IsTrue(attrSettings.Keys.Contains("monthly"));

            //Assert.AreEqual("True", attrSettings["daily"]);
            //Assert.AreEqual("False", attrSettings["weekly"]);
            //Assert.AreEqual("False", attrSettings["monthly"]);


        }

        [Test]
        public void WhatIsMyFavoriteColor()
        {

            // Act
            var reqEnv = JsonSerializer.Deserialize<AlexaRequestEnvelope>(FavoriteColorRequests.WhatIsMyFavoriteColor());

            // Assert
            Assert.AreEqual("1.0", reqEnv.Version);

            var req = reqEnv.Request;
            Assert.IsNotNull(req);
            Assert.AreEqual("en-US", req.LocaleString);
            Assert.AreEqual("amzn1.echo-api.request.0000000-0000-0000-0000-00000000000", req.RequestId);
            Assert.AreEqual(DateTime.Parse("2016-07-02T17:09:37Z").ToUniversalTime(), req.TimeStamp.ToUniversalTime());

            var sess = reqEnv.Session;
            Assert.IsNotNull(sess);
            Assert.AreEqual(true, sess.New);
            Assert.AreEqual(sess.SessionId, "SessionId.0000000-0000-0000-0000-00000000000");
            Assert.AreEqual(0, sess.Attributes.Count);

            var app = sess.Application;
            Assert.IsNotNull(app);
            Assert.AreEqual(app.ApplicationId, "amzn1.echo-sdk-ams.app.000000-d0ed-0000-ad00-000000d00ebe");

            var usr = sess.User;
            Assert.IsNotNull(usr);
            Assert.AreEqual(usr.UserID, "amzn1.account.AM3B00000000000000000000000");
            

            //check slots
            var intent = req.Intent;
            Assert.IsNotNull(intent);
            Assert.AreEqual("MyColorIsIntent", intent.Name);
            Assert.AreEqual(1, intent.Slots.Count);

            var firstSlot = intent.Slots.First();
            Assert.AreEqual("Color", firstSlot.Key);

            var slotValue = firstSlot.Value;
            Assert.AreEqual("Color", slotValue.Name);


        }
        

        [Test]
        public void AirportInfoSFO_BadRequest()
        {
            // Act
            var req = JsonSerializer.Deserialize<AlexaRequestEnvelope>(AirportInfoRequests.AirportInfoSFO_BadRequest());

            // Assert
            Assert.AreEqual("1.0", req.Version);
            Assert.AreEqual("en-US", req.Request.LocaleString);
            Assert.AreEqual(true, req.Session.New);
            Assert.AreEqual("SessionId.XXXXXXXXXXXXXXXXXX", req.Session.SessionId);
            Assert.AreEqual("amzn1.echo-sdk-ams.app.XXXXXXXXXXXXXXXXXX", req.Session.Application.ApplicationId);
            Assert.AreEqual("amzn1.ask.account.XXXXXXXXXXXXXXXXXX", req.Session.User.UserID);
            Assert.AreEqual("EdwRequestId.XXXXXXXXXXXXXXXXXX", req.Request.RequestId);
            Assert.AreEqual(DateTime.Parse("2016-07-03T01:48:34Z").ToUniversalTime(), req.Request.TimeStamp.ToUniversalTime());
            Assert.AreEqual(0, req.Session.Attributes.Count);
            Assert.AreEqual("airportinfo", req.Request.Intent.Name);


            //check slots
            Assert.AreEqual(1, req.Request.Intent.Slots.Count);
            var slot = req.Request.Intent.Slots.First();
            Assert.AreEqual("AIRPORTCODE", slot.Key);

            var slotValue = slot.Value;
            Assert.AreEqual("AIRPORTCODE", slotValue.Name);
            Assert.AreEqual("how is sfo", slotValue.Value);


        }

        [Test]
        public void AirportInfoSFO_Goodrequest()
        {
            // Act
            var req = JsonSerializer.Deserialize<AlexaRequestEnvelope>(AirportInfoRequests.AirportInfoSFO_GoodRequest());

            // Assert
            Assert.AreEqual("1.0", req.Version);
            Assert.AreEqual("en-US", req.Request.LocaleString);
            Assert.AreEqual(true, req.Session.New);
            Assert.AreEqual("SessionId.XXXXXXXXXXXXXXXXXX", req.Session.SessionId);
            Assert.AreEqual("amzn1.echo-sdk-ams.app.XXXXXXXXXXXXXXXXXX", req.Session.Application.ApplicationId);
            Assert.AreEqual("amzn1.ask.account.XXXXXXXXXXXXXXXXXX", req.Session.User.UserID);
            Assert.AreEqual("EdwRequestId.XXXXXXXXXXXXXXXXXX", req.Request.RequestId);
            Assert.AreEqual(DateTime.Parse("2016-07-03T01:57:46Z").ToUniversalTime(), req.Request.TimeStamp.ToUniversalTime());
            Assert.AreEqual(0, req.Session.Attributes.Count);
            Assert.AreEqual("airportinfo", req.Request.Intent.Name);


            //check slots
            Assert.AreEqual(1, req.Request.Intent.Slots.Count);
            var slot = req.Request.Intent.Slots.First();
            Assert.AreEqual("AIRPORTCODE", slot.Key);

            var slotValue = slot.Value;
            Assert.AreEqual("AIRPORTCODE", slotValue.Name);
            Assert.AreEqual("sfo", slotValue.Value);


        }


        [Test]
        public void FavoriteColor_Hello_Request()
        {
            // Act
            var req = JsonSerializer.Deserialize<AlexaRequestEnvelope>(FavoriteColorRequests.FavoriteColor_Hello_Request());

            // Assert
            Assert.AreEqual("1.0", req.Version);
            Assert.AreEqual("en-US", req.Request.LocaleString);
            Assert.AreEqual(true, req.Session.New);
            Assert.AreEqual("SessionId.XXXXXXXXXXXXXXXXXX", req.Session.SessionId);
            Assert.AreEqual("amzn1.echo-sdk-ams.app.XXXXXXXXXXXXXXXXXX", req.Session.Application.ApplicationId);
            Assert.AreEqual("amzn1.ask.account.XXXXXXXXXXXXXXXXXX", req.Session.User.UserID);
            Assert.AreEqual("EdwRequestId.XXXXXXXXXXXXXXXXXX", req.Request.RequestId);
            Assert.AreEqual(DateTime.Parse("2016-07-03T04:07:49Z").ToUniversalTime(), req.Request.TimeStamp.ToUniversalTime());
            Assert.AreEqual(0, req.Session.Attributes.Count);
            Assert.AreEqual("WhatsMyColorIntent", req.Request.Intent.Name);


            //check slots
            Assert.AreEqual(0, req.Request.Intent.Slots.Count);


        }


        [Test]
        public void FavoriteColor_ColorIsRed_Request()
        {
            // Act
            var req = JsonSerializer.Deserialize<AlexaRequestEnvelope>(FavoriteColorRequests.FavoriteColor_ColorIsRed_Request());

            // Assert
            Assert.AreEqual("1.0", req.Version);
            Assert.AreEqual("en-US", req.Request.LocaleString);
            Assert.AreEqual(false, req.Session.New);
            Assert.AreEqual("SessionId.XXXXXXXXXXXXXXXXXX", req.Session.SessionId);
            Assert.AreEqual("amzn1.echo-sdk-ams.app.XXXXXXXXXXXXXXXXXX", req.Session.Application.ApplicationId);
            Assert.AreEqual("amzn1.ask.account.XXXXXXXXXXXXXXXXXX", req.Session.User.UserID);
            Assert.AreEqual("EdwRequestId.XXXXXXXXXXXXXXXXXX", req.Request.RequestId);
            Assert.AreEqual(DateTime.Parse("2016-07-03T04:10:26Z").ToUniversalTime(), req.Request.TimeStamp.ToUniversalTime());
            Assert.AreEqual(0, req.Session.Attributes.Count);
            Assert.AreEqual("MyColorIsIntent", req.Request.Intent.Name);


            //check slots
            Assert.AreEqual(1, req.Request.Intent.Slots.Count);
            var slot = req.Request.Intent.Slots.First();
            Assert.AreEqual("Color", slot.Key);

            var slotValue = slot.Value;
            Assert.AreEqual("Color", slotValue.Name);
            Assert.AreEqual("red", slotValue.Value);


        }



        [Test]
        public void FavoriteColor_WhatIsColor_Request()
        {
            // Act
            var req = JsonSerializer.Deserialize<AlexaRequestEnvelope>(FavoriteColorRequests.FavoriteColor_WhatIsColor_Request());

            // Assert
            Assert.AreEqual("1.0", req.Version);
            Assert.AreEqual("en-US", req.Request.LocaleString);
            Assert.AreEqual(false, req.Session.New);
            Assert.AreEqual("SessionId.XXXXXXXXXXXXXXXXXX", req.Session.SessionId);
            Assert.AreEqual("amzn1.echo-sdk-ams.app.XXXXXXXXXXXXXXXXXX", req.Session.Application.ApplicationId);
            Assert.AreEqual("amzn1.ask.account.XXXXXXXXXXXXXXXXXX", req.Session.User.UserID);
            Assert.AreEqual("EdwRequestId.XXXXXXXXXXXXXXXXXX", req.Request.RequestId);
            Assert.AreEqual(DateTime.Parse("2016-07-03T04:11:59Z").ToUniversalTime(), req.Request.TimeStamp.ToUniversalTime());
            Assert.AreEqual(1, req.Session.Attributes.Count);
            Assert.AreEqual("WhatsMyColorIntent", req.Request.Intent.Name);


            //check slots
            Assert.AreEqual(0, req.Request.Intent.Slots.Count);
            //var slot = req.Request.Intent.Slots.First();
            //Assert.AreEqual("Color", slot.Key);

            //var slotValue = slot.LocaleString;
            //Assert.AreEqual("Color", slotValue.Name);
            //Assert.AreEqual("red", slotValue.LocaleString);


        }

    }
}
