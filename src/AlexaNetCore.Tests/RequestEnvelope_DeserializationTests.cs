using System;
using System.Linq;
using System.Text.Json;
using AlexaSkillDotNet;
using NUnit.Framework;

namespace AlexaSkillDotNet.Tests
{
    public class RequestEnvelope_DeserializationTests
    {
        [Test]
        public void LaunchRequestTest()
        {
            // Arrange


            // Act
            var req = JsonSerializer.Deserialize<AlexaSkillRequestEnvelope>(AmazonIntentSampleRequests.LaunchRequest());

            // Assert
            Assert.AreEqual(req.Version, "1.0");

            var sess = req.Session;
            Assert.IsNotNull(sess);
            Assert.AreEqual(true, sess.New);

            Assert.AreEqual("SessionId.3f1f8f0d-3c68-41f0-b24e-25c0bd1743da", sess.SessionId);
            Assert.AreEqual("amzn1.ask.skill.8323c433-7db7-44b2-97c1-1126f5cfc5f5", sess.Application.ApplicationId);
            Assert.AreEqual(0, sess.Attributes.Count);
            Assert.AreEqual("amzn1.ask.account.AFP3ZWPOS2BGJR7OWJZ3DHPKMOMDS7SN3HP3B3GZPDYUVPQUNF65UGMED2LUXUORM5C7PK7RGCTLWN53FR33NJH5OZM4AOYOSJQ64N7QCSWJDZKVFZDWRJKXBDJVWY4TWTLIULKKGJMUEMJSLMBGKMYITAKTCLGRAATLR6KRSGACRCRANGSLPNVLMZC5WJVZXIB4A3EBYBXA5RI", sess.User.UserID);
            Assert.AreEqual(null, sess.User.AccessToken);

            Assert.AreEqual(AlexaRequestType.LaunchRequest, req.Request.RequestType);
            Assert.AreEqual("EdwRequestId.d2abdc61-3726-4341-aebb-51c9aa995c42", req.Request.RequestId);
            Assert.AreEqual(DateTime.Parse("2016-08-30T03:01:27Z").ToUniversalTime(), req.Request.TimeStamp.ToUniversalTime());
        }

