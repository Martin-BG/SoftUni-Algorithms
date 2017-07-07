using System;

namespace _04.Generating_0_1_Vectors
{
    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var vector = new int[n];

            Gen01(vector, 0);
        }

        private static void Gen01(int[] vector, int index)
        {
            if (index >= vector.Length)
            {
                Console.WriteLine(string.Concat(vector));
            }
            else
            {
                vector[index] = 0;
                Gen01(vector, index + 1);

                vector[index] = 1;
                Gen01(vector, index + 1);
            }
        }
    }
}
