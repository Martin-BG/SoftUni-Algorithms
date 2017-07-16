using System;

namespace _02.Recursive_Factorial
{
    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            Console.WriteLine(Factorial(n));
        }

        private static long Factorial(int n)
        {
            if (n < 2)
            {
                return 1;
            }

            return n * Factorial(--n);
        }
    }
}
