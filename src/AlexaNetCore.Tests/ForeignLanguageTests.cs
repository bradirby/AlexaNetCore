using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;
using AlexaNetCore.Model;
using Microsoft.Extensions.Logging;
using Moq;

namespace AlexaNetCore.Tests
{
    public class ForeignLanguageTests
    {
        private class TestSkill : AlexaSkillBase
        {
            public TestSkill(ILoggerFactory loggerFactory) : base(loggerFactory)
            {

            }
        }

        [Test]
        public async Task NullTranslator_GivesOriginalText()
        {
            var origOutputText = "orig output text";
            var origRepromptText = "orig reprompt text";

            var skill = await new TestSkill(new LoggerFactory())
                //.RegisterRequestInterceptor(new SetBaseRequestLanguageDebugInterceptor(AlexaLocale.Spanish_ES))
                .RegisterIntentHandler(new DefaultCancelIntentHandler(origOutputText))
                .RegisterIntentHandler(new DefaultHelpIntentHandler(origOutputText))
                .RegisterIntentHandler(new DefaultFallbackIntentHandler(origOutputText))
                .RegisterIntentHandler(new DefaultLaunchIntentHandler(origOutputText))
                .RegisterIntentHandler(new DefaultSessionEndRequest(origOutputText))
                .RegisterIntentHandler(new DefaultStartOverIntentHandler(origOutputText))
                .RegisterIntentHandler(new DefaultStopIntentHandler(origOutputText))
                .LoadRequest(GenericSkillRequests.LaunchRequest())
                .ProcessRequestAsync();
            skill.Reprompt(origRepromptText);

            var returnJson = skill.GetResponse();

            Assert.IsTrue(returnJson.Contains(origOutputText));
            Assert.IsTrue(returnJson.Contains(origRepromptText));
        }




        [Test]
        public async Task LaunchRequest_ChangeRequestLocaleToSpain_TranslatesToTargetLanguage_Spanish()
        {
            var srchStrings = new AlexaMultiLanguageText($"find this", AlexaLocale.English_US)
                .AddText($"trova questo", AlexaLocale.Italian)
                .AddText($"encuentra esto", AlexaLocale.Spanish_ES);

            var reprompts =new AlexaMultiLanguageText($"hello world", AlexaLocale.English_US)
                .AddText($"ciao mondo", AlexaLocale.Italian)
                .AddText($"hola mundo", AlexaLocale.Spanish_ES);

            var skill = await new TestSkill(new LoggerFactory())
                .RegisterIntentHandler(new DefaultLaunchIntentHandler(srchStrings))
                .LoadRequest(GenericSkillRequests.LaunchRequest(AlexaLocale.Spanish_ES))
                .ProcessRequestAsync();
            skill.Reprompt(reprompts);


            Assert.AreEqual("encuentra esto", skill.GetSpokenText());
            Assert.AreEqual("hola mundo", skill.GetRepromptText());
        }

        [Test]
        public async Task LaunchRequest_ChangeRequestLocaleToSpain_TranslatesToTargetLanguage_English()
        {
            var srchStrings = new AlexaMultiLanguageText($"find this", AlexaLocale.English_US)
                .AddText($"trova questo", AlexaLocale.Italian)
                .AddText($"encuentra esto", AlexaLocale.Spanish_ES);

            var reprompts =new AlexaMultiLanguageText($"hello world", AlexaLocale.English_US)
                .AddText($"ciao mondo", AlexaLocale.Italian)
                .AddText($"hola mundo", AlexaLocale.Spanish_ES);

            var skill = await new TestSkill(new LoggerFactory())
                .RegisterIntentHandler(new DefaultLaunchIntentHandler(srchStrings))
                .LoadRequest(GenericSkillRequests.LaunchRequest())
                .ProcessRequestAsync();
            skill.Reprompt(reprompts);


            Assert.AreEqual("find this", skill.GetSpokenText());
            Assert.AreEqual("hello world", skill.GetRepromptText());
        }

        [Test]
        public async Task LaunchRequest_ChangeRequestLocaleToSpain_TranslatesToTargetLanguage_Italian()
        {
            var srchStrings = new AlexaMultiLanguageText($"find this", AlexaLocale.English_US)
                .AddText($"trova questo", AlexaLocale.Italian)
                .AddText($"encuentra esto", AlexaLocale.Spanish_ES);

            var reprompts =new AlexaMultiLanguageText($"hello world", AlexaLocale.English_US)
                .AddText($"ciao mondo", AlexaLocale.Italian)
                .AddText($"hola mundo", AlexaLocale.Spanish_ES);

            var skill = await new TestSkill(new LoggerFactory())
                .RegisterIntentHandler(new DefaultLaunchIntentHandler(srchStrings))
                .LoadRequest(GenericSkillRequests.LaunchRequest(AlexaLocale.Italian))
                .ProcessRequestAsync();
            skill.Reprompt(reprompts);


            Assert.AreEqual("trova questo", skill.GetSpokenText());
            Assert.AreEqual("ciao mondo", skill.GetRepromptText());
        }



