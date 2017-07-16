using System;

namespace _03.Variations_without_Repetitions
{
    internal class Program
    {
        private static void Main()
        {
            var elements = Console.ReadLine().Split();

            var k = int.Parse(Console.ReadLine());

            Gen(elements, new string[k], new bool[elements.Length], k, 0);
        }

        private static void Gen(string[] elements, string[] vector, bool[] used, int k, int index)
        {
            if (index >= k)
            {
                Console.WriteLine(string.Join(" ", vector));
            }
            else
            {
                for (var i = 0; i < elements.Length; i++)
                {
                    if (used[i])
                    {
                        continue;
                    }

                    used[i] = true;
                    vector[index] = elements[i];
                    Gen(elements, vector, used, k, index + 1);
                    used[i] = false;
                }
            }
        }
    }
}
