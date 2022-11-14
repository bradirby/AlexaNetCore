using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlexaNetCore.Model;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace AlexaNetCore.Tests.DefaultIntentHandlerTests
{
    internal class DefaultHelpIntentHandlerTest
    {
        private class TestSkill : AlexaSkillBase
        {
            public TestSkill(ILoggerFactory loggerFactory) : base(loggerFactory)
            {

            }
        }



        [Test]
        public async Task ProperIntentExecuted()
        {
            var skill = await new TestSkill(new LoggerFactory())
                .RegisterIntentHandler(new DefaultLaunchIntentHandler())
                .RegisterIntentHandler(new DefaultHelpIntentHandler())
                .RegisterIntentHandler(new DefaultCancelIntentHandler())
                .LoadRequest(GenericSkillRequests.HelpRequest())
                .ProcessRequestAsync();
            Assert.AreEqual(AlexaBuiltInIntents.HelpIntent, skill.ChosenIntent.IntentName);
        }

        [Test]
        public async Task DoesNotEndSession()
        {
            var skill = await new TestSkill(new LoggerFactory())
                .RegisterIntentHandler(new DefaultLaunchIntentHandler())
                .RegisterIntentHandler(new DefaultHelpIntentHandler())
                .RegisterIntentHandler(new DefaultCancelIntentHandler())
                .LoadRequest(GenericSkillRequests.HelpRequest())
                .ProcessRequestAsync();
            Assert.AreEqual(false, skill.ShouldEndSession);
        }


        [Test]
        public async Task Ctor_NoParams_SetsDefaultText()
        {
            var skill = await new TestSkill(new LoggerFactory())
                .RegisterIntentHandler(new DefaultLaunchIntentHandler())
                .RegisterIntentHandler(new DefaultHelpIntentHandler())
                .RegisterIntentHandler(new DefaultCancelIntentHandler())
                .LoadRequest(GenericSkillRequests.HelpRequest())
                .ProcessRequestAsync();
            
            Assert.AreEqual("I'm sorry you're having trouble.  Please ask again and I'll try harder.", skill.GetSpokenText());
            Assert.AreEqual("", skill.GetRepromptText());
        }


        [Test]
        public async Task Ctor_JustTextParam_SetsText()
        {
            var txt = new AlexaMultiLanguageText("Goodbye", AlexaLocale.English_US)
                .AddText("Ciao", AlexaLocale.Italian);

            
            var skill = await new TestSkill(new LoggerFactory())
                .RegisterIntentHandler(new DefaultLaunchIntentHandler())
                .RegisterIntentHandler(new DefaultHelpIntentHandler(txt))
                .RegisterIntentHandler(new DefaultCancelIntentHandler())
                .LoadRequest(GenericSkillRequests.HelpRequest())
                .ProcessRequestAsync();
            
            Assert.AreEqual("Goodbye", skill.GetSpokenText());
            Assert.AreEqual("", skill.GetRepromptText());
        }

        [Test]
        public async Task Ctor_JustTextParam_SetsText_Italian()
        {
            var txt = new AlexaMultiLanguageText("Goodbye", AlexaLocale.English_US)
                .AddText("Ciao", AlexaLocale.Italian);

            
            var skill = await new TestSkill(new LoggerFactory())
                //.RegisterRequestInterceptor(new SetBaseRequestLanguageDebugInterceptor(AlexaLocale.Italian))
                .RegisterIntentHandler(new DefaultLaunchIntentHandler())
                .RegisterIntentHandler(new DefaultHelpIntentHandler(txt))
                .RegisterIntentHandler(new DefaultCancelIntentHandler())
                .LoadRequest(GenericSkillRequests.HelpRequest(AlexaLocale.Italian))
                .ProcessRequestAsync();
            
            Assert.AreEqual("Ciao", skill.GetSpokenText());
            Assert.AreEqual("", skill.GetRepromptText());
        }

        [Test]
        public async Task Ctor_SetsReprompt_SetsText()
        {
            var txt = new AlexaMultiLanguageText("Goodbye", AlexaLocale.English_US)
                .AddText("Ciao", AlexaLocale.Italian);

            var repromptTxt = new AlexaMultiLanguageText("reprompt", AlexaLocale.English_US)
                .AddText("mondo", AlexaLocale.Italian);

            
            var skill = await new TestSkill(new LoggerFactory())
                .RegisterIntentHandler(new DefaultLaunchIntentHandler())
                .RegisterIntentHandler(new DefaultHelpIntentHandler(txt, repromptTxt))
                .RegisterIntentHandler(new DefaultCancelIntentHandler())
                .LoadRequest(GenericSkillRequests.HelpRequest())
                .ProcessRequestAsync();
            
            Assert.AreEqual("Goodbye", skill.GetSpokenText());
            Assert.AreEqual("reprompt", skill.GetRepromptText());
        }

        [Test]
        public async Task Ctor_SetsReprompt_SetsText_Italian()
        {
            var txt = new AlexaMultiLanguageText("Goodbye", AlexaLocale.English_US)
                .AddText("Ciao", AlexaLocale.Italian);

            var repromptTxt = new AlexaMultiLanguageText("reprompt", AlexaLocale.English_US)
                .AddText("mondo", AlexaLocale.Italian);

            
            var skill = await new TestSkill(new LoggerFactory())
                .RegisterIntentHandler(new DefaultLaunchIntentHandler())
                .RegisterIntentHandler(new DefaultHelpIntentHandler(txt,repromptTxt))
                .RegisterIntentHandler(new DefaultCancelIntentHandler())
                .LoadRequest(GenericSkillRequests.HelpRequest(AlexaLocale.Italian))
                .ProcessRequestAsync();
            
            Assert.AreEqual("Ciao", skill.GetSpokenText());
            Assert.AreEqual("mondo", skill.GetRepromptText());
        }

    }
}
