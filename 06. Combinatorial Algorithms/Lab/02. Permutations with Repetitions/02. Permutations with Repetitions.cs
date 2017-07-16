using System;
using System.Collections.Generic;

namespace _02.Permutations_with_Repetitions
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

            var elements = readLine.Split();

            PermuteRep(elements, 0);
        }

        private static void PermuteRep(string[] elements, int start)
        {
            if (start >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));
            }
            else
            {
                PermuteRep(elements, start + 1);

                var used = new HashSet<string> { elements[start] };

                for (var i = start + 1; i < elements.Length; i++)
                {
                    if (used.Contains(elements[i]))
                    {
                        continue;
                    }

                    used.Add(elements[i]);

                    Swap(elements, start, i);

                    PermuteRep(elements, start + 1);

                    Swap(elements, start, i);
                }
            }
        }

        private static void Swap(string[] elements, int i, int j)
        {
            var temp = elements[i];
            elements[i] = elements[j];
            elements[j] = temp;
        }
    }
}
