using System;
using Newtonsoft.Json;
using NUnit.Framework;

namespace SkillForNet.Tests
{

    public class AlexaSkillBaseTest
    {


        [Test]
        public void ProcessRequest_CallsProperMethods()
        {
            var c = new SkillTest();
            c.ProcessRequest(SampleRequests.GetLaunchRequest());
            Assert.AreEqual(true, c.VisitedList.Contains("ProcessLaunchRequest"));
            Assert.AreEqual(1, c.VisitedList.Count);

            c = new SkillTest();
            c.ProcessRequest(SampleRequests.GetIntentRequest());
            Assert.AreEqual(true, c.VisitedList.Contains("ProcessCustomIntentRequest"));
            Assert.AreEqual(1, c.VisitedList.Count);

            c = new SkillTest();
            c.ProcessRequest(SampleRequests.GetSessionEndRequest());
            Assert.AreEqual(true, c.VisitedList.Contains("ProcessSessionEndedRequest"));
            Assert.AreEqual(1, c.VisitedList.Count);
        }
    }
}
