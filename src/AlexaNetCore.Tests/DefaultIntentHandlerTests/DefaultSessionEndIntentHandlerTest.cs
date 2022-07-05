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
    internal class DefaultSessionEndIntentHandlerTest
    {
     private class TestSkill : AlexaSkillBase
        {

        }

        
        [Test]
        public async Task ProperIntentExecuted()
        {
            var skill = await new TestSkill()
                .RegisterIntentHandler(new DefaultLaunchIntentHandler())
                .RegisterIntentHandler(new DefaultSessionEndRequest())
                .RegisterIntentHandler(new DefaultHelpIntentHandler())
                .RegisterIntentHandler(new DefaultCancelIntentHandler())
                .LoadRequest(GenericSkillRequests.EndSession())
                .ProcessRequestAsync();
            Assert.AreEqual(AlexaIntentType.SessionEnded, skill.ChosenIntent.IntentType);
        }

        [Test]
        public async Task DoesNotEndSession()
        {
            var skill = await new TestSkill()
                .RegisterIntentHandler(new DefaultLaunchIntentHandler())
                .RegisterIntentHandler(new DefaultSessionEndRequest())
                .RegisterIntentHandler(new DefaultHelpIntentHandler())
                .RegisterIntentHandler(new DefaultCancelIntentHandler())
                .LoadRequest(GenericSkillRequests.EndSession())
                .ProcessRequestAsync();
            Assert.AreEqual(true, skill.ShouldEndSession);
        }


        [Test]
        public async Task Ctor_NoParams_SetsDefaultText()
        {
            var skill = await new TestSkill()
                .RegisterIntentHandler(new DefaultLaunchIntentHandler())
                .RegisterIntentHandler(new DefaultSessionEndRequest())
                .RegisterIntentHandler(new DefaultHelpIntentHandler())
                .RegisterIntentHandler(new DefaultCancelIntentHandler())
                .LoadRequest(GenericSkillRequests.EndSession())
                .ProcessRequestAsync();
            
            Assert.AreEqual("OK, Ending the session", skill.GetSpokenText());
            Assert.AreEqual("", skill.GetRepromptText());
        }


        [Test]
        public async Task Ctor_JustTextParam_SetsText()
        {
            var txt = new AlexaMultiLanguageText("Goodbye", AlexaLocale.English_US)
                .AddText("Ciao", AlexaLocale.Italian);

            
            var skill = await new TestSkill()
                .RegisterIntentHandler(new DefaultLaunchIntentHandler())
                .RegisterIntentHandler(new DefaultSessionEndRequest(txt))
                .RegisterIntentHandler(new DefaultHelpIntentHandler())
                .RegisterIntentHandler(new DefaultCancelIntentHandler())
                .LoadRequest(GenericSkillRequests.EndSession())
                .ProcessRequestAsync();
            
            Assert.AreEqual("Goodbye", skill.GetSpokenText());
            Assert.AreEqual("", skill.GetRepromptText());
        }

        [Test]
        public async Task Ctor_JustTextParam_SetsText_Italian()
        {
            var txt = new AlexaMultiLanguageText("Goodbye", AlexaLocale.English_US)
                .AddText("Ciao", AlexaLocale.Italian);

            
            var skill = await new TestSkill()
                .RegisterRequestInterceptor(new SetRequestLanguageDebugInterceptor(AlexaLocale.Italian), 1000)
                .RegisterIntentHandler(new DefaultLaunchIntentHandler())
                .RegisterIntentHandler(new DefaultSessionEndRequest(txt))
                .RegisterIntentHandler(new DefaultHelpIntentHandler())
                .RegisterIntentHandler(new DefaultCancelIntentHandler())
                .LoadRequest(GenericSkillRequests.EndSession())
                .ProcessRequestAsync();
            
            Assert.AreEqual("Ciao", skill.GetSpokenText());
            Assert.AreEqual("", skill.GetRepromptText());
        }


    }
}
