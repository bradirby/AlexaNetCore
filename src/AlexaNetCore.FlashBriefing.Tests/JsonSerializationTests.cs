using System;
using AlexaNetCore;
using NUnit.Framework;

namespace AlexaNetCore.FlashBriefing.Tests
{
    public class JsonSerializationTests
    {

        [Test]
        public void SingleItemSerialization()
        {
            var briefing = new TestBriefing().ProcessRequest();
            Assert.AreEqual(1, briefing.Items.Count);

            var response = briefing.CreateAlexaResponse();

            Assert.IsFalse(string.IsNullOrEmpty(response));
            Assert.IsTrue(response.Contains("urn:uuid:"));
        }

        private class TestBriefing : AlexaFlashBriefingBase
        {
            public override AlexaFlashBriefingBase ProcessRequest()
            {
                var item = new AlexaTextBriefingItem()
                    .SetTitle("This is the title")
                    .SetContent("In Alexa news today, Alexa Net Core is taking the dot net development world by storm.")
                    .SetDisplayUrl("https://developer.amazon.com/public/community/blog");

                AddFlashBriefing(item);
                return this;
            }
        }
    }


}
