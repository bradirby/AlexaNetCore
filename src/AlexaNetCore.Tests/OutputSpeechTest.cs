using System;
using System.Text.Json;
using AlexaNetCore;
using AlexaNetCore.Model;
using NUnit.Framework;

namespace AlexaNetCore.Tests
{

    public class OutputSpeechTest
    {
        [Test]
        public void GetJson_TypeProperty()
        {
            var c = new AlexaOutputSpeech(AlexaLocale.English_US);
            var obj = c.CreateAlexaResponse(AlexaLocale.English_US);
            Assert.IsNull(obj);  //if no text, should get null

            c.SpeechType = AlexaOutputSpeechType.PlainText;
            var a = Guid.NewGuid().ToString();
            c.SetText(a);
            var json = Serialize(c.CreateAlexaResponse(AlexaLocale.English_US));
            Assert.IsTrue(json.Contains(a));
            Assert.IsFalse(json.Contains("SSML"));
            Assert.IsTrue(json.Contains("PlainText"));

            c.SpeechType = AlexaOutputSpeechType.SSML;
            json = Serialize(c.CreateAlexaResponse(AlexaLocale.English_US));
            Assert.IsTrue(json.Contains(a));
            Assert.IsTrue(json.Contains("SSML"));
            Assert.IsFalse(json.Contains("PlainText"));


        }


        private string Serialize(dynamic obj)
        {
            string outputStr = JsonSerializer.Serialize(obj);
            outputStr = outputStr.Replace(@"\\", "");
            return outputStr;
        }
    }
}
