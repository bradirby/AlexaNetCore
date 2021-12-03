using AlexaSkillDotNet;
using NUnit.Framework;

namespace ExactMeasureSkill.Tests
{
    public class ImperialToMetricTryAgainTests
    {
        [Test]
        public void OneFootInMeters_TryAgainInMillimeters()
        {
            var s = new ExactMeasureAlexaSkill();
            s.LoadRequest(ImperialToMetricSampleRequests.OneFootInMeters_TryAgainInMillimeters());
            s.ProcessRequest();

            Assert.AreEqual(IntentNames.TryAgainIntent,s.ResponseEnv.IntentHandlerName);
            Assert.AreEqual(false, s.ResponseEnv.Response.ShouldEndSession);
            Assert.AreEqual(AlexaOutputSpeechType.PlainText, s.ResponseEnv.Response.OutputSpeech.SpeechType);
            Assert.IsFalse(string.IsNullOrEmpty(s.ResponseEnv.Response.OutputSpeech.GetText(AlexaLocale.English_US)));
            Assert.AreEqual("1 foot is 304.8 millimeters", s.ResponseEnv.Response.OutputSpeech.GetText(AlexaLocale.English_US));
        }

    }
}