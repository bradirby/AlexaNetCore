using AlexaNetCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExactMeasureSkill.Tests
{
    internal class ImperialToMetricDecimalNumberTests
    {
        
        [Test]
        public void SixPointSevenTwoFeetInMeters()
        {
            var s = new ExactMeasureAlexaSkill();
            var jsonStr = s.LoadRequest(ImperialToMetricSampleRequests.SixPointSevenTwoFeetInMeters()).ProcessRequest();

            Assert.AreEqual(false, s.ResponseEnv.Response.ShouldEndSession);
            Assert.AreEqual(AlexaOutputSpeechType.PlainText, s.ResponseEnv.Response.OutputSpeech.SpeechType);
            Assert.IsFalse(string.IsNullOrEmpty(s.ResponseEnv.Response.OutputSpeech.GetText(AlexaLocale.English_US)));
            Assert.AreEqual("6.72 feet is 2.0483 meters", s.ResponseEnv.Response.OutputSpeech.GetText(AlexaLocale.English_US));
            Assert.AreEqual(IntentNames.WithDecimalIntent,s.ResponseEnv.IntentHandlerName);
        }

        [Test]
        public void TwoPointTwoInchesInCentimeters()
        {
            var s = new ExactMeasureAlexaSkill();
            s.LoadRequest(ImperialToMetricSampleRequests.TwoPointTwoInchesInCentimeters()).ProcessRequest();

            Assert.AreEqual(false, s.ResponseEnv.Response.ShouldEndSession);
            Assert.AreEqual(AlexaOutputSpeechType.PlainText, s.ResponseEnv.Response.OutputSpeech.SpeechType);
            Assert.IsFalse(string.IsNullOrEmpty(s.ResponseEnv.Response.OutputSpeech.GetText(AlexaLocale.English_US)));
            Assert.AreEqual("2.2 inches is 5.588 centimeters", s.ResponseEnv.Response.OutputSpeech.GetText(AlexaLocale.English_US));
            Assert.AreEqual(IntentNames.WithDecimalIntent,s.ResponseEnv.IntentHandlerName);
        }

        [Test]
        public void TwoPointTwoFeetInCentimeters()
        {
            var s = new ExactMeasureAlexaSkill();
            s.LoadRequest(ImperialToMetricSampleRequests.TwoPointTwoFeetInCentimeters()).ProcessRequest();

            Assert.AreEqual(false, s.ResponseEnv.Response.ShouldEndSession);
            Assert.AreEqual(AlexaOutputSpeechType.PlainText, s.ResponseEnv.Response.OutputSpeech.SpeechType);
            Assert.IsFalse(string.IsNullOrEmpty(s.ResponseEnv.Response.OutputSpeech.GetText(AlexaLocale.English_US)));
            Assert.AreEqual("2.2 feet is 67.056 centimeters", s.ResponseEnv.Response.OutputSpeech.GetText(AlexaLocale.English_US));
            Assert.AreEqual(IntentNames.WithDecimalIntent,s.ResponseEnv.IntentHandlerName);
        }

        [Test]
        public void TwoPointTwoYardsInCentimeters()
        {
            var s = new ExactMeasureAlexaSkill();
            s.LoadRequest(ImperialToMetricSampleRequests.TwoPointTwoYardsInCentimeters()).ProcessRequest();

            Assert.AreEqual(false, s.ResponseEnv.Response.ShouldEndSession);
            Assert.AreEqual(AlexaOutputSpeechType.PlainText, s.ResponseEnv.Response.OutputSpeech.SpeechType);
            Assert.IsFalse(string.IsNullOrEmpty(s.ResponseEnv.Response.OutputSpeech.GetText(AlexaLocale.English_US)));
            Assert.AreEqual("2.2 yards is 201.168 centimeters", s.ResponseEnv.Response.OutputSpeech.GetText(AlexaLocale.English_US));
            Assert.AreEqual(IntentNames.WithDecimalIntent,s.ResponseEnv.IntentHandlerName);
        }

        [Test]
        public void TwoPointTwoMilesInMeters()
        {
            var s = new ExactMeasureAlexaSkill();
            s.LoadRequest(ImperialToMetricSampleRequests.TwoPointTwoMilesInMeters()).ProcessRequest();

            Assert.AreEqual(false, s.ResponseEnv.Response.ShouldEndSession);
            Assert.AreEqual(AlexaOutputSpeechType.PlainText, s.ResponseEnv.Response.OutputSpeech.SpeechType);
            Assert.IsFalse(string.IsNullOrEmpty(s.ResponseEnv.Response.OutputSpeech.GetText(AlexaLocale.English_US)));
            Assert.AreEqual("2.2 miles is 3540.5568 meters", s.ResponseEnv.Response.OutputSpeech.GetText(AlexaLocale.English_US));
            Assert.AreEqual(IntentNames.WithDecimalIntent,s.ResponseEnv.IntentHandlerName);
        }

    }
}
