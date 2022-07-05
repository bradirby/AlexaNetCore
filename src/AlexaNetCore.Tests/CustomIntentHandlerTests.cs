using AlexaNetCore.Model;
using NUnit.Framework;
using System;

namespace AlexaNetCore.Tests;

public class CustomIntentHandlerTests
{
    [Test]
    public void CustomSlotType_NoValues_Throws()
    {
        var obj = new AlexaCustomSlotType("measureType");
        Assert.Throws<ArgumentException>(() => obj.GetInteractionModel());
    }
}