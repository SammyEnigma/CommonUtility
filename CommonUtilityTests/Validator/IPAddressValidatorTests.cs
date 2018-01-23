using CommonUtilityTests.Constant;
using NUnit.Framework;

namespace CommonUtility.Validator.Tests
{
    [TestFixture()]
    [Category(nameof(IPAddressValidator))]
    public class IPAddressValidatorTests
    {
        [Test()]
        [Author(TestPropertyConstant.AuthorName, TestPropertyConstant.AuthorEmail)]
        public void IsValidIPv4TestT(
            [Values("192.168.01.01", "000.0.1.000")]
            string ip,
            [Values(true)]
            bool expected)
        {
            var actual = IPAddressValidator.IsValidIPv4(ip);

            Assert.AreEqual(expected, actual);
        }

        [Test()]
        [Author(TestPropertyConstant.AuthorName, TestPropertyConstant.AuthorEmail)]
        public void IsValidIPv4TestF(
            [Values("256.168.01.01", "0256.168.01.01", "192.168.01.01.1", "01.01.1")]
            string ip,
            [Values(false)]
            bool expected)
        {
            var actual = IPAddressValidator.IsValidIPv4(ip);

            Assert.AreEqual(expected, actual);
        }

        [Test()]
        [Author(TestPropertyConstant.AuthorName, TestPropertyConstant.AuthorEmail)]
        public void IsValidPortTestT(
            [Values("65535", "0")]
            string port,
            [Values(true)]
            bool expected)
        {
            var actual = IPAddressValidator.IsValidPort(port);

            Assert.AreEqual(expected, actual);
        }

        [Test()]
        [Author(TestPropertyConstant.AuthorName, TestPropertyConstant.AuthorEmail)]
        public void IsValidPortTestF(
            [Values("65538", "-1")]
            string port,
            [Values(false)]
            bool expected)
        {
            var actual = IPAddressValidator.IsValidPort(port);

            Assert.AreEqual(expected, actual);
        }
    }
}