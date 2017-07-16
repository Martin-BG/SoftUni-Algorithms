using System;

namespace _01.Permutations_without_Repetitions
{
    internal class Program
    {
        private static void Main()
        {
            var elements = Console.ReadLine().Split();
            GenRep(0, elements);
        }

        private static void GenRep(int index, string[] elements)
        {
            if (index >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));
            }
            else
            {
                GenRep(index + 1, elements);

                for (var i = index + 1; i < elements.Length; i++)
                {
                    Swap(index, i, elements);
                    GenRep(index + 1, elements);
                    Swap(i, index, elements);
                }
            }
        }

        private static void Swap(int i, int j, string[] elements)
        {
            var temp = elements[i];
            elements[i] = elements[j];
            elements[j] = temp;
        }
    }
}
