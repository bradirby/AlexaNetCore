using System;
using System.Text.Json;
using AlexaSkillDotNet;
using NUnit.Framework;

namespace AlexaSkillDotNet.Tests
{

    public class RepromptTest
    {
        public class TestAlexaSkill : AlexaSkillBase { }

        
        [Test]
        public void GetJson_TypeProperty()
        {
            var c = new AlexaReprompt("try again",new ConsoleMessageLogger());
            var obj = c.GetJson(AlexaLocale.English_US);
            Assert.IsNotNull(obj);  //if no text, should get null

            c.OutputSpeech.SpeechType = AlexaOutputSpeechType.PlainText;
            var a = Guid.NewGuid().ToString();
            c.OutputSpeech.SetText(a);
            var json = Serialize(c.GetJson(AlexaLocale.English_US));
            Assert.IsTrue(json.Contains(a));
            Assert.IsFalse(json.Contains(AlexaOutputSpeechType.SSML.ToString()));
            Assert.IsTrue(json.Contains(AlexaOutputSpeechType.PlainText.ToString()));

            c.OutputSpeech.SpeechType = AlexaOutputSpeechType.SSML;
            json = Serialize(c.GetJson(AlexaLocale.English_US));
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
