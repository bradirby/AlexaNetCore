using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using AlexaNetCore.Model;
using AlexaNetCore.RequestModel;
using NUnit.Framework;

namespace AlexaNetCore.Tests
{
    public class ResponseEnvelopeTest
    {
        [Test]
        public void CreateAlexaResponse_FormatIsCorrect()
        {
            // Arrange
            var reqEnv = JsonSerializer.Deserialize<AlexaRequestEnvelope>(GenericSkillRequests.LaunchRequest());
            var respEnv = new AlexaResponseEnvelope(reqEnv);
            respEnv.Version = "1.2";
            respEnv.Speak("Hello From Brad");
            respEnv.Reprompt("Anything else I can do?", AlexaOutputSpeechType.PlainText);
            respEnv.ShouldEndSession = true;

            // Act
            var outputObj = respEnv.CreateAlexaResponse();
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
            var req = JsonSerializer.Deserialize<AlexaRequestEnvelope>(GenericSkillRequests.LaunchRequest());
            var resp = new AlexaResponseEnvelope(req);
            resp.Version = "1.2";
            resp.Speak("Hello From Brad");
            resp.Reprompt("Anything else I can do?");
            resp.ShouldEndSession = true;

            // Act
            var outputObj = resp.CreateAlexaResponse();
            var outputStr = outputObj.ToString();

            // Assert
            //Assert.IsFalse(outputStr.ToString().IndexOf(@"""") > 0);
        }


        [Test]
        public void CreateAlexaResponse_AirportInfoSFO_BadRequest()
        {
            // Arrange
            var req = JsonSerializer.Deserialize<AlexaRequestEnvelope>(AirportInfoRequests.AirportInfoSFO_GoodRequest());
            var resp = new AlexaResponseEnvelope(req);
            resp.Version = "1.0";
            resp.Speak(
                "<speak>There is currently no delay at San Francisco International. The current weather conditions are A Few Clouds, 70.0 F (21.1 C) and wind Northwest at 13.8mph.</speak>", AlexaOutputSpeechType.SSML);

            resp.Reprompt("Anything else I can do?");
            resp.ShouldEndSession = true;

            // Act
            var outputObj = resp.CreateAlexaResponse();

            // Assert
            Assert.IsNotNull(outputObj);
        }



    }
}
