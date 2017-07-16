using System;
using System.Collections.Generic;

namespace _03.Combinations_with_Repetition
{
    internal class Program
    {
        private static void Main()
        {
            GetSequences(
                int.Parse(Console.ReadLine()), 
                new int[int.Parse(Console.ReadLine())], 
                0, 
                1);
        }

        private static void GetSequences(int elements, IList<int> array, int index, int nextNum)
        {
            if (index == array.Count)
            {
                Console.WriteLine(string.Join(" ", array));
                return;
            }

            for (var i = nextNum; i <= elements; i++)
            {
                array[index] = i;
                GetSequences(elements, array, index + 1, i);
            }
        }
    }
}
