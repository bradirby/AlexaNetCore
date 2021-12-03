using System;
using AlexaSkillDotNet;
using NUnit.Framework;

namespace AlexaFlashBriefing.Tests
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
                    .SetContent("Meet Brads version of Echosim. A new online community tool for developers that simulates the look and feel of an Amazon Echo.")
                    .SetDisplayUrl("https://developer.amazon.com/public/community/blog");

                AddFlashBriefing(item);
                return this;
            }
        }
    }


}
