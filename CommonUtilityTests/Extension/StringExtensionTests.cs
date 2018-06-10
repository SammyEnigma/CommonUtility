using CommonUtility.Extension;
using CommonUtilityTests.Constant;
using NUnit.Framework;
using System;
using System.Text;

namespace CommonUtility.Extension.Tests
{
    [TestFixture()]
    [Category(nameof(StringExtension))]
    public class StringExtensionTests
    {
        const string testString = "1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ~!@#$%^&*()_+-=\\{}[]: \";'<>?,./";

        [Test()]
        [Author(TestPropertyConstant.AuthorName, TestPropertyConstant.AuthorEmail)]
        public void ToBase64StringTest()
        {
            var expectedValue = "MTIzNDU2Nzg5MGFiY2RlZmdoaWprbG1ub3BxcnN0dXZ3eHl6QUJDREVGR0hJSktMTU5PUFFSU1RVVldYWVp+IUAjJCVeJiooKV8rLT1ce31bXTogIjsnPD4/LC4v";
            var actualValue = testString.ToBase64String(Encoding.UTF8);

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test()]
        [Author(TestPropertyConstant.AuthorName, TestPropertyConstant.AuthorEmail)]
        public void ToBase64UrlStringTest()
        {
            var expectedValue = "MTIzNDU2Nzg5MGFiY2RlZmdoaWprbG1ub3BxcnN0dXZ3eHl6QUJDREVGR0hJSktMTU5PUFFSU1RVVldYWVp-IUAjJCVeJiooKV8rLT1ce31bXTogIjsnPD4_LC4v";
            var actualValue = testString.ToBase64UrlString(Encoding.UTF8);

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test()]
        [Author(TestPropertyConstant.AuthorName, TestPropertyConstant.AuthorEmail)]
        public void UrlEncodeTest()
        {
            // fiddler 1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ%7E!%40%23%24%25%5E%26*()_%2B-%3D%5C%7B%7D%5B%5D%3A+%22%3B'%3C%3E%3F%2C.%2F
            var expectedValue = "1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ%7e!%40%23%24%25%5e%26*()_%2b-%3d%5c%7b%7d%5b%5d%3a+%22%3b%27%3c%3e%3f%2c.%2f";
            var actualValue = testString.UrlEncode(Encoding.UTF8);

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test()]
        [Author(TestPropertyConstant.AuthorName, TestPropertyConstant.AuthorEmail)]
        public void HexEncodeTest()
        {
            var expectedValue = "%31%32%33%34%35%36%37%38%39%30%61%62%63%64%65%66%67%68%69%6a%6b%6c%6d%6e%6f%70%71%72%73%74%75%76%77%78%79%7a%41%42%43%44%45%46%47%48%49%4a%4b%4c%4d%4e%4f%50%51%52%53%54%55%56%57%58%59%5a%7e%21%40%23%24%25%5e%26%2a%28%29%5f%2b%2d%3d%5c%7b%7d%5b%5d%3a%20%22%3b%27%3c%3e%3f%2c%2e%2f";
            var actualValue = '%' + testString.HexEncode(Encoding.UTF8, false).Replace('-', '%').ToLower();

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test()]
        [Author(TestPropertyConstant.AuthorName, TestPropertyConstant.AuthorEmail)]
        public void HexEncodeTest1()
        {
            var expectedValue = "%31%32%33%34%35%36%37%38%39%30%61%62%63%64%65%66%67%68%69%6a%6b%6c%6d%6e%6f%70%71%72%73%74%75%76%77%78%79%7a%41%42%43%44%45%46%47%48%49%4a%4b%4c%4d%4e%4f%50%51%52%53%54%55%56%57%58%59%5a%7e%21%40%23%24%25%5e%26%2a%28%29%5f%2b%2d%3d%5c%7b%7d%5b%5d%3a%20%22%3b%27%3c%3e%3f%2c%2e%2f".Replace("%", "");
            var actualValue = testString.HexEncode(Encoding.UTF8).ToLower();

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test()]
        [Author(TestPropertyConstant.AuthorName, TestPropertyConstant.AuthorEmail)]
        public void ToByteArrayTest()
        {
            var expectedValue = "0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x30, 0x61, 0x62, 0x63, 0x64, 0x65, 0x66, 0x67, 0x68, 0x69, 0x6A, 0x6B, 0x6C, 0x6D, 0x6E, 0x6F, 0x70, 0x71, 0x72, 0x73, 0x74, 0x75, 0x76, 0x77, 0x78, 0x79, 0x7A, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x49, 0x4A, 0x4B, 0x4C, 0x4D, 0x4E, 0x4F, 0x50, 0x51, 0x52, 0x53, 0x54, 0x55, 0x56, 0x57, 0x58, 0x59, 0x5A, 0x7E, 0x21, 0x40, 0x23, 0x24, 0x25, 0x5E, 0x26, 0x2A, 0x28, 0x29, 0x5F, 0x2B, 0x2D, 0x3D, 0x5C, 0x7B, 0x7D, 0x5B, 0x5D, 0x3A, 0x20, 0x22, 0x3B, 0x27, 0x3C, 0x3E, 0x3F, 0x2C, 0x2E, 0x2F";
            var actualValue = testString.ToByteArray(Encoding.UTF8);

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test()]
        [Author(TestPropertyConstant.AuthorName, TestPropertyConstant.AuthorEmail)]
        public void ToByteArrayTest1()
        {
            var expectedValue = "#31, #32, #33, #34, #35, #36, #37, #38, #39, #30, #61, #62, #63, #64, #65, #66, #67, #68, #69, #6A, #6B, #6C, #6D, #6E, #6F, #70, #71, #72, #73, #74, #75, #76, #77, #78, #79, #7A, #41, #42, #43, #44, #45, #46, #47, #48, #49, #4A, #4B, #4C, #4D, #4E, #4F, #50, #51, #52, #53, #54, #55, #56, #57, #58, #59, #5A, #7E, #21, #40, #23, #24, #25, #5E, #26, #2A, #28, #29, #5F, #2B, #2D, #3D, #5C, #7B, #7D, #5B, #5D, #3A, #20, #22, #3B, #27, #3C, #3E, #3F, #2C, #2E, #2F";
            var actualValue = testString.ToByteArray(Encoding.UTF8, " #{0:X2},").TrimStart(' ').TrimEnd(',');

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test()]
        [Author(TestPropertyConstant.AuthorName, TestPropertyConstant.AuthorEmail)]
        public void HtmlEncodeTest()
        {
            var expectedValue = "1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ~!@#$%^&amp;*()_+-=\\{}[]: &quot;;&#39;&lt;&gt;?,./";
            var actualValue = testString.HtmlEncode();

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test()]
        [Author(TestPropertyConstant.AuthorName, TestPropertyConstant.AuthorEmail)]
        public void JavaScriptStringEncodeTest()
        {
            //fiddler "1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ~!@#$%^&*()_+-=\\\\{}[]: \\\";'<>?,./";
            var expectedValue = "1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ~!@#$%^\\u0026*()_+-=\\\\{}[]: \\\";\\u0027\\u003c\\u003e?,./";
            var actualValue = testString.JavaScriptStringEncode();

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test()]
        [Author(TestPropertyConstant.AuthorName, TestPropertyConstant.AuthorEmail)]
        public void ToGuidTest()
        {
            var expectedValue = new Guid("B9DDB0261D14BA63E1E7C4E512E8B9FE");
            var actualValue = testString.ToGuid();

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test()]
        [Author(TestPropertyConstant.AuthorName, TestPropertyConstant.AuthorEmail)]
        public void ToGuidTest1()
        {
            var expectedValue = new Guid("dbfb2a1b-8520-4b3d-774c-13801000f94c");
            var actualValue = testString.ToGuid(Encoding.BigEndianUnicode);

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test()]
        [Author(TestPropertyConstant.AuthorName, TestPropertyConstant.AuthorEmail)]
        public void FromBase64StringTest()
        {
            var expectedValue = testString;
            var actualValue = "MTIzNDU2Nzg5MGFiY2RlZmdoaWprbG1ub3BxcnN0dXZ3eHl6QUJDREVGR0hJSktMTU5PUFFSU1RVVldYWVp+IUAjJCVeJiooKV8rLT1ce31bXTogIjsnPD4/LC4v".FromBase64String().ToString(Encoding.UTF8);

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test()]
        [Author(TestPropertyConstant.AuthorName, TestPropertyConstant.AuthorEmail)]
        public void FromBase64UrlStringTest()
        {
            var expectedValue = testString;
            var actualValue = "MTIzNDU2Nzg5MGFiY2RlZmdoaWprbG1ub3BxcnN0dXZ3eHl6QUJDREVGR0hJSktMTU5PUFFSU1RVVldYWVp-IUAjJCVeJiooKV8rLT1ce31bXTogIjsnPD4_LC4v".FromBase64UrlString().ToString(Encoding.UTF8);

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test()]
        [Author(TestPropertyConstant.AuthorName, TestPropertyConstant.AuthorEmail)]
        public void UrlDecodeTest()
        {
            var expectedValue = testString;
            var actualValue = "1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ%7E!%40%23%24%25%5E%26*()_%2B-%3D%5C%7B%7D%5B%5D%3A+%22%3B'%3C%3E%3F%2C.%2F".UrlDecode(Encoding.UTF8);

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test()]
        [Author(TestPropertyConstant.AuthorName, TestPropertyConstant.AuthorEmail)]
        public void HexDecodeTest()
        {
            var expectedValue = testString;
            var actualValue = "%31%32%33%34%35%36%37%38%39%30%61%62%63%64%65%66%67%68%69%6a%6b%6c%6d%6e%6f%70%71%72%73%74%75%76%77%78%79%7a%41%42%43%44%45%46%47%48%49%4a%4b%4c%4d%4e%4f%50%51%52%53%54%55%56%57%58%59%5a%7e%21%40%23%24%25%5e%26%2a%28%29%5f%2b%2d%3d%5c%7b%7d%5b%5d%3a%20%22%3b%27%3c%3e%3f%2c%2e%2f".Replace("%", "").HexDecode(Encoding.UTF8);

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test()]
        [Author(TestPropertyConstant.AuthorName, TestPropertyConstant.AuthorEmail)]
        public void HtmlDecodeTest()
        {
            var expectedValue = testString;
            var actualValue = "1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ~!@#$%^&amp;*()_+-=\\{}[]: &quot;;&#39;&lt;&gt;?,./".HtmlDecode();

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test()]
        [Author(TestPropertyConstant.AuthorName, TestPropertyConstant.AuthorEmail)]
        public void CreateSecureStringTest()
        {
            var expectedValue = testString;
            var actualValue = testString.CreateSecureString().CreateString();

            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}