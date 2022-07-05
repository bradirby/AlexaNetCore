using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlexaNetCore.Model;
using AlexaNetCore.Util.Interceptors;

namespace AlexaNetCore.Tests.DefaultIntentHandlerTests
{
    internal class DefaultLaunchIntentHandlerTest
    {
      private class TestSkill : AlexaSkillBase
        {

        }

        
        [Test]
        public async Task ProperIntentExecuted()
        {
            var skill = await new TestSkill()
                .RegisterIntentHandler(new DefaultLaunchIntentHandler())
                .RegisterIntentHandler(new DefaultHelpIntentHandler())
                .RegisterIntentHandler(new DefaultCancelIntentHandler())
                .LoadRequest(GenericSkillRequests.LaunchRequest())
                .ProcessRequestAsync();
            Assert.AreEqual(AlexaIntentType.Launch, skill.ChosenIntent.IntentType);
        }

        [Test]
        public async Task DoesNotEndSession()
        {
            var skill = await new TestSkill()
                .RegisterIntentHandler(new DefaultLaunchIntentHandler())
                .RegisterIntentHandler(new DefaultHelpIntentHandler())
                .RegisterIntentHandler(new DefaultCancelIntentHandler())
                .LoadRequest(GenericSkillRequests.LaunchRequest())
                .ProcessRequestAsync();
            Assert.AreEqual(false, skill.ShouldEndSession);
        }


        [Test]
        public async Task Ctor_NoParams_SetsDefaultText()
        {
            var skill = await new TestSkill()
                .RegisterIntentHandler(new DefaultLaunchIntentHandler())
                .RegisterIntentHandler(new DefaultHelpIntentHandler())
                .RegisterIntentHandler(new DefaultCancelIntentHandler())
                .LoadRequest(GenericSkillRequests.LaunchRequest())
                .ProcessRequestAsync();
            
            Assert.AreEqual("Hello, what can I do for you today?", skill.GetSpokenText());
            Assert.AreEqual("", skill.GetRepromptText());
        }


        [Test]
        public async Task Ctor_JustTextParam_SetsText()
        {
            var txt = new AlexaMultiLanguageText("Hello", AlexaLocale.English_US)
                .AddText("Ciao", AlexaLocale.Italian);

            
            var skill = await new TestSkill()
                .RegisterIntentHandler(new DefaultLaunchIntentHandler(txt))
                .RegisterIntentHandler(new DefaultHelpIntentHandler())
                .RegisterIntentHandler(new DefaultCancelIntentHandler())
                .LoadRequest(GenericSkillRequests.LaunchRequest())
                .ProcessRequestAsync();
            
            Assert.AreEqual("Hello", skill.GetSpokenText());
            Assert.AreEqual("", skill.GetRepromptText());
        }

        [Test]
        public async Task Ctor_JustTextParam_SetsText_Italian()
        {
            var txt = new AlexaMultiLanguageText("Hello", AlexaLocale.English_US)
                .AddText("Ciao", AlexaLocale.Italian);

            
            var skill = await new TestSkill()
                .RegisterRequestInterceptor(new SetRequestLanguageDebugInterceptor(AlexaLocale.Italian), 1000)
                .RegisterIntentHandler(new DefaultLaunchIntentHandler(txt))
                .RegisterIntentHandler(new DefaultHelpIntentHandler())
                .RegisterIntentHandler(new DefaultCancelIntentHandler())
                .LoadRequest(GenericSkillRequests.LaunchRequest())
                .ProcessRequestAsync();
            
            Assert.AreEqual("Ciao", skill.GetSpokenText());
            Assert.AreEqual("", skill.GetRepromptText());
        }

        [Test]
        public async Task Ctor_SetsReprompt_SetsText()
        {
            var txt = new AlexaMultiLanguageText("Hello", AlexaLocale.English_US)
                .AddText("Ciao", AlexaLocale.Italian);

            var repromptTxt = new AlexaMultiLanguageText("reprompt", AlexaLocale.English_US)
                .AddText("mondo", AlexaLocale.Italian);

            
            var skill = await new TestSkill()
                .RegisterIntentHandler(new DefaultLaunchIntentHandler(txt, repromptTxt))
                .RegisterIntentHandler(new DefaultHelpIntentHandler())
                .RegisterIntentHandler(new DefaultCancelIntentHandler())
                .LoadRequest(GenericSkillRequests.LaunchRequest())
                .ProcessRequestAsync();
            
            Assert.AreEqual("Hello", skill.GetSpokenText());
            Assert.AreEqual("reprompt", skill.GetRepromptText());
        }

        [Test]
        public async Task Ctor_SetsReprompt_SetsText_Italian()
        {
            var txt = new AlexaMultiLanguageText("Hello", AlexaLocale.English_US)
                .AddText("Ciao", AlexaLocale.Italian);

            var repromptTxt = new AlexaMultiLanguageText("reprompt", AlexaLocale.English_US)
                .AddText("mondo", AlexaLocale.Italian);

            
            var skill = await new TestSkill()
                .RegisterRequestInterceptor(new SetRequestLanguageDebugInterceptor(AlexaLocale.Italian), 1000)
                .RegisterIntentHandler(new DefaultLaunchIntentHandler(txt,repromptTxt))
                .RegisterIntentHandler(new DefaultHelpIntentHandler())
                .RegisterIntentHandler(new DefaultCancelIntentHandler())
                .LoadRequest(GenericSkillRequests.LaunchRequest())
                .ProcessRequestAsync();
            
            Assert.AreEqual("Ciao", skill.GetSpokenText());
            Assert.AreEqual("mondo", skill.GetRepromptText());
        }

    }
}
