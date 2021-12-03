using AlexaNetCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExactMeasureSkill.Tests
{
    public class ImperialToImperialWholeNumberTests
    {
        
        [Test]
        public void OneMileInInches()
        {
            var s = new ExactMeasureAlexaSkill();
            var jsonStr = s.LoadRequest(ImperialToImperialSampleRequests.OneMileInInches()).ProcessRequest();

            Assert.AreEqual(false, s.ResponseEnv.Response.ShouldEndSession);
            Assert.AreEqual(AlexaOutputSpeechType.PlainText, s.ResponseEnv.Response.OutputSpeech.SpeechType);
            Assert.IsFalse(string.IsNullOrEmpty(s.ResponseEnv.Response.OutputSpeech.GetText()));
            Assert.AreEqual(IntentNames.WholeNumberIntent,s.ResponseEnv.IntentHandlerName);
            Assert.AreEqual("1 mile is 63360 inches", s.ResponseEnv.Response.OutputSpeech.GetText());
            Assert.AreEqual("1 mile\r\n = 63360 inches\r\n",s.ResponseEnv.Response.Card.Text.GetText());
        }

        [Test]
        public void OneFootInInches()
        {
            var s = new ExactMeasureAlexaSkill();
            var jsonStr = s.LoadRequest(ImperialToImperialSampleRequests.OneFootInInches()).ProcessRequest();

            Assert.AreEqual(false, s.ResponseEnv.Response.ShouldEndSession);
            Assert.AreEqual(AlexaOutputSpeechType.PlainText, s.ResponseEnv.Response.OutputSpeech.SpeechType);
            Assert.IsFalse(string.IsNullOrEmpty(s.ResponseEnv.Response.OutputSpeech.GetText()));
            Assert.AreEqual(IntentNames.WholeNumberIntent,s.ResponseEnv.IntentHandlerName);
            Assert.AreEqual("1 foot is 12 inches", s.ResponseEnv.Response.OutputSpeech.GetText());
        }

    }
}
