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
        public void IsValidIPv4Test([Values("192.168.01.01", "000.0.1.000")] string ip)
        {
            var expected = IPAddressValidator.IsValidIPv4(ip);

            Assert.AreEqual(expected, true);
        }

        [Test()]
        [Author(TestPropertyConstant.AuthorName, TestPropertyConstant.AuthorEmail)]
        public void IsValidIPv4Test1([Values("256.168.01.01", "0256.168.01.01", "192.168.01.01.1", "01.01.1")] string ip)
        {
            var expected = IPAddressValidator.IsValidIPv4(ip);

            Assert.AreEqual(expected, false);
        }

        [Test()]
        [Author(TestPropertyConstant.AuthorName, TestPropertyConstant.AuthorEmail)]
        public void IsValidPortTest([Values("65535", "0")] string port)
        {
            var expected = IPAddressValidator.IsValidPort(port);

            Assert.AreEqual(expected, true);
        }

        [Test()]
        [Author(TestPropertyConstant.AuthorName, TestPropertyConstant.AuthorEmail)]
        public void IsValidPortTest1([Values("65538", "-1")] string port)
        {
            var expected = IPAddressValidator.IsValidPort(port);

            Assert.AreEqual(expected, false);
        }
    }
}