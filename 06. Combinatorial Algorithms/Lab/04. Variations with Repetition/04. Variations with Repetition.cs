using System;

namespace _04.Variations_with_Repetition
{
    internal class Program
    {
        private static void Main()
        {
            var elements = Console.ReadLine().Split();

            var k = int.Parse(Console.ReadLine());

            var vector = new int[k];

            while (true)
            {
                Print(vector, elements);

                var index = k - 1;

                while (index >= 0 && vector[index] == elements.Length - 1)
                {
                    index--;
                }

                if (index < 0)
                {
                    break;
                }

                vector[index]++;

                for (var i = index + 1; i < vector.Length; i++)
                {
                    vector[i] = 0;
                }
            }
        }

        private static void Print(int[] vector, string[] elements)
        {
            foreach (var index in vector)
            {
                Console.Write(elements[index] + " ");
            }

            Console.WriteLine();
        }
    }
}
