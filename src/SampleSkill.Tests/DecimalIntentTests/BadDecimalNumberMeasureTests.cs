using AlexaSkillDotNet;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExactMeasureSkill.Tests
{
    public class BadDecimalNumberMeasureTests
    {
        [Test]
        public void BadSourceMeasureType()
        {
            var s = new ExactMeasureAlexaSkill();
            var jsonStr = s.LoadRequest(BadMeasureTypeRequests.BadSourceMeasureTypeWithDecimals()).ProcessRequest();

            Assert.AreEqual(false, s.ResponseEnv.Response.ShouldEndSession);
            Assert.AreEqual(AlexaOutputSpeechType.PlainText, s.ResponseEnv.Response.OutputSpeech.SpeechType);
            Assert.IsFalse(string.IsNullOrEmpty(s.ResponseEnv.Response.OutputSpeech.GetText(AlexaLocale.English_US)));
            Assert.AreEqual(IntentNames.WithDecimalIntent,s.ResponseEnv.IntentHandlerName);
            Assert.AreEqual("Sorry, I don't recognize that unit of measure.", s.ResponseEnv.Response.OutputSpeech.GetText());
            Assert.AreEqual("Sorry, 'jjjj' is not a unit of measure I understand", s.ResponseEnv.Response.Card.Text.GetText());
        }

        [Test]
        public void BadTargetMeasureType()
        {
            var s = new ExactMeasureAlexaSkill();
            var jsonStr = s.LoadRequest(BadMeasureTypeRequests.BadTargetMeasureTypeWithDecimals()).ProcessRequest();

            Assert.AreEqual(false, s.ResponseEnv.Response.ShouldEndSession);
            Assert.AreEqual(AlexaOutputSpeechType.PlainText, s.ResponseEnv.Response.OutputSpeech.SpeechType);
            Assert.IsFalse(string.IsNullOrEmpty(s.ResponseEnv.Response.OutputSpeech.GetText(AlexaLocale.English_US)));
            Assert.AreEqual(IntentNames.WithDecimalIntent,s.ResponseEnv.IntentHandlerName);
            Assert.AreEqual("Sorry, I don't recognize that unit of measure.", s.ResponseEnv.Response.OutputSpeech.GetText());
            Assert.AreEqual("Sorry, 'aah' is not a unit I can convert to", s.ResponseEnv.Response.Card.Text.GetText());
        }


    }
}
