using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Towers_of_Hanoi
{
    internal class Program
    {
        public static int Steps;
        public static Stack<int> Source;
        public static Stack<int> Destination = new Stack<int>();
        public static Stack<int> Spare = new Stack<int>();

        private static void Main()
        {
            var elements = int.Parse(Console.ReadLine());
            Source = new Stack<int>(Enumerable.Range(1, elements).Reverse());

            PrintRods();
            Move(elements, Source, Destination, Spare);
        }

        private static void Move(int bottomDisk,
            Stack<int> source,
            Stack<int> destination,
            Stack<int> spare)
        {
            if (bottomDisk <= 0)
            {
                return;
            }

            Move(bottomDisk - 1, source, spare, destination);

            destination.Push(source.Pop());

            Steps++;
            Console.WriteLine($"Step #{Steps}: Moved disk");
            PrintRods();

            Move(bottomDisk - 1, spare, destination, source);
        }

        private static void PrintRods()
        {
            Console.WriteLine($"Source: {string.Join(", ", Source.Reverse())}");
            Console.WriteLine($"Destination: {string.Join(", ", Destination.Reverse())}");
            Console.WriteLine($"Spare: {string.Join(", ", Spare.Reverse())}");
            Console.WriteLine();
        }
    }
}
