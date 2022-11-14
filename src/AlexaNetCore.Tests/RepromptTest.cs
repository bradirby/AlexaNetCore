using System;
using System.Text.Json;
using AlexaNetCore;
using AlexaNetCore.Model;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace AlexaNetCore.Tests
{

    public class RepromptTest
    {
        private class TestSkill : AlexaSkillBase
        {
            public TestSkill(ILoggerFactory loggerFactory) : base(loggerFactory)
            {

            }
        }


        [Test]
        public void GetJson_TypeProperty()
        {
            var c = new AlexaReprompt("try again");
            var obj = c.CreateAlexaResponse(AlexaLocale.English_US);
            Assert.IsNotNull(obj);  //if no text, should get null

            c.OutputSpeech.SpeechType = AlexaOutputSpeechType.PlainText;
            var a = Guid.NewGuid().ToString();
            c.OutputSpeech.SetText(a);
            var json = Serialize(c.CreateAlexaResponse(AlexaLocale.English_US));
            Assert.IsTrue(json.Contains(a));
            Assert.IsFalse(json.Contains(AlexaOutputSpeechType.SSML.ToString()));
            Assert.IsTrue(json.Contains(AlexaOutputSpeechType.PlainText.ToString()));

            c.OutputSpeech.SpeechType = AlexaOutputSpeechType.SSML;
            json = Serialize(c.CreateAlexaResponse(AlexaLocale.English_US));
            Assert.IsTrue(json.Contains(a));
            Assert.IsTrue(json.Contains(AlexaOutputSpeechType.SSML.ToString()));
            Assert.IsFalse(json.Contains(AlexaOutputSpeechType.PlainText.ToString()));
        }

      

        private string Serialize(dynamic obj)
        {
            string outputStr = JsonSerializer.Serialize(obj);
            outputStr = outputStr.Replace(@"\\", "");
            return outputStr;
        }
    }

}
