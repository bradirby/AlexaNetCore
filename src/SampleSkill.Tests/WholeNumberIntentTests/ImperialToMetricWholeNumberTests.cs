using AlexaNetCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExactMeasureSkill.Tests
{
    internal class ImperialToMetricWholeNumberTests
    {

        
        [Test]
        public void SevenMilesInMeters()
        {
            var s = new ExactMeasureAlexaSkill();
            s.LoadRequest(ImperialToMetricSampleRequests.SevenMilesInMeters()).ProcessRequest();

            Assert.AreEqual(IntentNames.WholeNumberIntent,s.ResponseEnv.IntentHandlerName);
            Assert.AreEqual(false, s.ResponseEnv.Response.ShouldEndSession);
            Assert.AreEqual(AlexaOutputSpeechType.PlainText, s.ResponseEnv.Response.OutputSpeech.SpeechType);
            Assert.IsFalse(string.IsNullOrEmpty(s.ResponseEnv.Response.OutputSpeech.GetText(AlexaLocale.English_US)));
            Assert.AreEqual("7 miles is 11265.408 meters", s.ResponseEnv.Response.OutputSpeech.GetText(AlexaLocale.English_US));
        }

        [Test]
        public void OneInchInCentimeters()
        {
            var s = new ExactMeasureAlexaSkill();
            s.LoadRequest(ImperialToMetricSampleRequests.OneInchInCentimeters()).ProcessRequest();

            Assert.AreEqual(IntentNames.WholeNumberIntent,s.ResponseEnv.IntentHandlerName);
            Assert.AreEqual(false, s.ResponseEnv.Response.ShouldEndSession);
            Assert.AreEqual(AlexaOutputSpeechType.PlainText, s.ResponseEnv.Response.OutputSpeech.SpeechType);
            Assert.IsFalse(string.IsNullOrEmpty(s.ResponseEnv.Response.OutputSpeech.GetText(AlexaLocale.English_US)));
            Assert.AreEqual("1 inch is 2.54 centimeters", s.ResponseEnv.Response.OutputSpeech.GetText(AlexaLocale.English_US));
        }

        [Test]
        public void OneYardInCentimeters()
        {
            var s = new ExactMeasureAlexaSkill();
            s.LoadRequest(ImperialToMetricSampleRequests.OneYardInCentimeters()).ProcessRequest();

            Assert.AreEqual(IntentNames.WholeNumberIntent,s.ResponseEnv.IntentHandlerName);
            Assert.AreEqual(false, s.ResponseEnv.Response.ShouldEndSession);
            Assert.AreEqual(AlexaOutputSpeechType.PlainText, s.ResponseEnv.Response.OutputSpeech.SpeechType);
            Assert.IsFalse(string.IsNullOrEmpty(s.ResponseEnv.Response.OutputSpeech.GetText(AlexaLocale.English_US)));
            Assert.AreEqual("1 yard is 91.44 centimeters", s.ResponseEnv.Response.OutputSpeech.GetText(AlexaLocale.English_US));
        }

        [Test]
        public void OneMileInMeters()
        {
            var s = new ExactMeasureAlexaSkill();
            s.LoadRequest(ImperialToMetricSampleRequests.OneMileInMeters()).ProcessRequest();

            Assert.AreEqual(IntentNames.WholeNumberIntent,s.ResponseEnv.IntentHandlerName);
            Assert.AreEqual(false, s.ResponseEnv.Response.ShouldEndSession);
            Assert.AreEqual(AlexaOutputSpeechType.PlainText, s.ResponseEnv.Response.OutputSpeech.SpeechType);
            Assert.IsFalse(string.IsNullOrEmpty(s.ResponseEnv.Response.OutputSpeech.GetText(AlexaLocale.English_US)));
            Assert.AreEqual("1 mile is 1609.344 meters", s.ResponseEnv.Response.OutputSpeech.GetText(AlexaLocale.English_US));
        }

        [Test]
        public void OneFootInMeters()
        {
            var s = new ExactMeasureAlexaSkill();
            s.LoadRequest(ImperialToMetricSampleRequests.OneFootInMeters()).ProcessRequest();

            Assert.AreEqual(IntentNames.WholeNumberIntent,s.ResponseEnv.IntentHandlerName);
            Assert.AreEqual(false, s.ResponseEnv.Response.ShouldEndSession);
            Assert.AreEqual(AlexaOutputSpeechType.PlainText, s.ResponseEnv.Response.OutputSpeech.SpeechType);
            Assert.IsFalse(string.IsNullOrEmpty(s.ResponseEnv.Response.OutputSpeech.GetText(AlexaLocale.English_US)));
            Assert.AreEqual("1 foot is 0.3048 meters", s.ResponseEnv.Response.OutputSpeech.GetText(AlexaLocale.English_US));
        }




    }
}
