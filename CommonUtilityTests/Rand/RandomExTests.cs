using CommonUtilityTests.Constant;
using NUnit.Framework;
using System;

namespace CommonUtility.Rand.Tests
{
    [TestFixture()]
    public class RandomExTests
    {
        [Test()]
        [Author(TestPropertyConstant.AuthorName, TestPropertyConstant.AuthorEmail)]
        public void NextStringTest(
            [Values(-10, 0, 10, 100)]
            int count,
            [Values(true, false)]
            bool upperLetter,
            [Values(true, false)]
            bool lowerLetter,
            [Values(true, false)]
            bool number
            )
        {
            const string upperPattern = "[A-Z]";
            const string lowerPattern = "[a-z]";
            const string numberPattern = "[0-9]";

            if (count <= 0)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() =>
                {
                    RandomEx.NextString(count, upperLetter, lowerLetter, number);
                });

                return;
            }

            if (!upperLetter && !lowerLetter && !number)
            {
                Assert.Throws<InvalidOperationException>(() =>
                {
                    RandomEx.NextString(count, upperLetter, lowerLetter, number);
                });

                return;
            }

            var actual = RandomEx.NextString(count, upperLetter, lowerLetter, number);

            Assert.IsNotEmpty(actual);

            if (upperLetter)
                StringAssert.IsMatch(upperPattern, actual);
            else
                StringAssert.DoesNotMatch(upperPattern, actual);

            if (lowerLetter)
                StringAssert.IsMatch(lowerPattern, actual);
            else
                StringAssert.DoesNotMatch(lowerPattern, actual);

            if (number)
                StringAssert.IsMatch(numberPattern, actual);
            else
                StringAssert.DoesNotMatch(numberPattern, actual);

            Assert.AreEqual(count, actual.Length);
        }
    }
}