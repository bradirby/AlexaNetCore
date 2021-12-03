using AlexaSkillDotNet;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExactMeasureSkill.Tests
{
    internal class MetricToImperialDecimalNumberTests
    {
        
        
        [Test]
        public void OnePointTwoMetersInYards()
        {
            var s = new ExactMeasureAlexaSkill();
            var json = s.LoadRequest(MetricToImperialSampleRequests.OnePointTwoMetersInYards()).ProcessRequest().CreateAlexaResponse();

            Assert.AreEqual(IntentNames.WithDecimalIntent,s.ResponseEnv.IntentHandlerName);
            Assert.AreEqual(false, s.ResponseEnv.Response.ShouldEndSession);
            Assert.AreEqual(AlexaOutputSpeechType.PlainText, s.ResponseEnv.Response.OutputSpeech.SpeechType);
            Assert.IsFalse(string.IsNullOrEmpty(s.ResponseEnv.Response.OutputSpeech.GetText(AlexaLocale.English_US)));
            Assert.AreEqual("1.2 meters is 1.3123 yards, or Three feet Eleven and one fourth inches".ToLower(), 
                s.ResponseEnv.Response.OutputSpeech.GetText(AlexaLocale.English_US).ToLower());

        }
        
        
      
        [Test]
        public void SixtySevenPointThreeNineKilometersInMiles_WithExtraValues()
        {
            var s = new ExactMeasureAlexaSkill();
            s.LoadRequest(MetricToImperialSampleRequests.SixtySevenPointThreeNineKilometersInMiles_WithExtraValues()).ProcessRequest();

            Assert.AreEqual(IntentNames.WithDecimalIntent,s.ResponseEnv.IntentHandlerName);
            Assert.AreEqual(false, s.ResponseEnv.Response.ShouldEndSession);
            Assert.AreEqual(AlexaOutputSpeechType.PlainText, s.ResponseEnv.Response.OutputSpeech.SpeechType);
            Assert.IsFalse(string.IsNullOrEmpty(s.ResponseEnv.Response.OutputSpeech.GetText(AlexaLocale.English_US)));
            Assert.AreEqual("67.39 kilometers is 41.8742 miles, or Forty-one miles Four thousand six hundred and fifteen feet Eleven and three sixty-fourths inches".ToLower(), 
                s.ResponseEnv.Response.OutputSpeech.GetText(AlexaLocale.English_US).ToLower());
        }

        [Test]
        public void SixtySevenPointThreeNineKilometersInMiles()
        {
            var s = new ExactMeasureAlexaSkill();
            s.LoadRequest(MetricToImperialSampleRequests.SixtySevenPointThreeNineKilometersInMiles()).ProcessRequest();

            Assert.AreEqual(IntentNames.WithDecimalIntent,s.ResponseEnv.IntentHandlerName);
            Assert.AreEqual(false, s.ResponseEnv.Response.ShouldEndSession);
            Assert.AreEqual("Did you want to convert anything else?",s.ResponseEnv.Response.Reprompt.OutputSpeech.GetText(AlexaLocale.English_US));
            Assert.AreEqual(AlexaOutputSpeechType.PlainText, s.ResponseEnv.Response.OutputSpeech.SpeechType);
            Assert.IsFalse(string.IsNullOrEmpty(s.ResponseEnv.Response.OutputSpeech.GetText(AlexaLocale.English_US)));
            Assert.AreEqual("67.39 kilometers is 41.8742 miles, or Forty-one miles Four thousand six hundred and fifteen feet Eleven and three sixty-fourths inches".ToLower(), 
                s.ResponseEnv.Response.OutputSpeech.GetText(AlexaLocale.English_US).ToLower());
        }




        [Test]
        public void OnePointTwoSevenMetersInInches()
        {
            var s = new ExactMeasureAlexaSkill();
            s.LoadRequest(MetricToImperialSampleRequests.OnePointTwoSevenMetersInInches());
            s.ProcessRequest();

            Assert.AreEqual(IntentNames.WithDecimalIntent,s.ResponseEnv.IntentHandlerName);
            Assert.AreEqual(false, s.ResponseEnv.Response.ShouldEndSession);
            Assert.AreEqual(AlexaOutputSpeechType.PlainText, s.ResponseEnv.Response.OutputSpeech.SpeechType);
            Assert.IsFalse(string.IsNullOrEmpty(s.ResponseEnv.Response.OutputSpeech.GetText(AlexaLocale.English_US)));
            Assert.AreEqual("1.27 meters is 50 inches, or Four feet Two and One Sixty-fourth inches", s.ResponseEnv.Response.OutputSpeech.GetText(AlexaLocale.English_US));

        }


    }
}