        [Test]
        [Ignore("need better test data")]
        public void IntentRequestTest()
        {
            //https://developer.amazon.com/public/solutions/alexa/alexa-skills-kit/docs/alexa-skills-kit-interface-reference

            // Act
            var req = JsonSerializer.Deserialize<AlexaSkillRequestEnvelope>(AmazonIntentSampleRequests.SessionEndedRequest());

            // Assert
            Assert.AreEqual(req.Version, "1.0");
            Assert.AreEqual(req.Session.New, false);
            Assert.AreEqual("session1234", req.Session.SessionId);
            Assert.AreEqual("amzn1.echo-sdk-ams.app.[unique-value-here]", req.Session.Application.ApplicationId);
            Assert.AreEqual(null, req.Session.User.UserID);
            Assert.AreEqual(AlexaRequestType.SessionEndedRequest, req.Request.RequestType);
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
            var req = JsonSerializer.Deserialize<AlexaSkillRequestEnvelope>(AmazonIntentSampleRequests.SessionEndedRequest());

            // Assert
            Assert.AreEqual(req.Version, "1.0");
            Assert.AreEqual(req.Session.New, false);
            Assert.AreEqual("session1234", req.Session.SessionId);
            Assert.AreEqual("amzn1.echo-sdk-ams.app.[unique-value-here]", req.Session.Application.ApplicationId);
            //Assert.AreEqual("amzn1.account.AM3B00000000000000000000000", req.SessionAttributes.User.UserID);
            Assert.AreEqual(AlexaRequestType.SessionEndedRequest, req.Request.RequestType);
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
            var reqEnv = JsonSerializer.Deserialize<AlexaSkillRequestEnvelope>(FavoriteColorRequests.WhatIsMyFavoriteColor());

            // Assert
            Assert.AreEqual("1.0", reqEnv.Version);

            var req = reqEnv.Request;
            Assert.IsNotNull(req);
            Assert.AreEqual("en-US", req.LocaleString);
            Assert.AreEqual(AlexaRequestType.IntentRequest, req.RequestType);
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
            var req = JsonSerializer.Deserialize<AlexaSkillRequestEnvelope>(AirportInfoRequests.AirportInfoSFO_BadRequest());

            // Assert
            Assert.AreEqual("1.0", req.Version);
            Assert.AreEqual("en-US", req.Request.LocaleString);
            Assert.AreEqual(true, req.Session.New);
            Assert.AreEqual("SessionId.86e83b44-ab46-49c8-98c5-73d9b2f141c5", req.Session.SessionId);
            Assert.AreEqual("amzn1.echo-sdk-ams.app.AVKBEKZBEGRTZ2RGIETZJTOSIRJODK774H", req.Session.Application.ApplicationId);
            Assert.AreEqual("amzn1.ask.account.XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", req.Session.User.UserID);
            Assert.AreEqual(AlexaRequestType.IntentRequest, req.Request.RequestType);
            Assert.AreEqual("EdwRequestId.5959a778-9033-4be0-9e77-96d8aec7c75e", req.Request.RequestId);
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
            var req = JsonSerializer.Deserialize<AlexaSkillRequestEnvelope>(AirportInfoRequests.AirportInfoSFO_GoodRequest());

            // Assert
            Assert.AreEqual("1.0", req.Version);
            Assert.AreEqual("en-US", req.Request.LocaleString);
            Assert.AreEqual(true, req.Session.New);
            Assert.AreEqual("SessionId.58ac99fd-73b2-49bf-b72f-5d8449850762", req.Session.SessionId);
            Assert.AreEqual("amzn1.echo-sdk-ams.app.AVKBEKZBEGRTZ2RGIETZJTOSIRJODK774H", req.Session.Application.ApplicationId);
            Assert.AreEqual("amzn1.ask.account.XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", req.Session.User.UserID);
            Assert.AreEqual(AlexaRequestType.IntentRequest, req.Request.RequestType);
            Assert.AreEqual("EdwRequestId.7991ec0f-9298-4bb4-961a-e1f29e09d3a7", req.Request.RequestId);
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
            var req = JsonSerializer.Deserialize<AlexaSkillRequestEnvelope>(FavoriteColorRequests.FavoriteColor_Hello_Request());

            // Assert
            Assert.AreEqual("1.0", req.Version);
            Assert.AreEqual("en-US", req.Request.LocaleString);
            Assert.AreEqual(true, req.Session.New);
            Assert.AreEqual("SessionId.faa3dca9-1669-48ce-a032-785c0b1c4f4f", req.Session.SessionId);
            Assert.AreEqual("amzn1.echo-sdk-ams.app.AVKBEKZBEGRTZ2RGIETZJTOSIRJODK774H", req.Session.Application.ApplicationId);
            Assert.AreEqual("amzn1.ask.account.XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", req.Session.User.UserID);
            Assert.AreEqual(AlexaRequestType.IntentRequest, req.Request.RequestType);
            Assert.AreEqual("EdwRequestId.cf8eddaf-9aad-465d-9743-063381815dd7", req.Request.RequestId);
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
            var req = JsonSerializer.Deserialize<AlexaSkillRequestEnvelope>(FavoriteColorRequests.FavoriteColor_ColorIsRed_Request());

            // Assert
            Assert.AreEqual("1.0", req.Version);
            Assert.AreEqual("en-US", req.Request.LocaleString);
            Assert.AreEqual(false, req.Session.New);
            Assert.AreEqual("SessionId.faa3dca9-1669-48ce-a032-785c0b1c4f4f", req.Session.SessionId);
            Assert.AreEqual("amzn1.echo-sdk-ams.app.AVKBEKZBEGRTZ2RGIETZJTOSIRJODK774H", req.Session.Application.ApplicationId);
            Assert.AreEqual("amzn1.ask.account.XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", req.Session.User.UserID);
            Assert.AreEqual(AlexaRequestType.IntentRequest, req.Request.RequestType);
            Assert.AreEqual("EdwRequestId.710051f7-8847-43ca-9a63-7bf5c488ecf5", req.Request.RequestId);
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
            var req = JsonSerializer.Deserialize<AlexaSkillRequestEnvelope>(FavoriteColorRequests.FavoriteColor_WhatIsColor_Request());

            // Assert
            Assert.AreEqual("1.0", req.Version);
            Assert.AreEqual("en-US", req.Request.LocaleString);
            Assert.AreEqual(false, req.Session.New);
            Assert.AreEqual("SessionId.faa3dca9-1669-48ce-a032-785c0b1c4f4f", req.Session.SessionId);
            Assert.AreEqual("amzn1.echo-sdk-ams.app.AVKBEKZBEGRTZ2RGIETZJTOSIRJODK774H", req.Session.Application.ApplicationId);
            Assert.AreEqual("amzn1.ask.account.XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", req.Session.User.UserID);
            Assert.AreEqual(AlexaRequestType.IntentRequest, req.Request.RequestType);
            Assert.AreEqual("EdwRequestId.dc00d105-a609-4579-9f0c-64ef540667cc", req.Request.RequestId);
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

        [Test]
        public void GetIntentHistory_EmptyHistory_ReturnsEmptyList()
        {
            // arrange
            var req = JsonSerializer.Deserialize<AlexaSkillRequestEnvelope>(AmazonIntentSampleRequests.EmptyRequest());

            //act
            var history = req.GetIntentHistory();

            //assert
            Assert.IsNotNull(history);
            Assert.AreEqual(0, history.Count);

        }

        [Test]
        [Ignore("history is not working yet")]
        public void GetIntentHistory_TwoItemHistory_ReadsHistoryCorrectly()
        {
            // arrange
            var req = JsonSerializer.Deserialize<AlexaSkillRequestEnvelope>(AmazonIntentSampleRequests.AMAZONStopIntent());

            //act
            var history = req.GetIntentHistory();

            //assert
            Assert.IsNotNull(history);
            Assert.AreEqual(3, history.Count);
            Assert.AreEqual("intent1", history[1]);
            Assert.AreEqual("intent2", history[2]);
            Assert.AreEqual("intent3", history[3]);

        }

    }
}
