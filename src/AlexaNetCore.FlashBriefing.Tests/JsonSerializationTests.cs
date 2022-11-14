using System;
using System.Threading.Tasks;
using AlexaNetCore;
using AlexaNetCore.Model;
using NUnit.Framework;

namespace AlexaNetCore.FlashBriefing.Tests
{
    public class JsonSerializationTests
    {

        [Test]
        public async Task SingleItemSerialization()
        {
            var briefing = await new TestBriefing().ProcessRequestAsync();
            Assert.AreEqual(1, briefing.Items.Count);

            var response = briefing.GetResponse(AlexaLocale.English_US);

            Assert.IsFalse(string.IsNullOrEmpty(response));
            Assert.IsTrue(response.Contains("urn:uuid:"));
        }

        private class TestBriefing : AlexaFlashBriefingBase
        {
            public override Task<AlexaFlashBriefingBase> ProcessRequestAsync()
            {
                var item = new AlexaTextBriefingItem()
                    .SetTitle("This is the title")
                    .SetContent("In Alexa news today, Alexa Net Core is taking the dot net development world by storm.")
                    .SetDisplayUrl("https://developer.amazon.com/public/community/blog");

                AddFlashBriefing(item);
                return Task.FromResult((AlexaFlashBriefingBase) this);
            }
        }
    }


}
