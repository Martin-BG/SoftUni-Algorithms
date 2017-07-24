using System;

namespace _01.Fibonacci
{
    internal class Program
    {
        private static ulong[] _memo;

        private static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            _memo = new ulong[n + 1];

            Console.WriteLine($"{Fibonacci(n)}");
        }

        private static ulong Fibonacci(int n)
        {
            if (_memo[n] > 0)
            {
                return _memo[n];
            }

            if (n <= 2)
            {
                _memo[n] = 1;
            }
            else
            {
                _memo[n] = Fibonacci(n - 1) + Fibonacci(n - 2);
            }

            return _memo[n];
        }
    }
}
