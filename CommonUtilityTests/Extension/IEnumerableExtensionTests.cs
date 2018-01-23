using CommonUtilityTests.Constant;
using NUnit.Framework;
using System;
using System.Linq;

namespace CommonUtility.Extension.Tests
{
    [TestFixture()]
    [Category(nameof(IEnumerableExtension))]
    public class IEnumerableExtensionTests
    {
        [Test()]
        [Author(TestPropertyConstant.AuthorName, TestPropertyConstant.AuthorEmail)]
        public void SplitTest(
            [Values(0, 24, 46, 57, 68, 95)]
            int total,
            [Values(-5, 0, 2, 5, 99)]
            int groupCount)
        {
            var list = new int[total];
            var random = new Random();
            Array.ForEach(list, l => l = random.Next());

            var groupedList = list.Split(groupCount);

            var expectedGroupCount = Math.Max(groupCount, 1);
            Assert.AreEqual(expectedGroupCount, groupedList.Count());

            Assert.AreEqual(list.Count(), groupedList.Sum(l => l.Count()));

            // Some IEnumerable.Count() may not equal itemCount, it's OK.
            var hasValueGroupCount = Math.Min(expectedGroupCount, total);
            var itemCount = groupedList.First().Count();
            for (int i = 0; i < hasValueGroupCount - 1; i++)
            {
                Assert.AreEqual(itemCount, groupedList[i].Count());
            }
        }
    }
}