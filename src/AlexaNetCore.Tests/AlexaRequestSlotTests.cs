using System.Linq;
using System.Text.Json;
using AlexaNetCore.RequestModel;
using AlexaNetCore.Tests.TestData;
using NUnit.Framework;

namespace AlexaNetCore.Tests;

public class AlexaRequestSlotTests
{
    [Test]
    public void DeserializationTest()
    {
        var request = JsonSerializer.Deserialize<AlexaRequestEnvelope>(DialogRequests.DialogCompleted);
        Assert.IsNotNull(request.Request);
        Assert.AreEqual("RecommendationIntent", request.Request.Intent.Name);
        Assert.AreEqual("allergies", request.Request.Intent.Slots.First().Value.Name);

        var slotVal = request.Request.Intent.Slots.First().Value;
        Assert.AreEqual("amzn1.er-authority.echo-sdk.amzn1.ask.skill.xxx.allergiesType", slotVal.Resolutions.ResolutionsPerAuthority.First().Authority);

        var slotResAuth = slotVal.Resolutions.ResolutionsPerAuthority.First();
        Assert.IsNotNull( slotResAuth.Status);
        Assert.AreEqual("ER_SUCCESS_MATCH", slotResAuth.Status.Code);

        var slotMatchedValues = slotResAuth.Values.First();
        Assert.AreEqual("PEA", slotMatchedValues.Value.Id);
    }
}