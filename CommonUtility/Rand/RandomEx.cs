using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonUtility.Rand
{
    public class RandomEx
    {
        private static readonly object _sync = new object();
        private static Random random = new Random();

        public static string NextString(int count, bool upperLetter = true, bool lowerLetter = true, bool number = true)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException(nameof(count), "count must greater than zero");

            if (!upperLetter && !lowerLetter && !number)
                throw new InvalidOperationException("upperLetter/lowerLetter/number at least one is true");

            var index = 0;
            var scopes = new List<Scope>();
            if (upperLetter)
            {
                var scope = new Scope { FirstIndex = index, FirstChar = 'A', Count = 26 };
                scopes.Add(scope);
                index += scope.Count;
            }
            if (lowerLetter)
            {
                var scope = new Scope { FirstIndex = index, FirstChar = 'a', Count = 26 };
                scopes.Add(scope);
                index += scope.Count;
            }
            if (number)
            {
                var scope = new Scope { FirstIndex = index, FirstChar = '0', Count = 10 };
                scopes.Add(scope);
                index += scope.Count;
            }

            var builder = new StringBuilder(count * 2);
            for (int i = 0; i < count; i++)
            {
                var value = 0;
                lock (_sync)
                    value = random.Next(index);

                foreach (var scope in scopes)
                {
                    if (scope.FirstIndex <= value && (scope.FirstIndex + scope.Count > value))
                    {
                        var @char = (char)(value - scope.FirstIndex + scope.FirstChar);

                        builder.Append(@char);
                        break;
                    }
                }
            }

            return builder.ToString();
        }

        public static int Next(int minValue = 0, int maxValue = int.MaxValue)
        {
            var value = 0;
            lock (_sync)
                value = random.Next(minValue, maxValue);

            return value;
        }

        public static void NextBytes(byte[] buffer)
        {
            lock (_sync)
                random.NextBytes(buffer);
        }

        public static double NextDouble()
        {
            var value = 0d;
            lock (_sync)
                value = random.NextDouble();

            return value;
        }

        struct Scope
        {
            public int FirstIndex;
            public char FirstChar;
            public int Count;
        }
    }
}
