using CommonUtilityTests.Constant;
using NUnit.Framework;
using System;

namespace CommonUtility.Extension.Tests
{
    [TestFixture()]
    [Category(nameof(DayOfWeekExtension))]
    public class DayOfWeekExtensionTests
    {
        [Test()]
        [Author(TestPropertyConstant.AuthorName, TestPropertyConstant.AuthorEmail)]
        public void IsWeekendTest()
        {
            var expectedValue = false;
            var actualValue = DayOfWeek.Monday.IsWeekend();

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test()]
        [Author(TestPropertyConstant.AuthorName, TestPropertyConstant.AuthorEmail)]
        public void IsWeekendTest1()
        {
            var expectedValue = true;
            var actualValue = DayOfWeek.Sunday.IsWeekend();

            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}