using CommonUtility.Security;
using CommonUtilityTests.Constant;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Cryptography;
using System.Text;

namespace CommonUtility.Extension.Tests
{
    [TestClass()]
    public class CryptographyExtensionTests
    {
        [TestMethod()]
        [TestProperty(TestPropertyConstant.Author, "3gbywork")]
        public void SetHashAlgorithmTest()
        {
            var expectedValue = MD5.Create();
            var actualValue = new Cryptography().SetHashAlgorithm(CryptoServiceProviderType.MD5);

            Assert.AreEqual(expectedValue.ToString(), actualValue.HashAlgorithm.ToString());
        }

        [TestMethod()]
        [TestProperty(TestPropertyConstant.Author, "3gbywork")]
        public void SetEncodingTest()
        {
            var expectedValue = Encoding.UTF8;
            var actualValue = new Cryptography().SetEncoding(Encoding.UTF8);

            Assert.AreEqual(expectedValue, actualValue.Encoding);
        }
    }
}