using AlexaNetCore;
using DistanceLibrary;
using ExactMeasureSkill;
using NUnit.Framework;


namespace ExactMeasureSkill.Tests
{
    public class MetricDistanceUnitTest
    {
        [Test]
        public void ToWords_OneAndAHalfMeters_ReturnsProperString()
        {
            Assert.AreEqual("one meter and fifty centimeters".ToLower(), new MetricDistance(1.5).GetSpokenText().ToLower());
        }

        [Test]
        public void ToWords_OneKilometerFiveAndAHalfMeters_ReturnsProperString()
        {
            Assert.AreEqual("one kilometer and one meter and fifty centimeters".ToLower(), new MetricDistance(1001.5).GetSpokenText().ToLower());
        }

        [Test]
        public void ToWords_VeryLargeNumber_ReturnsProperString()
        {
            Assert.AreEqual("one hundred and twenty-three thousand four hundred and sixty-six kilometers and one meter and fifty centimeters".ToLower(), new MetricDistance(123466001.5).GetSpokenText().ToLower());
        }

        [Test]
        public void ToWords_OneMeter_ReturnsProperString()
        {
            Assert.AreEqual("one meter".ToLower(), new MetricDistance(1).GetSpokenText().ToLower());
        }

        [Test]
        public void ToWords_TenMeters_ReturnsProperString()
        {
            Assert.AreEqual("Ten meters".ToLower(), new MetricDistance(10).GetSpokenText().ToLower());
        }

        [Test]
        public void ToWords_TwelveMeters_ReturnsProperString()
        {
            Assert.AreEqual("twelve meters".ToLower(), new MetricDistance(12).GetSpokenText().ToLower());
        }

        [Test]
        public void ToWords_TwoKilometers_ReturnsProperString()
        {
            Assert.AreEqual("two kilometers".ToLower(), new MetricDistance(2000).GetSpokenText().ToLower());
        }

        [Test]
        public void ToWords_OneKilometer_ReturnsProperString()
        {
            Assert.AreEqual("one kilometer".ToLower(), new MetricDistance(1000).GetSpokenText().ToLower());
        }
    }
}
