using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using NUnit.Framework;

namespace AlexaSkillDotNet.Tests
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
            Assert.AreEqual("amzn1.echo-api.session.ce498e3f-9494-4b28-b029-de6577092411", req.Session.SessionId);
            Assert.AreEqual("amzn1.ask.skill.6acd2461-06d1-44f0-ad5c-c9a16bdb8830", req.Session.Application.ApplicationId);
            Assert.AreEqual(false, req.Session.Attributes.Any());
            Assert.AreEqual("amzn1.ask.account.AGTRXT3Y3FU74LNNIASLVD6C37PZAI4IKC2FYEB3CMUM7MRUWAGVLYQQWFIGXC5LGG33ENHGY726D3TIGU25WJZTFZI6R7A52ZHPOVF6XVFGY6EWX2UNLVFXEISZFKK3AT3CKHQQZXCQC3FDNMZSDLKT7YNXHO3H5AFFX22NBENRASTIZLHZ3RLVITQXIFPLHSZZDBLV5NJABZI", req.Session.User.UserID);

        }

        [Test]
        public void Request()
        {
            var req = JsonSerializer.Deserialize<AlexaSkillRequestEnvelope>(ApprovalSubmissionSampleRequests.LaunchRequest2());
            Assert.AreEqual("LaunchRequest", req.Request.RequestType);
            Assert.AreEqual("amzn1.echo-api.request.feb4406d-01c0-4d3e-aa6f-1da6ebd717f8", req.Request.RequestId);
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
            Assert.AreEqual("amzn1.ask.skill.6acd2461-06d1-44f0-ad5c-c9a16bdb8830", req.Context.System.Application.ApplicationId);
            Assert.AreEqual("amzn1.ask.account.AGTRXT3Y3FU74LNNIASLVD6C37PZAI4IKC2FYEB3CMUM7MRUWAGVLYQQWFIGXC5LGG33ENHGY726D3TIGU25WJZTFZI6R7A52ZHPOVF6XVFGY6EWX2UNLVFXEISZFKK3AT3CKHQQZXCQC3FDNMZSDLKT7YNXHO3H5AFFX22NBENRASTIZLHZ3RLVITQXIFPLHSZZDBLV5NJABZI", req.Context.System.User.UserID);
            Assert.AreEqual("amzn1.ask.device.AEC6MAIKKWRL7EYPPCCDRKW6F6SALTUIEMLC7URKBCHYJM5BAU7IVZUUNCCY5NVHIBDS6PM2NGDQ42U66RSZE7GOC732VOZCSQWC5APXAMAPBI45N4OSF3XKSF6WERDNHF5HACPRBVHRICXTAQ2E25VAT7ZA", req.Context.System.Device.Id);
            Assert.AreEqual("https://api.amazonalexa.com", req.Context.System.ApiEndpoint);
            Assert.AreEqual("eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6IjEifQ.eyJhdWQiOiJodHRwczovL2FwaS5hbWF6b25hbGV4YS5jb20iLCJpc3MiOiJBbGV4YVNraWxsS2l0Iiwic3ViIjoiYW16bjEuYXNrLnNraWxsLjZhY2QyNDYxLTA2ZDEtNDRmMC1hZDVjLWM5YTE2YmRiODgzMCIsImV4cCI6MTYzMjQ4MTA1MSwiaWF0IjoxNjMyNDgwNzUxLCJuYmYiOjE2MzI0ODA3NTEsInByaXZhdGVDbGFpbXMiOnsiY29udGV4dCI6IkFBQUFBQUFBQUFDakhmbHlMcHdmUS8yalBNNUVKOUc0SkFFQUFBQUFBQUFaQUw0emlOQkxlWjRPSEhmSlloZmJOajdPYTJaN3lvMjFrWE5DN090a2hzQkFTLzFWMzh2MlVwWnF2L2NDcUlNZEE3MVZCVnJsSjlRR3h2L2M1UnJ5MDV3dURjV2hldTdaR2xmeHR5czdMZ0paVnM5dVBQVjd5TzViSXVzL0tVbkkxNWYxVU9lYnF3S2Y1Z0tJODhzOEM5NXVHZkVGSEVsdHVGT0FSQnZ3eW1NNzMrUGxkbFREVFNBN0IzQ2lTV0xHWFVsSVYwdEs4U0NSVk1LTHNrdFk4dExkQzRqNVdzZ3NDWlpDNEhyNzc4bVRtT1dGRk9IcE5TQ2k4Zng3YU9WNUdIWmdlclJJZEFNb1J2cGF2RElPczY2N3ZVU2s2eW52ZStNMnJsNGtISzNXU21ROFJobGdXK2VUdWZJblZIM1RyVlBIMmpaZ0piTEZvaml1MG42dTlkSVRqeDhYZVFON2NMT1g5eFordHU2cEZEcm5XNmErcG4zNXpZc2F3VzNEME9JRiIsImNvbnNlbnRUb2tlbiI6bnVsbCwiZGV2aWNlSWQiOiJhbXpuMS5hc2suZGV2aWNlLkFFQzZNQUlLS1dSTDdFWVBQQ0NEUktXNkY2U0FMVFVJRU1MQzdVUktCQ0hZSk01QkFVN0lWWlVVTkNDWTVOVkhJQkRTNlBNMk5HRFE0MlU2NlJTWkU3R09DNzMyVk9aQ1NRV0M1QVBYQU1BUEJJNDVONE9TRjNYS1NGNldFUkROSEY1SEFDUFJCVkhSSUNYVEFRMkUyNVZBVDdaQSIsInVzZXJJZCI6ImFtem4xLmFzay5hY2NvdW50LkFHVFJYVDNZM0ZVNzRMTk5JQVNMVkQ2QzM3UFpBSTRJS0MyRllFQjNDTVVNN01SVVdBR1ZMWVFRV0ZJR1hDNUxHRzMzRU5IR1k3MjZEM1RJR1UyNVdKWlRGWkk2UjdBNTJaSFBPVkY2WFZGR1k2RVdYMlVOTFZGWEVJU1pGS0szQVQzQ0tIUVFaWENRQzNGRE5NWlNETEtUN1lOWEhPM0g1QUZGWDIyTkJFTlJBU1RJWkxIWjNSTFZJVFFYSUZQTEhTWlpEQkxWNU5KQUJaSSJ9fQ.Fr1rM2r_98V4GhYRsaX36G9iPIHiQ9wRXO_aMbS7VdqPwNicNJsmYEo0aL4mZXLusj95r95slI7OiRxyhSwFEDFZIX_9geHFnBts7zlN0j866W62CSjFt5593CkfAg36G3DLdORUnoSPSTrHBjC_tsOH2t4XeDkRJBDDqU65sMGGqbc8ivhRpzFMW4MZej7bFf54i3VvrkaF87d2OZGHEjVkMC0YCXHHSwA9ZcoA9zPIBpWtqtcZVC4Qh61sfJxg8d8vnTGoeM5R7ZE-JZsYC7DNgwE3HQ-48mMcTMwLlWlnkHEodku07YgtPENQIyiRqxNSdGETk1vQIjn2vMbVIw", req.Context.System.ApiAccessToken);
        }
    }
}
