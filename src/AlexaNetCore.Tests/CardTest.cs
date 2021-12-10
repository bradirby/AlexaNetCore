using System;
using System.Runtime.CompilerServices;
using System.Text.Json;
using AlexaNetCore;
using NUnit.Framework;

namespace AlexaNetCore.Tests
{
   

    public class CardTest
    {

        private class TestAlexaSkill : AlexaSkillBase
        {
            public TestAlexaSkill()
            {
            }
        }

        [Test]
        public void CardIsAddedToResponse_IsRenderedInJson()
        {
            var skill = new TestAlexaSkill();
            skill.RegisterDefaultIntentHandlers();
            skill.LoadRequest(AmazonIntentSampleRequests.LaunchRequest()).ProcessRequest();
            skill.ResponseEnv.AddSimpleCard("card title to find", "card body to find");
            var json = skill.CreateAlexaResponse();

            Assert.IsTrue(json.Contains("card title to find"));
            Assert.IsTrue(json.Contains("card body to find"));
        }


        [Test]
        public void GetJson_LinkedAccount_RendersJsonCorrectly()
        {
            var c = new AlexaCard(AlexaCardType.LinkAccount, new ConsoleMessageLogger());
            c.SetText("text field");
            c.SetContentText("content field");
            c.SetTitleText("title field");
            var json = Serialize(c.GetJson(AlexaLocale.English_US));
            Assert.IsTrue(Serialize(json).Contains("LinkAccount"));
            Assert.IsFalse(Serialize(json).Contains("text field"));
            Assert.IsFalse(Serialize(json).Contains("title field"));
            Assert.IsFalse(Serialize(json).Contains("content field"));

        }

        [Test]
        public void GetJson_AskForPermission_RendersJsonCorrectly()
        {
            var c = new AlexaCard(AlexaCardType.AskForPermissionsConsent, new ConsoleMessageLogger());
            c.SetText("text field");
            c.SetContentText("content field");
            c.SetTitleText("title field");
            var json = Serialize(c.GetJson(AlexaLocale.English_US));
            Assert.IsTrue(Serialize(json).Contains("AskForPermission"));
            Assert.IsFalse(Serialize(json).Contains("text field"));
            Assert.IsFalse(Serialize(json).Contains("title field"));
            Assert.IsFalse(Serialize(json).Contains("content field"));

        }

        
        [Test]
        public void GetJson_Simple_RendersJsonCorrectly()
        {
            var c = new AlexaCard(AlexaCardType.Simple, new ConsoleMessageLogger());
            c.SetText("text field");
            c.SetContentText("content field");
            c.SetTitleText("title field");
            var json = Serialize(c.GetJson(AlexaLocale.English_US));
            Assert.IsTrue(Serialize(json).Contains("Simple"));
            Assert.IsFalse(Serialize(json).Contains("text field"));
            Assert.IsTrue(Serialize(json).Contains("title field"));
            Assert.IsTrue(Serialize(json).Contains("content field"));

            c = new AlexaCard(AlexaCardType.Standard, new ConsoleMessageLogger());
            json = Serialize(c.GetJson(AlexaLocale.English_US));
            Assert.IsTrue(Serialize(json).Contains("Standard"));
        }

        [Test]
        public void GetJson_Standard_RendersJsonCorrectly()
        {
            var c = new AlexaCard(AlexaCardType.Standard, new ConsoleMessageLogger());
            c.SetText("text field");
            c.SetContentText("content field");
            c.SetTitleText("title field");
            var json = Serialize(c.GetJson(AlexaLocale.English_US));
            Assert.IsTrue(Serialize(json).Contains("Standard"));
            Assert.IsTrue(Serialize(json).Contains("text field"));
            Assert.IsFalse(Serialize(json).Contains("content field"));
            Assert.IsTrue(Serialize(json).Contains("title field"));
        }

        private string Serialize(dynamic obj)
        {
            string outputStr = JsonSerializer.Serialize(obj);
            outputStr = outputStr.Replace(@"\\", "");
            return outputStr;
        }
    }

}
