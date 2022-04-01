using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using NUnit.Framework;

namespace AlexaNetCore.Tests
{
    public class RequestEnvelope_DeSerizliaztionTests_LaunchRequestParsing
    {

        [Test]
        public void Version()
        {
            var req = JsonSerializer.Deserialize<AlexaSkillRequestEnvelope>(ApprovalSubmissionSampleRequests.LaunchRequest2());
            Assert.AreEqual("1.0", req.Version);
        }

        [Test]
        public void Session()
        {
            var req = JsonSerializer.Deserialize<AlexaSkillRequestEnvelope>(ApprovalSubmissionSampleRequests.LaunchRequest2());
            Assert.AreEqual(true, req.Session.New);
            Assert.AreEqual("amzn1.echo-api.session.XXXXXXXXXXXXXXXXXX", req.Session.SessionId);
            Assert.AreEqual("amzn1.ask.skill.XXXXXXXXXXXXXXXXXX", req.Session.Application.ApplicationId);
            Assert.AreEqual(false, req.Session.Attributes.Any());
            Assert.AreEqual("amzn1.ask.account.XXXXXXXXXXXXXXXXXX", req.Session.User.UserID);

        }

        [Test]
        public void Request()
        {
            var req = JsonSerializer.Deserialize<AlexaSkillRequestEnvelope>(ApprovalSubmissionSampleRequests.LaunchRequest2());
            Assert.AreEqual("LaunchRequest", req.Request.RequestType);
            Assert.AreEqual("amzn1.echo-api.request.XXXXXXXXXXXXXXXXXX", req.Request.RequestId);
            Assert.AreEqual("en-US", req.Request.LocaleString);
            Assert.AreEqual(DateTime.Parse("2021-09-24T10:52:31"), req.Request.TimeStamp);
            Assert.AreEqual(false, req.Request.ShouldLinkResultBeReturned);

        }

        
        [Test]
        public void Context_Viewport()
        {
            var req = JsonSerializer.Deserialize<AlexaSkillRequestEnvelope>(ApprovalSubmissionSampleRequests.LaunchRequest2());
            Assert.AreEqual("HUB", req.Context.Viewport.Mode);
            Assert.AreEqual("RECTANGLE", req.Context.Viewport.Shape);
            Assert.AreEqual(1280, req.Context.Viewport.PixelWidth);
            Assert.AreEqual(800, req.Context.Viewport.PixelHeight);
            Assert.AreEqual(1, req.Context.Viewport.Touch.Count);
            Assert.AreEqual("SINGLE", req.Context.Viewport.Touch.First());
            Assert.AreEqual(2, req.Context.Viewport.Video.Codecs.Count);
            Assert.IsNotNull(req.Context.Viewport.Video.Codecs.First(c => c == "H_264_42"));
            Assert.IsNotNull(req.Context.Viewport.Video.Codecs.First(c => c == "H_264_41"));
        }

        [Test]
        public void Context_Viewport_Experiences()
        {
            var req = JsonSerializer.Deserialize<AlexaSkillRequestEnvelope>(ApprovalSubmissionSampleRequests.LaunchRequest2());
            Assert.AreEqual(1, req.Context.Viewport.Experiences.Count);
            Assert.IsNotNull(req.Context.Viewport.Experiences.First(e => e.ArcMinuteWidth == 346));
            Assert.IsNotNull(req.Context.Viewport.Experiences.First(e => e.ArcMinuteHeight == 216));
            Assert.IsNotNull(req.Context.Viewport.Experiences.First(e => !e.CanRotate));
            Assert.IsNotNull(req.Context.Viewport.Experiences.First(e => !e.CanResize));
        }

        [Test]
        public void Context_Viewport_System()
        {
            var req = JsonSerializer.Deserialize<AlexaSkillRequestEnvelope>(ApprovalSubmissionSampleRequests.LaunchRequest2());
            Assert.AreEqual("amzn1.ask.skill.XXXXXXXXXXXXXXXXXX", req.Context.System.Application.ApplicationId);
            Assert.AreEqual("amzn1.ask.account.XXXXXXXXXXXXXXXXXX", req.Context.System.User.UserID);
            Assert.AreEqual("amzn1.ask.device.XXXXXXXXXXXXXXXXXX", req.Context.System.Device.Id);
            Assert.AreEqual("https://api.amazonalexa.com", req.Context.System.ApiEndpoint);
            Assert.AreEqual("XXXXXXXXXXXXXXXXXX", req.Context.System.ApiAccessToken);
        }
    }
}
