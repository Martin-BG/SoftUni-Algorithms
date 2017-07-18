using System;
using System.Linq;

namespace _05.Egyptian_Fractions
{
    internal class Program
    {
        private static void Main()
        {
            var tokens = Console.ReadLine()
                .Split('/')
                .Select(int.Parse)
                .ToArray();

            var nom = tokens[0];
            var denom = tokens[1];

            if (nom >= denom)
            {
                Console.WriteLine("Error (fraction is equal to or greater than 1)");
                return;
            }

            Console.Write($"{nom}/{denom} = ");

            while (true)
            {
                if (denom % nom == 0)
                {
                    Console.WriteLine($"1/{denom / nom}");
                    break;
                }

                var divider = (nom + denom) / nom;

                Console.Write($"1/{divider} + ");

                nom = (nom * divider) - denom;
                denom = denom * divider;
            }
        }
    }
}
