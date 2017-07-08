using CommonUtilityTests.Constant;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CommonUtility.Extension.Tests
{
    [TestClass()]
    public class DayOfWeekExtensionTests
    {
        [TestMethod()]
        [TestProperty(TestPropertyConstant.Author, "3gbywork")]
        public void IsWeekendTest()
        {
            var expectedValue = false;
            var actualValue = DayOfWeek.Monday.IsWeekend();

            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod()]
        [TestProperty(TestPropertyConstant.Author, "3gbywork")]
        public void IsWeekendTest1()
        {
            var expectedValue = true;
            var actualValue = DayOfWeek.Sunday.IsWeekend();

            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}