using System.Collections.Generic;
using System.Linq;

namespace CommonUtility.Extension
{
    public static class IEnumerableExtension
    {
        /// <summary>
        ///     Divides a list into a given number of groups
        /// </summary>
        /// <typeparam name="T">Any type</typeparam>
        /// <param name="list">Source list</param>
        /// <param name="groupCount">number of groups, The minimum value is 1</param>
        /// <returns></returns>
        public static IList<IEnumerable<T>> Split<T>(this IEnumerable<T> list, int groupCount)
        {
            var group = new List<IEnumerable<T>>();
            var enumerable = list.ToList();
            var total = enumerable.Count();

            if (groupCount < 1) groupCount = 1;
            var groupItemCount = total / groupCount + (total % groupCount == 0 ? 0 : 1);

            for (var i = 0; i < groupCount; i++) group.Add(enumerable.Skip(i * groupItemCount).Take(groupItemCount));

            return group;
        }
    }
}