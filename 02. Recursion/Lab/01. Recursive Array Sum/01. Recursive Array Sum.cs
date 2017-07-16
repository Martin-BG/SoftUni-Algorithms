using System;
using System.Linq;

namespace _01.Recursive_Array_Sum
{
    class Program
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(Sum(numbers, 0));
        }

        private static int Sum(int[] numbers, int index)
        {
            if (index == numbers.Length - 1)
            {
                return numbers[index];
            }

            return numbers[index] + Sum(numbers, ++index);
        }
    }
}