        [Test]
        public async Task LaunchRequest_ChangeRequestLocaleToItaly_TranslatesToTargetLanguage()
        {
            var skill = new TestSkill(new LoggerFactory())
                .RegisterDefaultTestHandlers(
                new AlexaMultiLanguageText( $"find this", AlexaLocale.English_US)
                    .AddText( $"trova questo", AlexaLocale.Italian)
                    .AddText( $"encuentra esto", AlexaLocale.Spanish_ES));


            await skill
                .LoadRequest(GenericSkillRequests.LaunchRequest(AlexaLocale.Italian))
                .ProcessRequestAsync();
            skill.Reprompt(new AlexaMultiLanguageText( $"hello world", AlexaLocale.English_US)
                    .AddText( $"ciao mondo", AlexaLocale.Italian)
                    .AddText( $"hola mundo", AlexaLocale.Spanish_ES));
            var returnJson = skill.GetResponse();

            Assert.IsFalse(returnJson.Contains("hello world"));
            Assert.IsTrue(returnJson.Contains("ciao mondo"));
            Assert.IsFalse(returnJson.Contains("hola mundo"));

            Assert.IsFalse(returnJson.Contains("find this"));
            Assert.IsTrue(returnJson.Contains("trova questo"));
            Assert.IsFalse(returnJson.Contains("encuentra esto"));

        }
        
        [Test]
        public async Task LaunchRequest_DoNotSpecifyLocale_TranslatesToTargetLanguage()
        {
            var skill = await new TestSkill(new LoggerFactory())
                .RegisterDefaultTestHandlers(
                new AlexaMultiLanguageText( $"find this", AlexaLocale.English_US)
                    .AddText( $"trova questo", AlexaLocale.Italian)
                    .AddText( $"encuentra esto", AlexaLocale.Spanish_ES))                .LoadRequest(GenericSkillRequests.LaunchRequest())
                .ProcessRequestAsync();

            skill.Reprompt(new AlexaMultiLanguageText( $"hello world", AlexaLocale.English_US)
                    .AddText( $"ciao mondo", AlexaLocale.Italian)
                    .AddText( $"hola mundo", AlexaLocale.Spanish_ES));
            var returnJson = skill.GetResponse();

            Assert.IsTrue(returnJson.Contains("hello world"));
            Assert.IsFalse(returnJson.Contains("ciao mondo"));
            Assert.IsFalse(returnJson.Contains("hola mundo"));

            Assert.IsTrue(returnJson.Contains("find this"));
            Assert.IsFalse(returnJson.Contains("trova questo"));
            Assert.IsFalse(returnJson.Contains("encuentra esto"));

        }


        [Test]
        public async Task LaunchRequest_SpecifyLocaleEnglish_TranslatesCorrectly()
        {
            var languages = 
                new AlexaMultiLanguageText( "find this", AlexaLocale.English_US)
                    .AddText( "trova questo", AlexaLocale.Italian)
                    .AddText( "encuentra esto", AlexaLocale.Spanish_ES);


            var skill = new TestSkill(new LoggerFactory());
            skill.RegisterDefaultTestHandlers(languages);
            skill.LoadRequest(GenericSkillRequests.LaunchRequest());
            await skill.ProcessRequestAsync();
            var str = skill.GetSpokenText(AlexaLocale.English_US);


            Assert.AreEqual("find this", str);
        }


        [Test]
        public async Task LaunchRequest_SpecifyLocaleItalian_TranslatesCorrectly()
        {
            var languages = 
                new AlexaMultiLanguageText( "find this", AlexaLocale.English_US)
                    .AddText( "trova questo", AlexaLocale.Italian)
                    .AddText( "encuentra esto", AlexaLocale.Spanish_ES);


            var skill = new TestSkill(new LoggerFactory());
            skill.RegisterDefaultTestHandlers(languages);
            skill.LoadRequest(GenericSkillRequests.LaunchRequest(AlexaLocale.Italian));
            await skill.ProcessRequestAsync();

            Assert.AreEqual("trova questo", skill.GetSpokenText());

        }

        [Test]
        public async Task LaunchRequest_SpecifyLocalespanish_TranslatesCorrectly()
        {
            var languages = 
                new AlexaMultiLanguageText( "find this", AlexaLocale.English_US)
                    .AddText( "trova questo", AlexaLocale.Italian)
                    .AddText( "encuentra esto", AlexaLocale.Spanish_ES);


            var skill = new TestSkill(new LoggerFactory());
            skill.RegisterDefaultTestHandlers(languages);
            skill.LoadRequest(GenericSkillRequests.LaunchRequest(AlexaLocale.Spanish_ES));
            await skill.ProcessRequestAsync();
                

            Assert.AreEqual("encuentra esto", skill.GetSpokenText());

        }


    }

}