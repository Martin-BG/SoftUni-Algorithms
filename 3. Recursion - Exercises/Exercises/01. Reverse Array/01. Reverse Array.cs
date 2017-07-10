using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Reverse_Array
{
    internal class Program
    {
        private static void Main()
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            ReverseArray(numbers, 0, numbers.Length-1);

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void ReverseArray(IList<int> numbers, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            var temp = numbers[start];
            numbers[start] = numbers[end];
            numbers[end] = temp;

            ReverseArray(numbers, ++start, --end);
        }
    }
}
