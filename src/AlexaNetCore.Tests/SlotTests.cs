using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using AlexaNetCore.InteractionModel;
using NUnit.Framework;

namespace AlexaNetCore.Tests
{
    public class SlotTests
    {
        private string dblQuote => "\"";
        private string curlyBraceOpen => "{";
        private string curlyBraceClose => "}";

        [Test]
        public void CustomSlotTypeValueOptionDescriptorInteractionModel_NoSynonyms_ReturnsValidJson()
        {
            var obj = new CustomSlotTypeValueOptionDescriptorInteractionModel("Test");
            var str = JsonSerializer.Serialize(obj);
            Assert.AreEqual($"{curlyBraceOpen}{dblQuote}value{dblQuote}:{dblQuote}Test{dblQuote},{dblQuote}synonyms{dblQuote}:[]{curlyBraceClose}", str);
        }

        [Test]
        public void CustomSlotTypeValueOptionDescriptorInteractionModel_OneSynonym_ReturnsValidJson()
        {
            var obj = new CustomSlotTypeValueOptionDescriptorInteractionModel("Test");
            obj.AddSynonym("synName");
            var str = JsonSerializer.Serialize(obj);
            Assert.AreEqual($"{curlyBraceOpen}{dblQuote}value{dblQuote}:{dblQuote}Test{dblQuote},{dblQuote}synonyms{dblQuote}:[{dblQuote}synName{dblQuote}]{curlyBraceClose}", str);
        }

        [Test]
        public void CustomSlotTypeValueOptionDescriptorInteractionModel_TwoSynonyms_ReturnsValidJson()
        {
            var obj = new CustomSlotTypeValueOptionDescriptorInteractionModel("Test");
            obj.AddSynonym("synName");
            obj.AddSynonym("secondSynName");
            var str = JsonSerializer.Serialize(obj);
            Assert.AreEqual($"{curlyBraceOpen}{dblQuote}value{dblQuote}:{dblQuote}Test{dblQuote},{dblQuote}synonyms{dblQuote}:[{dblQuote}synName{dblQuote},{dblQuote}secondSynName{dblQuote}]{curlyBraceClose}", str);
        }

    }
}
