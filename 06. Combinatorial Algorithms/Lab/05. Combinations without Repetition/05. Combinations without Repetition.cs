using System;

namespace _05.Combinations_without_Repetition
{
    internal class Program
    {
        private static void Main()
        {
            var elements = Console.ReadLine().Split();

            var k = int.Parse(Console.ReadLine());

            Gen(new string[k], elements, 0, 0);
        }

        private static void Gen(string[] vector, string[] elements, int index, int start)
        {
            if (index >= vector.Length)
            {
                Console.WriteLine(string.Join(" ", vector));
            }
            else
            {
                for (var i = start; i < elements.Length; i++)
                {
                    vector[index] = elements[i];
                    Gen(vector, elements, index + 1, i + 1);
                }
            }
        }
    }
}
