using System;
using System.Text.Json;
using AlexaNetCore.InteractionModel;
using AlexaNetCore.Model;
using NUnit.Framework;

namespace AlexaNetCore.Tests
{
    public class AlexaCustomSlotTypeTests
    {
                
        [Test]
        public void CustomSlotType_NoValues_Throws()
        {
            var obj = new AlexaCustomSlotType("measureType");
            Assert.Throws<ArgumentException>(() => obj.GetInteractionModel());
        }

        [Test]
        public void CustomSlotType_OneValueNoSyn_ReturnsValidJson()
        {
            var obj = new AlexaCustomSlotType("measureType")
                .AddValueOption(new AlexaCustomSlotTypeValueOption("", "opt1"));
            var str = JsonSerializer.Serialize(obj.GetInteractionModel());
            var expectedVal = $"{{\"name\":\"measureType\",\"values\":[{{\"name\":{{\"value\":\"opt1\"}}}}]}}";
            Assert.AreEqual(expectedVal, str);
        }

        [Test]
        public void CustomSlotType_OneValueWithSyn_ReturnsValidJson()
        {
            var obj = new AlexaCustomSlotType("measureType")
                .AddValueOption(new AlexaCustomSlotTypeValueOption( "", "opt1",new[] {"synName","secondSynName"}));
            var str = JsonSerializer.Serialize(obj.GetInteractionModel());
            var expectedVal = $"{{\"name\":\"measureType\",\"values\":[{{\"name\":{{\"value\":\"opt1\",\"synonyms\":[\"synName\",\"secondSynName\"]}}}}]}}";
            Assert.AreEqual(expectedVal, str);
        }

        [Test]
        public void CustomSlotType_TwoValuesNoSyn_ReturnsValidJson()
        {
            var obj = new AlexaCustomSlotType("measureType")
                .AddValueOption(new AlexaCustomSlotTypeValueOption("", "opt1"))
                .AddValueOption(new AlexaCustomSlotTypeValueOption( "","opt2"));
            var str = JsonSerializer.Serialize(obj.GetInteractionModel());
            var expectedVal = $"{{\"name\":\"measureType\",\"values\":[{{\"name\":{{\"value\":\"opt1\"}}}},{{\"name\":{{\"value\":\"opt2\"}}}}]}}";
            Assert.AreEqual(expectedVal, str);
        }

        [Test]
        public void CustomSlotType_TwoValuesWithSyn_ReturnsValidJson()
        {
            var obj = new AlexaCustomSlotType("measureType")
                .AddValueOption(new AlexaCustomSlotTypeValueOption("", "opt1",new[] {"synName","secondSynName"}))
                .AddValueOption(new AlexaCustomSlotTypeValueOption("", "opt2",new[] {"synName2","secondSynName2"}));
            var str = JsonSerializer.Serialize(obj.GetInteractionModel());
            var expectedVal = $"{{\"name\":\"measureType\",\"values\":[{{\"name\":{{\"value\":\"opt1\",\"synonyms\":[\"synName\",\"secondSynName\"]}}}},{{\"name\":{{\"value\":\"opt2\",\"synonyms\":[\"synName2\",\"secondSynName2\"]}}}}]}}";
            Assert.AreEqual(expectedVal, str);
        }

    }
}
