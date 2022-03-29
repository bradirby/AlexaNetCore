using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;
using AlexaNetCore.InteractionModel;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AlexaNetCore.Tests
{
    public class SlotTests
    {
        private string dblQuote => "\"";
        private string curlyOpen => "{";
        private string curlyClose => "}";

        [Test]
        public void CustomSlotTypeValueOptionDescriptorInteractionModel_NoSynonyms_ReturnsValidJson()
        {
            var obj = new CustomSlotTypeValueOptionDescriptorInteractionModel("Test");
            var str = JsonSerializer.Serialize(obj);
            var expectedVal = $"{{\"value\":\"Test\",\"synonyms\":[]}}";
            Assert.AreEqual(expectedVal, str);
        }

        [Test]
        public void CustomSlotTypeValueOptionDescriptorInteractionModel_OneSynonym_ReturnsValidJson()
        {
            var obj = new CustomSlotTypeValueOptionDescriptorInteractionModel("Test");
            obj.AddSynonym("synName");
            var str = JsonSerializer.Serialize(obj);
            var expectedVal = $"{{\"value\":\"Test\",\"synonyms\":[\"synName\"]}}";
            Assert.AreEqual(expectedVal, str);
        }

        [Test]
        public void CustomSlotTypeValueOptionDescriptorInteractionModel_TwoSynonyms_ReturnsValidJson()
        {
            var obj = new CustomSlotTypeValueOptionDescriptorInteractionModel("Test");
            obj.AddSynonym("synName");
            obj.AddSynonym("secondSynName");
            var str = JsonSerializer.Serialize(obj);
            var expectedVal = $"{{\"value\":\"Test\",\"synonyms\":[\"synName\",\"secondSynName\"]}}";
            Assert.AreEqual(expectedVal, str);
        }



        
        [Test]
        public void CustomSlotTypeValueOptionInteractionModel_NoSynonyms_ReturnsValidJson()
        {
            var obj = new CustomSlotTypeValueOptionInteractionModel("Test");
            var str = JsonSerializer.Serialize(obj);
            var expectedVal = $"{{\"name\":{{\"value\":\"Test\",\"synonyms\":[]}}}}";
            Assert.AreEqual(expectedVal, str);
        }


        [Test]
        public void CustomSlotTypeValueOptionInteractionModel_OneSynonym_ReturnsValidJson()
        {
            var obj = new CustomSlotTypeValueOptionInteractionModel("Test");
            obj.AddSynonym("synName");
            var str = JsonSerializer.Serialize(obj);
            var expectedVal = $"{{\"name\":{{\"value\":\"Test\",\"synonyms\":[\"synName\"]}}}}";
            Assert.AreEqual(expectedVal, str);
        }

        [Test]
        public void CustomSlotTypeValueOptionInteractionModel_TwoSynonyms_ReturnsValidJson()
        {
            var obj = new CustomSlotTypeValueOptionInteractionModel("Test");
            obj.AddSynonym("synName");
            obj.AddSynonym("secondSynName");
            var str = JsonSerializer.Serialize(obj);
            var expectedVal = $"{{\"name\":{{\"value\":\"Test\",\"synonyms\":[\"synName\",\"secondSynName\"]}}}}";
            Assert.AreEqual(expectedVal, str);
        }





                
        [Test]
        public void CustomSlotTypeInteractionModel_NoValues_ReturnsValidJson()
        {
            var obj = new CustomSlotTypeInteractionModel("measureType");
            var str = JsonSerializer.Serialize(obj);
            var expectedVal = $"{{\"name\":\"measureType\",\"values\":[]}}";
            Assert.AreEqual(expectedVal, str);
        }

        [Test]
        public void CustomSlotTypeInteractionModel_OneValueNoSyn_ReturnsValidJson()
        {
            var obj = new CustomSlotTypeInteractionModel("measureType");
            obj.AddOption(new CustomSlotTypeValueOptionInteractionModel("opt1"));
            var str = JsonSerializer.Serialize(obj);
            var expectedVal = $"{{\"name\":\"measureType\",\"values\":[{{\"name\":{{\"value\":\"opt1\",\"synonyms\":[]}}}}]}}";
            Assert.AreEqual(expectedVal, str);
        }

        [Test]
        public void CustomSlotTypeInteractionModel_OneValueWithSyn_ReturnsValidJson()
        {
            var obj = new CustomSlotTypeInteractionModel("measureType");
            obj.AddOption(new CustomSlotTypeValueOptionInteractionModel("opt1",new[] {"synName","secondSynName"}));
            var str = JsonSerializer.Serialize(obj);
            var expectedVal = $"{{\"name\":\"measureType\",\"values\":[{{\"name\":{{\"value\":\"opt1\",\"synonyms\":[\"synName\",\"secondSynName\"]}}}}]}}";
            Assert.AreEqual(expectedVal, str);
        }

        [Test]
        public void CustomSlotTypeInteractionModel_TwoValuesNoSyn_ReturnsValidJson()
        {
            var obj = new CustomSlotTypeInteractionModel("measureType");
            obj.AddOption(new CustomSlotTypeValueOptionInteractionModel("opt1"));
            obj.AddOption(new CustomSlotTypeValueOptionInteractionModel("opt2"));
            var str = JsonSerializer.Serialize(obj);
            var expectedVal = $"{{\"name\":\"measureType\",\"values\":[{{\"name\":{{\"value\":\"opt1\",\"synonyms\":[]}}}},{{\"name\":{{\"value\":\"opt2\",\"synonyms\":[]}}}}]}}";
            Assert.AreEqual(expectedVal, str);
        }

        [Test]
        public void CustomSlotTypeInteractionModel_TwoValuesWithSyn_ReturnsValidJson()
        {
            var obj = new CustomSlotTypeInteractionModel("measureType");
            obj.AddOption(new CustomSlotTypeValueOptionInteractionModel("opt1",new[] {"synName","secondSynName"}));
            obj.AddOption(new CustomSlotTypeValueOptionInteractionModel("opt2",new[] {"synName2","secondSynName2"}));
            var str = JsonSerializer.Serialize(obj);
            var expectedVal = $"{{\"name\":\"measureType\",\"values\":[{{\"name\":{{\"value\":\"opt1\",\"synonyms\":[\"synName\",\"secondSynName\"]}}}}]}}";
            Assert.AreEqual(expectedVal, str);
        }

    }
}
