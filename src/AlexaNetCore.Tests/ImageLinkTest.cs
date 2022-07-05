using System;
using System.Text.Json;
using AlexaNetCore;
using AlexaNetCore.Model;
using NUnit.Framework;

namespace AlexaNetCore.Tests
{

    public class ImageLinkTest
    {
        [Test]
        public void GetJson_TypeProperty()
        {
            var c = new AlexaImageLink("","");
            var obj = c.GetJson();
            Assert.IsNull(obj);

            c = new AlexaImageLink("http://www.mysite.com/small.jpg","http://www.mysite.com/large.jpg");
            var json = Serialize(c.GetJson());
            Assert.IsTrue(Serialize(json).Contains("small"));

            c = new AlexaImageLink("","http://www.mysite.com/large.jpg");
            json = Serialize(c.GetJson());
            Assert.IsTrue(Serialize(json).Contains("large"));

            c = new AlexaImageLink("http://www.mysite.com/small.jpg","http://www.mysite.com/large.jpg");
            json = Serialize(c.GetJson());
            Assert.IsTrue(Serialize(json).Contains("small"));
            Assert.IsTrue(Serialize(json).Contains("large"));

        }
        private string Serialize(dynamic obj)
        {
            string outputStr = JsonSerializer.Serialize(obj);
            outputStr = outputStr.Replace(@"\\", "");
            return outputStr;
        }
    }

}
