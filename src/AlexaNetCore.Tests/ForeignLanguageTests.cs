using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using AlexaNetCore;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Runtime.Internal.Util;
using Moq;

namespace AlexaNetCore.Tests
{
    public class ForeignLanguageTests
    {
        private class TestAlexaSkill : AlexaSkillBase
        {
        }

        [Test]
        public void NullTranslator_GivesOriginalText()
        {
            var origOutputText = "orig output text";
            var origRepromptText = "orig reprompt text";

            var skill = new TestAlexaSkill();
            skill.RegisterDefaultIntentHandlers(origOutputText);
            var returnJson = skill
                .LoadRequest(GenericSkillRequests.LaunchRequest().SetLocale(AlexaLocale.Spanish_ES))
                .ProcessRequest()
                .SetRepromptSpeach(origRepromptText)
                .SetShouldEndSession(false)
                .CreateAlexaResponse();

            Assert.IsTrue(returnJson.Contains(origOutputText));
            Assert.IsTrue(returnJson.Contains(origRepromptText));
        }



        [Test]
        public void RegisterTranslator_TranslatesOutputText()
        {
            var trSvc = new Mock<IAlexaTranslationService>();
            var origText = "orig output text";
            var translatedText = "translated output text";
            trSvc.Setup(x => x.TranslateAsync(origText, AlexaLocale.Italian.LanguageCode))
                .Returns(Task.FromResult(translatedText));
            trSvc.Setup(t => t.SourceLanguageCode).Returns(AlexaLocale.English_US.LanguageCode);

            var skill = new TestAlexaSkill()
                .RegisterDefaultIntentHandlers(origText)
                .LoadRequest(GenericSkillRequests.LaunchRequest().SetLocale(AlexaLocale.Italian))
                .ProcessRequest();
            var returnJson = skill.CreateAlexaResponse(trSvc.Object);

            Assert.IsFalse(returnJson.Contains(origText));
            Assert.IsTrue(returnJson.Contains(translatedText));
        }

        [Test]
        public void RegisterTranslator_TranslatesRepromptText()
        {
            var trSvc = new Mock<IAlexaTranslationService>();
            var origText = "orig output text";
            var translatedText = "translated output text";
            trSvc.Setup(x => x.TranslateAsync(origText, AlexaLocale.Italian.LanguageCode))
                .Returns(Task.FromResult(translatedText));
            trSvc.Setup(t => t.SourceLanguageCode).Returns(AlexaLocale.English_US.LanguageCode);

            var skill = new TestAlexaSkill()
                .RegisterDefaultIntentHandlers(origText)
                .LoadRequest(GenericSkillRequests.LaunchRequest().SetLocale(AlexaLocale.Italian));
            skill.ProcessRequest();
            if (!skill.IsRepromptSet) skill.SetRepromptSpeach(origText);
            var returnJson = skill.CreateAlexaResponse(trSvc.Object);

            Assert.IsFalse(returnJson.Contains(origText));
            Assert.IsTrue(returnJson.Contains(translatedText));
        }


        [Test]
        public void LaunchRequest_ChangeRequestLocaleToSpain_TranslatesToTargetLanguage()
        {
            var skill = new TestAlexaSkill();
            skill.RegisterDefaultIntentHandlers(
                new AlexaMultiLanguageText($"find this", AlexaLocale.English_US)
                    .AddText($"trova questo", AlexaLocale.Italian)
                    .AddText($"encuentra esto", AlexaLocale.Spanish_ES));


            var returnJson = skill
                .LoadRequest(GenericSkillRequests.LaunchRequest().SetLocale(AlexaLocale.Spanish_ES))
                .ProcessRequest()
                .SetRepromptSpeach(new AlexaMultiLanguageText($"hello world", AlexaLocale.English_US)
                    .AddText( $"ciao mondo", AlexaLocale.Italian)
                    .AddText( $"hola mundo", AlexaLocale.Spanish_ES))
                .SetShouldEndSession(false)
                .CreateAlexaResponse();

            Assert.IsFalse(returnJson.Contains("hello world"));
            Assert.IsFalse(returnJson.Contains("ciao mondo"));
            Assert.IsTrue(returnJson.Contains("hola mundo"));

            Assert.IsFalse(returnJson.Contains("find this"));
            Assert.IsFalse(returnJson.Contains("trova questo"));
            Assert.IsTrue(returnJson.Contains("encuentra esto"));

            Assert.IsFalse(returnJson.Contains("hello world"));
            Assert.IsFalse(returnJson.Contains("ciao mondo"));
            Assert.IsTrue(returnJson.Contains("hola mundo"));

            Assert.IsTrue(skill.MsgLogger.GetLogHistory().Any(s => s.StartsWith("DEBUG")));
            Assert.IsFalse(skill.MsgLogger.GetLogHistory().Any(s => s.StartsWith("WARNING")));
            Assert.IsFalse(skill.MsgLogger.GetLogHistory().Any(s => s.StartsWith("ERROR")));

        }

