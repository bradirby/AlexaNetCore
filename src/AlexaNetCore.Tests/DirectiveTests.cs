﻿using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlexaNetCore.Directives;
using AlexaNetCore.Model;
using Microsoft.Extensions.Logging;
using Moq;

namespace AlexaNetCore.Tests
{
    internal class DirectiveTests
    {

        private class TestSkill : AlexaSkillBase
        {
            public TestSkill(ILoggerFactory loggerFactory) : base(loggerFactory)
            {

            }
        }

        private class TestDirectiveIntent : AlexaIntentHandlerBase
        {
            private List<AlexaSlotUpdate> Slots;
            public TestDirectiveIntent(List<AlexaSlotUpdate> slots) : base(AlexaIntentType.Launch, "test")
            {
                Slots = slots;
            }

            public override Task ProcessAsync()
            {
                Speak("hello");
                var directive = new AlexaUpdateDynamicEntitiesDirective(Slots);
                AddDirective(directive);
                return Task.CompletedTask;
            }
        }

        
        [Test]
        public async Task NoDirectives_NothingAddedToResponse()
        {
            var skill = new TestSkill(new LoggerFactory());
            skill.RegisterIntentHandler(new DefaultLaunchIntentHandler());
            skill.LoadRequest(GenericSkillRequests.LaunchRequest());
            await skill.ProcessRequestAsync();

            var json = skill.GetResponse();

            Assert.IsFalse(json.Contains("directives"));
        }


        [Test]
        public async Task DirectiveAdded_KeyWordAddedToResponse()
        {
            var lst = new List<AlexaSlotUpdate>();
            var skill = new TestSkill(new LoggerFactory());
            skill.RegisterIntentHandler(new TestDirectiveIntent(lst))
                .LoadRequest(GenericSkillRequests.LaunchRequest());
            await skill.ProcessRequestAsync();

            var json = skill.GetResponse();

            Assert.IsTrue(json.Contains("directive"));
        }

        [Test]
        public async Task DirectiveAdded_CorrectUpdateBehavior()
        {
            var optionLst = new List<AlexaSlotUpdateOption>();
            optionLst.Add( new AlexaSlotUpdateOption("LGA", "LaGuardia Airport")
                .AddSynonym("New York"));
            optionLst.Add( new AlexaSlotUpdateOption("BOS","Logan International Airport")
                .AddSynonym("Boston Logan"));

            var slotLst = new List<AlexaSlotUpdate>();
            slotLst.Add(new AlexaSlotUpdate("AirportSlotType", optionLst));


            var skill = new TestSkill(new LoggerFactory());
            skill.RegisterIntentHandler(new TestDirectiveIntent(slotLst))
                .LoadRequest(GenericSkillRequests.LaunchRequest());
            await skill.ProcessRequestAsync();

            var json = skill.GetResponse();

            Assert.IsTrue(json.Contains("Logan International Airport"));
        }
      

    }
}
