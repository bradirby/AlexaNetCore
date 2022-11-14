using System;
using System.Text.Json;
using System.Threading.Tasks;
using AlexaNetCore.Model;
using NUnit.Framework;

namespace AlexaNetCore.Tests.InteractionModelTests;

internal class InteractionModelTests_Slots
{
    private string dblQuote => "\"";


    [Test]
    public void Intent_OneSampleInvocations_GeneratesProperCollection()
    {
        var intent = new ModelGenIntent().AddSampleInvocation("find this invocation");

        var slot = intent.AddSlot("slotname",AlexaBuiltInSlotTypes.FourDigitNumber, false);

        var obj = intent.GetInteractionModel();

        var str = JsonSerializer.Serialize(obj);
        Assert.IsTrue(str.Contains($"{dblQuote}samples{dblQuote}:[{dblQuote}find this invocation{dblQuote}]"));
    }




    //private class ModelGenSkill : AlexaSkillBase
    //{

    //}


    private class ModelGenIntent : AlexaIntentHandlerBase
    {
        public ModelGenIntent() : base(AlexaIntentType.Custom, "ModelGenIntent")
        {
        }

        public override Task ProcessAsync()
        {
            throw new NotImplementedException();
        }
    }

}