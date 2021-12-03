using AlexaNetCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExactMeasureSkill.Tests
{
    internal class MetricToImperialWholeNumberTests
    {
        
        [Test]
        public void SixtySevenKilometersInMiles()
        {
            var s = new ExactMeasureAlexaSkill();
            s.LoadRequest(MetricToImperialSampleRequests.SixtySevenKilometersInMiles()).ProcessRequest();

            Assert.AreEqual(IntentNames.WholeNumberIntent,s.ResponseEnv.IntentHandlerName);
            Assert.AreEqual(false, s.ResponseEnv.Response.ShouldEndSession);
            Assert.AreEqual("Did you want to convert anything else?",s.ResponseEnv.Response.Reprompt.OutputSpeech.GetText());
            Assert.AreEqual(AlexaOutputSpeechType.PlainText, s.ResponseEnv.Response.OutputSpeech.SpeechType);
            Assert.IsFalse(string.IsNullOrEmpty(s.ResponseEnv.Response.OutputSpeech.GetText(AlexaLocale.English_US)));
            Assert.AreEqual("67 kilometers is 41.6319 miles, or Forty-One miles Three Thousand Three Hundred and Thirty-Six feet Four and Forty-Five Sixty-fourths inches", s.ResponseEnv.Response.OutputSpeech.GetText());
        }

        [Test]
        public void OneMeterInYards()
        {
            var s = new ExactMeasureAlexaSkill();
            s.LoadRequest(MetricToImperialSampleRequests.OneMeterInYards()).ProcessRequest();

            Assert.AreEqual(IntentNames.WholeNumberIntent,s.ResponseEnv.IntentHandlerName);
            Assert.AreEqual(false, s.ResponseEnv.Response.ShouldEndSession);
            Assert.AreEqual(AlexaOutputSpeechType.PlainText, s.ResponseEnv.Response.OutputSpeech.SpeechType);
            Assert.IsFalse(string.IsNullOrEmpty(s.ResponseEnv.Response.OutputSpeech.GetText(AlexaLocale.English_US)));
            Assert.AreEqual("1 meter is 1.0936 yards, or Three feet Three and Three Eighths inches", s.ResponseEnv.Response.OutputSpeech.GetText());
        }

        [Test]
        public void TwentyOneMetersInInches()
        {
            var s = new ExactMeasureAlexaSkill();
            s.LoadRequest(MetricToImperialSampleRequests.TwentyOneMetersInInches()).ProcessRequest();

            Assert.AreEqual(IntentNames.WholeNumberIntent,s.ResponseEnv.IntentHandlerName);
            Assert.AreEqual(false, s.ResponseEnv.Response.ShouldEndSession);
            Assert.AreEqual(AlexaOutputSpeechType.PlainText, s.ResponseEnv.Response.OutputSpeech.SpeechType);
            Assert.IsFalse(string.IsNullOrEmpty(s.ResponseEnv.Response.OutputSpeech.GetText(AlexaLocale.English_US)));
            Assert.AreEqual("21 meters is 826.7721 inches, or Sixty-Eight feet Ten and Twenty-Five Thirty-seconds inches", s.ResponseEnv.Response.OutputSpeech.GetText());
        }

    }
}
