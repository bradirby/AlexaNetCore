using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AlexaNetCore.Tests
{
    internal class InteractionModelGenerationTests
    {
        string dblQuote => "\"";
        
        [Test]
        public void Intent_GeneratesNameCorrectly()
        {
            var intent = new ModelGenIntent();
            var str = intent.GetInteractionModelIntentDescriptor();
            Assert.IsTrue(str.Contains($"{dblQuote}name{dblQuote}: {dblQuote}ModelGenIntent{dblQuote}"));
        }

        [Test]
        public void Intent_NoSampleInvocations_GeneratesEmptyCollection()
        {
            var intent = new ModelGenIntent();
            var str = intent.GetInteractionModelIntentDescriptor();
            str = str.Replace("\r\n", "");
            Assert.IsTrue(str.Contains($"{dblQuote}samples{dblQuote}: []"));
        }

        [Test]
        public void Intent_OneSampleInvocations_GeneratesProperCollection()
        {
            var intent = new ModelGenIntent();
            intent.AddSampleInvocation("find this invocation");
            var str = intent.GetInteractionModelIntentDescriptor();
            str = str.Replace("\r\n", "");
            Assert.IsTrue(str.Contains($"{dblQuote}samples{dblQuote}: [{dblQuote}find this invocation{dblQuote}]"));
        }

        [Test]
        public void Intent_TwoSampleInvocations_GeneratesProperCollection()
        {
            var intent = new ModelGenIntent();
            intent.AddSampleInvocation("find this invocation");
            intent.AddSampleInvocation("and this one");
            var str = intent.GetInteractionModelIntentDescriptor();
            str = str.Replace("\r\n", "");
            Assert.IsTrue(str.Contains($"{dblQuote}samples{dblQuote}: [{dblQuote}find this invocation{dblQuote}, {dblQuote}and this one{dblQuote}]"));
        }

        public class ModelGenIntent : AlexaIntentHandlerBase
        {
            public ModelGenIntent() : base("ModelGenIntent")
            {
            }

            public override void Process()
            {
                throw new NotImplementedException();
            }
        }
    }
}
