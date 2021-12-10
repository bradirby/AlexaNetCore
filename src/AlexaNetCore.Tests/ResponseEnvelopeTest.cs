﻿using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using AlexaNetCore;
using NUnit.Framework;

namespace AlexaNetCore.Tests
{
    public class ResponseEnvelopeTest
    {
        [Test]
        public void CreateAlexaResponse_FormatIsCorrect()
        {
            // Arrange
            var reqEnv = JsonSerializer.Deserialize<AlexaSkillRequestEnvelope>(AmazonIntentSampleRequests.LaunchRequest());
            var respEnv = new AlexaSkillResponseEnvelope(reqEnv, new ConsoleMessageLogger());
            respEnv.Version = "1.2";
            respEnv.SetOutputSpeech("Hello From Brad");
            respEnv.Response.OutputSpeech.SpeechType = AlexaOutputSpeechType.PlainText;
            respEnv.Response.Reprompt.OutputSpeech.SpeechType = AlexaOutputSpeechType.PlainText;
            respEnv.Response.Reprompt.OutputSpeech.SetText("Anything else I can do?");
            respEnv.Response.ShouldEndSession = true;

            // Act
            var outputObj = respEnv.CreateAlexaResponse(null);
            var outputStr = outputObj.ToString();

            // Assert
            //Assert.IsFalse(outputStr.IndexOf(@"""") > 0);
            Assert.IsFalse(outputStr.IndexOf("Response") > 0); //case sensitive search
            Assert.IsFalse(outputStr.IndexOf("Version") > 0); //case sensitive search
            Assert.IsFalse(outputStr.IndexOf("SessionAttributes") > 0); //case sensitive search
            Assert.IsFalse(outputStr.IndexOf("Card") > 0); //case sensitive search
            Assert.IsFalse(outputStr.IndexOf("Reprompt") > 0); //case sensitive search
            Assert.IsFalse(outputStr.IndexOf("ShouldEndSession") > 0); //case sensitive search
            Assert.IsFalse(outputStr.IndexOf("Locale") > 0); //case sensitive search
            Assert.IsFalse(outputStr.IndexOf("TimeStamp") > 0); //case sensitive search
            Assert.IsFalse(outputStr.IndexOf("timeStamp") > 0); //case sensitive search
            Assert.IsFalse(outputStr.IndexOf("RequestId") > 0); //case sensitive search
            Assert.IsFalse(outputStr.IndexOf("OutputSpeech") > 0); //case sensitive search
            Assert.IsFalse(outputStr.IndexOf("[") > 0); //case sensitive search
            Assert.IsFalse(outputStr.IndexOf("]") > 0); //case sensitive search
        }

        [Test]
        public void CreateAlexaResponse_ServiceSimulatorTest()
        {
            // Arrange
            var req = JsonSerializer.Deserialize<AlexaSkillRequestEnvelope>(AmazonIntentSampleRequests.LaunchRequest());
            var resp = new AlexaSkillResponseEnvelope(req, new ConsoleMessageLogger());
            resp.Version = "1.2";
            resp.Response.OutputSpeech.SetText("Hello From Brad");
            resp.Response.OutputSpeech.SpeechType = AlexaOutputSpeechType.PlainText;
            resp.Response.Reprompt.OutputSpeech.SpeechType = AlexaOutputSpeechType.PlainText;
            resp.Response.Reprompt.OutputSpeech.SetText("Anything else I can do?");
            resp.Response.ShouldEndSession = true;

            // Act
            var outputObj = resp.CreateAlexaResponse(null);
            var outputStr = outputObj.ToString();

            // Assert
            //Assert.IsFalse(outputStr.ToString().IndexOf(@"""") > 0);
        }


        [Test]
        public void CreateAlexaResponse_AirportInfoSFO_BadRequest()
        {
            // Arrange
            var req = JsonSerializer.Deserialize<AlexaSkillRequestEnvelope>(AirportInfoRequests.AirportInfoSFO_GoodRequest());
            var resp = new AlexaSkillResponseEnvelope(req, new ConsoleMessageLogger());
            resp.Version = "1.0";
            resp.Response.OutputSpeech.SpeechType = AlexaOutputSpeechType.SSML;
            resp.Response.OutputSpeech.SetText(
                "<speak>There is currently no delay at San Francisco International. The current weather conditions are A Few Clouds, 70.0 F (21.1 C) and wind Northwest at 13.8mph.</speak>");

            resp.Response.Reprompt.OutputSpeech.SpeechType = AlexaOutputSpeechType.PlainText;
            resp.Response.Reprompt.OutputSpeech.SetText("Anything else I can do?");
            resp.Response.ShouldEndSession = true;

            // Act
            var outputObj = resp.CreateAlexaResponse(null);

            // Assert
            Assert.IsNotNull(outputObj);
        }



    }
}
