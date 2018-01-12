using CommonUtility.Security;
using CommonUtilityTests.Constant;
using NUnit.Framework;
using System.Security.Cryptography;
using System.Text;

namespace CommonUtility.Extension.Tests
{
    [TestFixture()]
    [Category(nameof(CryptographicException))]
    public class CryptographyExtensionTests
    {
        [Test()]
        [Author(TestPropertyConstant.AuthorName, TestPropertyConstant.AuthorEmail)]
        public void SetHashAlgorithmTest()
        {
            var expectedValue = MD5.Create();
            var actualValue = new Cryptography().SetHashAlgorithm(CryptoServiceProviderType.MD5);

            Assert.AreEqual(expectedValue.ToString(), actualValue.HashAlgorithm.ToString());
        }

        [Test()]
        [Author(TestPropertyConstant.AuthorName, TestPropertyConstant.AuthorEmail)]
        public void SetEncodingTest()
        {
            var expectedValue = Encoding.UTF8;
            var actualValue = new Cryptography().SetEncoding(Encoding.UTF8);

            Assert.AreEqual(expectedValue, actualValue.Encoding);
        }
    }
}