        [Test]
        public void LaunchRequest_ChangeRequestLocaleToItaly_TranslatesToTargetLanguage()
        {
            var skill = new TestAlexaSkill();
            skill.RegisterDefaultIntentHandlers(
                new AlexaMultiLanguageText( $"find this", AlexaLocale.English_US)
                    .AddText( $"trova questo", AlexaLocale.Italian)
                    .AddText( $"encuentra esto", AlexaLocale.Spanish_ES));


            var returnJson = skill
                .LoadRequest(GenericSkillRequests.LaunchRequest().SetLocale(AlexaLocale.Italian))
                .ProcessRequest()
                .SetRepromptSpeach(new AlexaMultiLanguageText( $"hello world", AlexaLocale.English_US)
                    .AddText( $"ciao mondo", AlexaLocale.Italian)
                    .AddText( $"hola mundo", AlexaLocale.Spanish_ES))
                .CreateAlexaResponse();

            Assert.IsFalse(returnJson.Contains("hello world"));
            Assert.IsTrue(returnJson.Contains("ciao mondo"));
            Assert.IsFalse(returnJson.Contains("hola mundo"));

            Assert.IsFalse(returnJson.Contains("find this"));
            Assert.IsTrue(returnJson.Contains("trova questo"));
            Assert.IsFalse(returnJson.Contains("encuentra esto"));

            Assert.IsTrue(skill.MsgLogger.GetLogHistory().Any(s => s.StartsWith("DEBUG")));
            Assert.IsFalse(skill.MsgLogger.GetLogHistory().Any(s => s.StartsWith("WARNING")));
            Assert.IsFalse(skill.MsgLogger.GetLogHistory().Any(s => s.StartsWith("ERROR")));

        }
        
        [Test]
        public void LaunchRequest_DoNotSpecifyLocale_TranslatesToTargetLanguage()
        {
            var skill = new TestAlexaSkill();
            skill.RegisterDefaultIntentHandlers(
                new AlexaMultiLanguageText( $"find this", AlexaLocale.English_US)
                    .AddText( $"trova questo", AlexaLocale.Italian)
                    .AddText( $"encuentra esto", AlexaLocale.Spanish_ES));


            var returnJson = skill
                .LoadRequest(GenericSkillRequests.LaunchRequest())
                .ProcessRequest()
                .SetRepromptSpeach(new AlexaMultiLanguageText( $"hello world", AlexaLocale.English_US)
                    .AddText( $"ciao mondo", AlexaLocale.Italian)
                    .AddText( $"hola mundo", AlexaLocale.Spanish_ES))
                .CreateAlexaResponse();

            Assert.IsTrue(returnJson.Contains("hello world"));
            Assert.IsFalse(returnJson.Contains("ciao mondo"));
            Assert.IsFalse(returnJson.Contains("hola mundo"));

            Assert.IsTrue(returnJson.Contains("find this"));
            Assert.IsFalse(returnJson.Contains("trova questo"));
            Assert.IsFalse(returnJson.Contains("encuentra esto"));

            Assert.IsTrue(skill.MsgLogger.GetLogHistory().Any(s => s.StartsWith("DEBUG")));
            Assert.IsFalse(skill.MsgLogger.GetLogHistory().Any(s => s.StartsWith("WARNING")));
            Assert.IsFalse(skill.MsgLogger.GetLogHistory().Any(s => s.StartsWith("ERROR")));

        }


        [Test]
        public void LaunchRequest_SpecifyLocale_TranslatesCorrectly()
        {
            var skill = new TestAlexaSkill();
            skill.RegisterDefaultIntentHandlers(
                new AlexaMultiLanguageText( "find this", AlexaLocale.English_US)
                    .AddText( "trova questo", AlexaLocale.Italian)
                    .AddText( "encuentra esto", AlexaLocale.Spanish_ES));


            var returnJson = skill
                .LoadRequest(GenericSkillRequests.LaunchRequest())
                .ProcessRequest()
                .CreateAlexaResponse();

            Assert.AreEqual("find this", skill.ResponseEnv.GetOutputSpeach(AlexaLocale.English_US));
            Assert.AreEqual("trova questo", skill.ResponseEnv.GetOutputSpeach(AlexaLocale.Italian));
            Assert.AreEqual("encuentra esto", skill.ResponseEnv.GetOutputSpeach(AlexaLocale.Spanish_ES));

            Assert.IsTrue(skill.MsgLogger.GetLogHistory().Any(s => s.StartsWith("DEBUG")));
            Assert.IsFalse(skill.MsgLogger.GetLogHistory().Any(s => s.StartsWith("WARNING")));
            Assert.IsFalse(skill.MsgLogger.GetLogHistory().Any(s => s.StartsWith("ERROR")));

        }




    }

}