using CommonUtilityTests.Constant;
using NUnit.Framework;
using System;

namespace CommonUtility.Convert.Tests
{
    [TestFixture()]
    [Category(nameof(Converter))]
    public class ConverterTests
    {
        /// <see cref="bool"/>
        /// <see cref="char"/>
        /// <see cref="sbyte"/>
        /// <see cref="byte"/>
        /// <see cref="short"/>
        /// <see cref="ushort"/>
        /// <see cref="int"/>
        /// <see cref="uint"/>
        /// <see cref="long"/>
        /// <see cref="ulong"/>
        /// <see cref="float"/>
        /// <see cref="double"/>
        /// <see cref="decimal"/>
        /// <see cref="DateTime"/>

        [Test()]
        [Author(TestPropertyConstant.AuthorName, TestPropertyConstant.AuthorEmail)]
        public void TryParseBoolTest()
        {
            var expectedValue = true;
            var actualValue = Converter.TryParse("true", false);
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test()]
        [Author(TestPropertyConstant.AuthorName, TestPropertyConstant.AuthorEmail)]
        public void TryParseCharTest()
        {
            var expectedValue = 't';
            var actualValue = Converter.TryParse("t", 'a');
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test()]
        [Author(TestPropertyConstant.AuthorName, TestPropertyConstant.AuthorEmail)]
        public void TryParseSbyteTest()
        {
            var expectedValue = (sbyte)-2;
            var actualValue = Converter.TryParse("-1230", (sbyte)-2);
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test()]
        [Author(TestPropertyConstant.AuthorName, TestPropertyConstant.AuthorEmail)]
        public void TryParseByteTest()
        {
            var expectedValue = (byte)1;
            var actualValue = Converter.TryParse("1", (byte)2);
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test()]
        [Author(TestPropertyConstant.AuthorName, TestPropertyConstant.AuthorEmail)]
        public void TryParseStringTest()
        {
            var expectedValue = "true";
            var actualValue = Converter.TryParse("true", "false");
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test()]
        [Author(TestPropertyConstant.AuthorName, TestPropertyConstant.AuthorEmail)]
        public void TryParseFloatTest()
        {
            var expectedValue = 3.5f;
            var actualValue = Converter.TryParse("3.5", 1.2f);
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test()]
        [Author(TestPropertyConstant.AuthorName, TestPropertyConstant.AuthorEmail)]
        public void TryParseDoubleTest()
        {
            var expectedValue = 3.5;
            var actualValue = Converter.TryParse("3.5", 1.2);
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test()]
        [Author(TestPropertyConstant.AuthorName, TestPropertyConstant.AuthorEmail)]
        public void TryParseDecimalTest()
        {
            var expectedValue = (decimal)2.13;
            var actualValue = Converter.TryParse("2.13", (decimal)1.2);
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test()]
        [Author(TestPropertyConstant.AuthorName, TestPropertyConstant.AuthorEmail)]
        public void TryParseDateTimeTest()
        {
            var expectedValue = new DateTime(2017, 6, 27, 22, 40, 0);
            var actualValue = Converter.TryParse("2017/6/27 22:40:00", DateTime.Now);
            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}