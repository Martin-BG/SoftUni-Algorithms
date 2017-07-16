using System;
using System.Collections.Generic;

namespace _02.Nested_Loops
{
    internal class Program
    {
        private static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var array = new int[n];

            CreateSequences(array, 0);
        }

        private static void CreateSequences(IList<int> array, int start)
        {
            if (start == array.Count)
            {
                Console.WriteLine(string.Join(" ", array));
                return;
            }

            for (var i = 1; i <= array.Count; i++)
            {
                array[start] = i;
                CreateSequences(array, start + 1);
            }
        }
    }
}
