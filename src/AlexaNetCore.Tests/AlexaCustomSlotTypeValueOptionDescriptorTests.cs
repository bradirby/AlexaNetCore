using System.Text.Json;
using AlexaNetCore.Model;
using NUnit.Framework;

namespace AlexaNetCore.Tests;

public class AlexaCustomSlotTypeValueOptionDescriptorTests
{
    [Test]
    public void CustomSlotTypeValueOptionDescriptorInteractionModel_NoSynonyms_ReturnsValidJson()
    {
        var obj = new AlexaCustomSlotTypeValueOptionDescriptor("Test");
        var str = JsonSerializer.Serialize(obj.GetInteractionModel());
        var expectedVal = $"{{\"value\":\"Test\"}}";
        Assert.AreEqual(expectedVal, str);
    }

    [Test]
    public void CustomSlotTypeValueOptionDescriptorInteractionModel_OneSynonym_ReturnsValidJson()
    {
        var obj = new AlexaCustomSlotTypeValueOptionDescriptor("Test")
            .AddSynonym("synName");
        var str = JsonSerializer.Serialize(obj.GetInteractionModel());
        var expectedVal = $"{{\"value\":\"Test\",\"synonyms\":[\"synName\"]}}";
        Assert.AreEqual(expectedVal, str);
    }

    [Test]
    public void CustomSlotTypeValueOptionDescriptorInteractionModel_TwoSynonyms_ReturnsValidJson()
    {
        var obj = new AlexaCustomSlotTypeValueOptionDescriptor("Test")
            .AddSynonym("synName")
            .AddSynonym("secondSynName");
        var str = JsonSerializer.Serialize(obj.GetInteractionModel());
        var expectedVal = $"{{\"value\":\"Test\",\"synonyms\":[\"synName\",\"secondSynName\"]}}";
        Assert.AreEqual(expectedVal, str);
    }

        

        
    [Test]
    public void CustomSlotTypeValueOptionDescriptor_NoSynonyms_ReturnsValidJson()
    {
        var obj = new AlexaCustomSlotTypeValueOptionDescriptor("Test");
        var str = JsonSerializer.Serialize(obj.GetInteractionModel());
        var expectedVal = $"{{\"value\":\"Test\"}}";
        Assert.AreEqual(expectedVal, str);
    }


    [Test]
    public void CustomSlotTypeValueOptionDescriptor_OneSynonym_ReturnsValidJson()
    {
        var obj = new AlexaCustomSlotTypeValueOptionDescriptor("Test")
            .AddSynonym("synName");
        var str = JsonSerializer.Serialize(obj.GetInteractionModel());
        var expectedVal = $"{{\"value\":\"Test\",\"synonyms\":[\"synName\"]}}";
        Assert.AreEqual(expectedVal, str);
    }

    [Test]
    public void CustomSlotTypeValueOptionDescriptor_TwoSynonyms_ReturnsValidJson()
    {
        var obj = new AlexaCustomSlotTypeValueOptionDescriptor("Test")
            .AddSynonym("synName")
            .AddSynonym("secondSynName");
        var str = JsonSerializer.Serialize(obj.GetInteractionModel());
        var expectedVal = $"{{\"value\":\"Test\",\"synonyms\":[\"synName\",\"secondSynName\"]}}";
        Assert.AreEqual(expectedVal, str);
    }


        
    [Test]
    public void CustomSlotTypeValueOption_NoSynonyms_ReturnsValidJson()
    {
        var obj = new AlexaCustomSlotTypeValueOptionDescriptor("Test");
        var str = JsonSerializer.Serialize(obj.GetInteractionModel());
        var expectedVal = $"{{\"value\":\"Test\"}}";
        Assert.AreEqual(expectedVal, str);
    }


    [Test]
    public void CustomSlotTypeValueOption_OneSynonym_ReturnsValidJson()
    {
        var obj = new AlexaCustomSlotTypeValueOptionDescriptor("Test")
            .AddSynonym("synName");
        var str = JsonSerializer.Serialize(obj.GetInteractionModel());
        var expectedVal = $"{{\"value\":\"Test\",\"synonyms\":[\"synName\"]}}";
        Assert.AreEqual(expectedVal, str);
    }

    [Test]
    public void CustomSlotTypeValueOption_TwoSynonyms_ReturnsValidJson()
    {
        var obj = new AlexaCustomSlotTypeValueOptionDescriptor("Test")
            .AddSynonym("synName")
            .AddSynonym("secondSynName");
        var str = JsonSerializer.Serialize(obj.GetInteractionModel());
        var expectedVal = $"{{\"value\":\"Test\",\"synonyms\":[\"synName\",\"secondSynName\"]}}";
        Assert.AreEqual(expectedVal, str);
    }


}