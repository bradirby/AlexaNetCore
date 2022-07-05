using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlexaNetCore.Model;
using AlexaNetCore.Util.Interceptors;
using NUnit.Framework;

namespace AlexaNetCore.Tests.DefaultIntentHandlerTests
{
    internal class DefaultCancelIntentHandlerTest
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
                .LoadRequest(BuiltInIntentRequests.CancelIntent)
                .ProcessRequestAsync();
            Assert.AreEqual(AlexaBuiltInIntents.CancelIntent, skill.ChosenIntent.IntentName);
        }


        
        [Test]
        public async Task EndsSession()
        {
            var skill = await new TestSkill()
                .RegisterIntentHandler(new DefaultLaunchIntentHandler())
                .RegisterIntentHandler(new DefaultHelpIntentHandler())
                .RegisterIntentHandler(new DefaultCancelIntentHandler())
                .LoadRequest(BuiltInIntentRequests.CancelIntent)
                .ProcessRequestAsync();
            Assert.AreEqual(true, skill.ShouldEndSession);
        }

        [Test]
        public async Task Ctor_NoParams_SetsDefaultText()
        {
            var skill = await new TestSkill()
                .RegisterIntentHandler(new DefaultLaunchIntentHandler())
                .RegisterIntentHandler(new DefaultHelpIntentHandler())
                .RegisterIntentHandler(new DefaultCancelIntentHandler())
                .LoadRequest(BuiltInIntentRequests.CancelIntent)
                .ProcessRequestAsync();
            
            Assert.AreEqual("Ok, cancelling", skill.GetSpokenText());
            Assert.AreEqual("", skill.GetRepromptText());
        }


        [Test]
        public async Task Ctor_JustTextParam_SetsText()
        {
            var txt = new AlexaMultiLanguageText("Goodbye", AlexaLocale.English_US)
                .AddText("Ciao", AlexaLocale.Italian);

            
            var skill = await new TestSkill()
                .RegisterIntentHandler(new DefaultLaunchIntentHandler())
                .RegisterIntentHandler(new DefaultHelpIntentHandler())
                .RegisterIntentHandler(new DefaultCancelIntentHandler(txt))
                .LoadRequest(BuiltInIntentRequests.CancelIntent)
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
                .RegisterIntentHandler(new DefaultHelpIntentHandler())
                .RegisterIntentHandler(new DefaultCancelIntentHandler(txt))
                .LoadRequest(BuiltInIntentRequests.CancelIntent)
                .ProcessRequestAsync();
            
            Assert.AreEqual("Ciao", skill.GetSpokenText());
            Assert.AreEqual("", skill.GetRepromptText());
        }


    }
}
