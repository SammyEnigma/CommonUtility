using CommonUtilityTests.Constant;
using NUnit.Framework;
using System.Text;

namespace CommonUtility.Extension.Tests
{
    [TestFixture()]
    [Category(nameof(BytesExtension))]
    public class BytesExtensionTests
    {
        private const string TestString = "1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ~!@#$%^&*()_+-=\\{}[]: \";'<>?,./";

        [Test()]
        [Author(TestPropertyConstant.AuthorName, TestPropertyConstant.AuthorEmail)]
        public void ToStringTest()
        {
            var expectedValue = "%31%32%33%34%35%36%37%38%39%30%61%62%63%64%65%66%67%68%69%6a%6b%6c%6d%6e%6f%70%71%72%73%74%75%76%77%78%79%7a%41%42%43%44%45%46%47%48%49%4a%4b%4c%4d%4e%4f%50%51%52%53%54%55%56%57%58%59%5a%7e%21%40%23%24%25%5e%26%2a%28%29%5f%2b%2d%3d%5c%7b%7d%5b%5d%3a%20%22%3b%27%3c%3e%3f%2c%2e%2f".Replace("%", "");
            var actualValue = Encoding.UTF8.GetBytes(TestString).ToString(true).ToLower();

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test()]
        [Author(TestPropertyConstant.AuthorName, TestPropertyConstant.AuthorEmail)]
        public void ToStringTest1()
        {
            var expectedValue = TestString;
            var actualValue = Encoding.UTF8.GetBytes(TestString).ToString(Encoding.UTF8);

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test()]
        [Author(TestPropertyConstant.AuthorName, TestPropertyConstant.AuthorEmail)]
        public void ToBase64StringTest()
        {
            var expectedValue = "MTIzNDU2Nzg5MGFiY2RlZmdoaWprbG1ub3BxcnN0dXZ3eHl6QUJDREVGR0hJSktMTU5PUFFSU1RVVldYWVp+IUAjJCVeJiooKV8rLT1ce31bXTogIjsnPD4/LC4v";
            var actualValue = Encoding.UTF8.GetBytes(TestString).ToBase64String();

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test()]
        [Author(TestPropertyConstant.AuthorName, TestPropertyConstant.AuthorEmail)]
        public void ToBase64UrlStringTest()
        {
            var expectedValue = "MTIzNDU2Nzg5MGFiY2RlZmdoaWprbG1ub3BxcnN0dXZ3eHl6QUJDREVGR0hJSktMTU5PUFFSU1RVVldYWVp-IUAjJCVeJiooKV8rLT1ce31bXTogIjsnPD4_LC4v";
            var actualValue = Encoding.UTF8.GetBytes(TestString).ToBase64UrlString();

            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}