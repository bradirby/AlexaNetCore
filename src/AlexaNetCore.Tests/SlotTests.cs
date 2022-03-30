using System;
using System.Text.Json;
using AlexaNetCore.InteractionModel;
using NUnit.Framework;

namespace AlexaNetCore.Tests
{
    public class SlotTests
    {

        [Test]
        public void CustomSlotTypeValueOptionDescriptorInteractionModel_NoSynonyms_ReturnsValidJson()
        {
            var obj = new CustomSlotTypeValueOptionDescriptor("Test");
            var str = JsonSerializer.Serialize(obj.GetInteractionModel());
            var expectedVal = $"{{\"value\":\"Test\"}}";
            Assert.AreEqual(expectedVal, str);
        }

        [Test]
        public void CustomSlotTypeValueOptionDescriptorInteractionModel_OneSynonym_ReturnsValidJson()
        {
            var obj = new CustomSlotTypeValueOptionDescriptor("Test");
            obj.AddSynonym("synName");
            var str = JsonSerializer.Serialize(obj.GetInteractionModel());
            var expectedVal = $"{{\"value\":\"Test\",\"synonyms\":[\"synName\"]}}";
            Assert.AreEqual(expectedVal, str);
        }

        [Test]
        public void CustomSlotTypeValueOptionDescriptorInteractionModel_TwoSynonyms_ReturnsValidJson()
        {
            var obj = new CustomSlotTypeValueOptionDescriptor("Test");
            obj.AddSynonym("synName");
            obj.AddSynonym("secondSynName");
            var str = JsonSerializer.Serialize(obj.GetInteractionModel());
            var expectedVal = $"{{\"value\":\"Test\",\"synonyms\":[\"synName\",\"secondSynName\"]}}";
            Assert.AreEqual(expectedVal, str);
        }



        
        [Test]
        public void CustomSlotTypeValueOptionDescriptor_NoSynonyms_ReturnsValidJson()
        {
            var obj = new CustomSlotTypeValueOptionDescriptor("Test");
            var str = JsonSerializer.Serialize(obj.GetInteractionModel());
            var expectedVal = $"{{\"value\":\"Test\"}}";
            Assert.AreEqual(expectedVal, str);
        }


        [Test]
        public void CustomSlotTypeValueOptionDescriptor_OneSynonym_ReturnsValidJson()
        {
            var obj = new CustomSlotTypeValueOptionDescriptor("Test");
            obj.AddSynonym("synName");
            var str = JsonSerializer.Serialize(obj.GetInteractionModel());
            var expectedVal = $"{{\"value\":\"Test\",\"synonyms\":[\"synName\"]}}";
            Assert.AreEqual(expectedVal, str);
        }

        [Test]
        public void CustomSlotTypeValueOptionDescriptor_TwoSynonyms_ReturnsValidJson()
        {
            var obj = new CustomSlotTypeValueOptionDescriptor("Test");
            obj.AddSynonym("synName");
            obj.AddSynonym("secondSynName");
            var str = JsonSerializer.Serialize(obj.GetInteractionModel());
            var expectedVal = $"{{\"value\":\"Test\",\"synonyms\":[\"synName\",\"secondSynName\"]}}";
            Assert.AreEqual(expectedVal, str);
        }


        
        [Test]
        public void CustomSlotTypeValueOption_NoSynonyms_ReturnsValidJson()
        {
            var obj = new CustomSlotTypeValueOption("Test");
            var str = JsonSerializer.Serialize(obj.GetInteractionModel());
            var expectedVal = $"{{\"name\":{{\"value\":\"Test\"}}}}";
            Assert.AreEqual(expectedVal, str);
        }


        [Test]
        public void CustomSlotTypeValueOption_OneSynonym_ReturnsValidJson()
        {
            var obj = new CustomSlotTypeValueOption("Test");
            obj.AddSynonym("synName");
            var str = JsonSerializer.Serialize(obj.GetInteractionModel());
            var expectedVal = $"{{\"name\":{{\"value\":\"Test\",\"synonyms\":[\"synName\"]}}}}";
            Assert.AreEqual(expectedVal, str);
        }

        [Test]
        public void CustomSlotTypeValueOption_TwoSynonyms_ReturnsValidJson()
        {
            var obj = new CustomSlotTypeValueOption("Test");
            obj.AddSynonym("synName");
            obj.AddSynonym("secondSynName");
            var str = JsonSerializer.Serialize(obj.GetInteractionModel());
            var expectedVal = $"{{\"name\":{{\"value\":\"Test\",\"synonyms\":[\"synName\",\"secondSynName\"]}}}}";
            Assert.AreEqual(expectedVal, str);
        }



                
        [Test]
        public void CustomSlotType_NoValues_Throws()
        {
            var obj = new CustomSlotType("measureType");
            Assert.Throws<ArgumentException>(() => obj.GetInteractionModel());
        }

        [Test]
        public void CustomSlotType_OneValueNoSyn_ReturnsValidJson()
        {
            var obj = new CustomSlotType("measureType");
            obj.AddValueOption(new CustomSlotTypeValueOption("opt1"));
            var str = JsonSerializer.Serialize(obj.GetInteractionModel());
            var expectedVal = $"{{\"name\":\"measureType\",\"values\":[{{\"name\":{{\"value\":\"opt1\"}}}}]}}";
            Assert.AreEqual(expectedVal, str);
        }

        [Test]
        public void CustomSlotType_OneValueWithSyn_ReturnsValidJson()
        {
            var obj = new CustomSlotType("measureType");
            obj.AddValueOption(new CustomSlotTypeValueOption("opt1",new[] {"synName","secondSynName"}));
            var str = JsonSerializer.Serialize(obj.GetInteractionModel());
            var expectedVal = $"{{\"name\":\"measureType\",\"values\":[{{\"name\":{{\"value\":\"opt1\",\"synonyms\":[\"synName\",\"secondSynName\"]}}}}]}}";
            Assert.AreEqual(expectedVal, str);
        }

        [Test]
        public void CustomSlotType_TwoValuesNoSyn_ReturnsValidJson()
        {
            var obj = new CustomSlotType("measureType");
            obj.AddValueOption(new CustomSlotTypeValueOption("opt1"));
            obj.AddValueOption(new CustomSlotTypeValueOption("opt2"));
            var str = JsonSerializer.Serialize(obj.GetInteractionModel());
            var expectedVal = $"{{\"name\":\"measureType\",\"values\":[{{\"name\":{{\"value\":\"opt1\"}}}},{{\"name\":{{\"value\":\"opt2\"}}}}]}}";
            Assert.AreEqual(expectedVal, str);
        }

        [Test]
        public void CustomSlotType_TwoValuesWithSyn_ReturnsValidJson()
        {
            var obj = new CustomSlotType("measureType");
            obj.AddValueOption(new CustomSlotTypeValueOption("opt1",new[] {"synName","secondSynName"}));
            obj.AddValueOption(new CustomSlotTypeValueOption("opt2",new[] {"synName2","secondSynName2"}));
            var str = JsonSerializer.Serialize(obj.GetInteractionModel());
            var expectedVal = $"{{\"name\":\"measureType\",\"values\":[{{\"name\":{{\"value\":\"opt1\",\"synonyms\":[\"synName\",\"secondSynName\"]}}}},{{\"name\":{{\"value\":\"opt2\",\"synonyms\":[\"synName2\",\"secondSynName2\"]}}}}]}}";
            Assert.AreEqual(expectedVal, str);
        }

    }
}
