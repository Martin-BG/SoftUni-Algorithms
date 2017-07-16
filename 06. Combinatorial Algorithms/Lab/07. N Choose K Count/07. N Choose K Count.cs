using System;

namespace _07.N_Choose_K_Count
{
    internal class Program
    {
        private static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var k = int.Parse(Console.ReadLine());

            Console.WriteLine(Binom(n, k));
        }

        private static ulong Binom(int n, int k)
        {
            if (k > n)
            {
                return 0UL;
            }

            if (k == 0 || k == n)
            {
                return 1UL;
            }

            return Binom(n - 1, k - 1) + Binom(n - 1, k);
        }
    }
}
