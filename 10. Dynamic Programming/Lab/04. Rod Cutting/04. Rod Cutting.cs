using System;
using System.Linq;

namespace _04.Rod_Cutting
{
    internal class Program
    {
        private static int[] _prices;
        private static int[] _memo;
        private static int[] _index;

        private static void Main()
        {
            _prices = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var rodLength = int.Parse(Console.ReadLine());

            _memo = new int[_prices.Length];
            _index = new int[_prices.Length];

            Console.WriteLine(CutRod(rodLength));
            PrintSolution(rodLength);
        }

        private static void PrintSolution(int rodLength)
        {
            while (rodLength != 0)
            {
                Console.Write(_index[rodLength] + " ");
                rodLength -= _index[rodLength];
            }
            Console.WriteLine();
        }

        private static int CutRod(int rodLength)
        {
            if (_memo[rodLength] != 0)
            {
                return _memo[rodLength];
            }

            if (rodLength == 0)
            {
                return 0;
            }

            var max = 0;
            var wholePart = rodLength;

            for (var i = 1; i <= rodLength; i++)
            {
                var currentMax = Math.Max(max, _prices[i] + CutRod(rodLength - i));

                if (currentMax <= max)
                {
                    continue;
                }

                wholePart = i;
                max = currentMax;
            }

            _index[rodLength] = wholePart;
            _memo[rodLength] = max;

            return max;
        }
    }
}
