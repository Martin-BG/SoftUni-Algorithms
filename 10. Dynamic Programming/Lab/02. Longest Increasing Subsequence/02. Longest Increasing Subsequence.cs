using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Longest_Increasing_Subsequence
{
    internal class Program
    {
        private static void Main()
        {
            var readLine = Console.ReadLine();

            if (readLine == null)
            {
                return;
            }

            var numbers = readLine
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(string.Join(" ", FindLis(numbers)));
        }

        private static IEnumerable<int> FindLis(IReadOnlyList<int> numbers)
        {
            var elements = numbers.Count;
            var len = new int[elements];
            var prev = new int[elements];

            var maxLen = 0;
            var lastIndex = -1;

            for (var index = 0; index < elements; index++)
            {
                len[index] = 1;
                prev[index] = -1;

                for (var i = 0; i < index; i++)
                {
                    if (numbers[i] < numbers[index] && len[i] >= len[index])
                    {
                        len[index] = len[i] + 1;
                        prev[index] = i;
                    }
                }

                if (len[index] > maxLen)
                {
                    maxLen = len[index];
                    lastIndex = index;
                }
            }

            var lis = new List<int>();

            while (lastIndex != -1)
            {
                lis.Add(numbers[lastIndex]);
                lastIndex = prev[lastIndex];
            }

            lis.Reverse();

            return lis;
        }
    }
}
