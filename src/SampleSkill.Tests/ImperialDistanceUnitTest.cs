

using AlexaNetCore;
using DistanceLibrary;
using NUnit.Framework;

namespace ExactMeasureSkill.Tests
{
    public class ImperialDistanceUnitTest
    {
        [Test]
        public void ToWords_ValidValues_ReturnsProperString()
        {
            Assert.AreEqual("Ten inches", new ImperialDistance(10).GetSpokenText());
            Assert.AreEqual("One foot", new ImperialDistance(12).GetSpokenText());
            Assert.AreEqual("Two feet", new ImperialDistance(24).GetSpokenText());
            Assert.AreEqual("One foot Two inches", new ImperialDistance(14).GetSpokenText());
            Assert.AreEqual("Two feet Five inches", new ImperialDistance(29).GetSpokenText());
        }
   
        
        [Test]
        public void GetSpokenText_OneHundredSixtyTwoAndOneQuarterInches()
        {
            var m = new ImperialDistance(162.25);
            var txt = m.GetSpokenText();
            Assert.AreEqual("Thirteen feet Six and one fourth inches".ToLower(), txt.ToLower());
        }

        [Test]
        public void GetSpokenText_OneHundredSixtyTwoThousandInches()
        {
            var m = new ImperialDistance(16200);
            var txt = m.GetSpokenText();
            Assert.AreEqual("One thousand three hundred and fifty feet".ToLower(), txt.ToLower());
        }

        [Test]
        public void GetSpokenText_OneHundredSixtyTwoThousandThreeInches()
        {
            var m = new ImperialDistance(16203);
            var txt = m.GetSpokenText();
            Assert.AreEqual("One thousand three hundred and fifty feet Three inches".ToLower(), txt.ToLower());
        }

        [Test]
        public void GetSpokenText_TenHundredSixtyTwoThousandThreeInches()
        {
            var m = new ImperialDistance(106203);
            var txt = m.GetSpokenText();
            Assert.AreEqual("One mile Three thousand five hundred and seventy feet Three inches".ToLower(), txt.ToLower());
        }

        [Test]
        public void GetSpokenText_TenHundredSixtyTwoThousandOneInch()
        {
            var m = new ImperialDistance(106201);
            var txt = m.GetSpokenText();
            Assert.AreEqual("One mile Three thousand five hundred and seventy feet One inch".ToLower(), txt.ToLower());
        }

        

        [Test]
        public void GetSpokenText_OneHundredSixtyTwoInches()
        {
            var m = new ImperialDistance(162);
            var txt = m.GetSpokenText();
            Assert.AreEqual("Thirteen feet Six inches", txt);
        }

        [Test]
        public void GetSpokenText_OneHundredSixtyTwoAndAHalfInches()
        {
            var m = new ImperialDistance(162.5);
            var txt = m.GetSpokenText();
            Assert.AreEqual("Thirteen feet Six and one half inches".ToLower(), txt.ToLower());
        }


        [Test]
        public void GetSpokenText_OneHundredSixtyTwoAndSixtyOneSixtyFourthsInches()
        {
            double val =  (61.0/64.0);
            val += 62.0;
            var m = new ImperialDistance(val);
            var txt = m.GetSpokenText();
            Assert.AreEqual("Five feet Two and sixty-one sixty-fourths inches".ToLower(), txt.ToLower());
        }

        [Test]
        public void TestFullRange()
        {
            Assert.AreEqual("one and one half inches", new ImperialDistance(1.5).GetSpokenText().ToLower());

            Assert.AreEqual("one and one fourth inches", new ImperialDistance(1.25).GetSpokenText().ToLower());
            Assert.AreEqual("one and three fourths inches", new ImperialDistance(1.75).GetSpokenText().ToLower());

            Assert.AreEqual("one and one eighth inches", new ImperialDistance(1.0 + 1.0 / 8.0).GetSpokenText().ToLower());
            Assert.AreEqual("one and one fourth inches", new ImperialDistance(1.0 + 2.0 / 8.0).GetSpokenText().ToLower());
            Assert.AreEqual("one and three eighths inches", new ImperialDistance(1.0 + 3.0 / 8.0).GetSpokenText().ToLower());
            Assert.AreEqual("one and one half inches", new ImperialDistance(1.0 + 4.0 / 8.0).GetSpokenText().ToLower());
            Assert.AreEqual("one and five eighths inches", new ImperialDistance(1.0 + 5.0 / 8.0).GetSpokenText().ToLower());
            Assert.AreEqual("one and three fourths inches", new ImperialDistance(1.0 + 6.0 / 8.0).GetSpokenText().ToLower());
            Assert.AreEqual("one and seven eighths inches", new ImperialDistance(1.0 + 7.0 / 8.0).GetSpokenText().ToLower());
            Assert.AreEqual("two inches", new ImperialDistance(1.0 + 8.0 / 8.0).GetSpokenText().ToLower());

            Assert.AreEqual("one and one sixteenth inches", new ImperialDistance(1.0 + 1.0 / 16.0).GetSpokenText().ToLower());
        }





    }
}
