using System.Text.Json;
using System.Threading.Tasks;
using AlexaNetCore.Model;
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
        public async Task CardIsAddedToResponse_IsRenderedInJson()
        {
            var skill = await new TestAlexaSkill()
                .RegisterIntentHandler(new DefaultCancelIntentHandler())
                .RegisterIntentHandler(new DefaultHelpIntentHandler())
                .RegisterIntentHandler(new DefaultFallbackIntentHandler())
                .RegisterIntentHandler(new DefaultLaunchIntentHandler())
                .RegisterIntentHandler(new DefaultSessionEndRequest())
                .RegisterIntentHandler(new DefaultStartOverIntentHandler())
                .RegisterIntentHandler(new DefaultStopIntentHandler())
                .LoadRequest(AmazonIntentSampleRequests.LaunchRequest())
                .ProcessRequestAsync();
            skill.AddCard("card title to find", "card body to find");

            var json = skill.GetResponse();

            Assert.IsTrue(json.Contains("card title to find"));
            Assert.IsTrue(json.Contains("card body to find"));
        }


        [Test]
        public void GetJson_LinkedAccount_RendersJsonCorrectly()
        {
            var c = new AlexaCard(AlexaCardType.LinkAccount, "old title", "old text")
                .SetText("text field")
                .SetContentText("content field")
                .SetTitleText("title field");
            var json = Serialize(c.CreateAlexaResponse(AlexaLocale.English_US));
            Assert.IsTrue(Serialize(json).Contains("LinkAccount"));
            Assert.IsFalse(Serialize(json).Contains("text field"));
            Assert.IsFalse(Serialize(json).Contains("title field"));
            Assert.IsFalse(Serialize(json).Contains("content field"));

        }

        [Test]
        public void GetJson_AskForPermission_RendersJsonCorrectly()
        {
            var c = new AlexaCard(AlexaCardType.AskForPermissionsConsent, "old title", "old text")
                .SetText("text field")
                .SetContentText("content field")
                .SetTitleText("title field");
            var json = Serialize(c.CreateAlexaResponse(AlexaLocale.English_US));
            Assert.IsTrue(Serialize(json).Contains("AskForPermission"));
            Assert.IsFalse(Serialize(json).Contains("text field"));
            Assert.IsFalse(Serialize(json).Contains("title field"));
            Assert.IsFalse(Serialize(json).Contains("content field"));

        }


        [Test]
        public void GetJson_Simple_RendersJsonCorrectly()
        {
            var c = new AlexaCard(AlexaCardType.Simple, "old title", "old text")
                .SetText("text field")
                .SetContentText("content field")
                .SetTitleText("title field");
            var json = Serialize(c.CreateAlexaResponse(AlexaLocale.English_US));
            Assert.IsTrue(Serialize(json).Contains("Simple"));
            Assert.IsFalse(Serialize(json).Contains("text field"));
            Assert.IsTrue(Serialize(json).Contains("title field"));
            Assert.IsTrue(Serialize(json).Contains("content field"));

            c = new AlexaCard(AlexaCardType.Standard, "old title", "old text");
            json = Serialize(c.CreateAlexaResponse(AlexaLocale.English_US));
            Assert.IsTrue(Serialize(json).Contains("Standard"));
        }

        [Test]
        public void GetJson_Standard_RendersJsonCorrectly()
        {
            var c = new AlexaCard(AlexaCardType.Standard, "old title", "old text")
                .SetText("text field")
                .SetContentText("content field")
                .SetTitleText("title field");
            var json = Serialize(c.CreateAlexaResponse(AlexaLocale.English_US));
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