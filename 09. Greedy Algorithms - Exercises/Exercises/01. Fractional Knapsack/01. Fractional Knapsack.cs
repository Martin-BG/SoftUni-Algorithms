using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Fractional_Knapsack
{
    internal class Program
    {
        private static void Main()
        {
            var capacity = double.Parse(Console.ReadLine().Split(':')[1].Trim());
            var itemsCount = int.Parse(Console.ReadLine().Split(':')[1].Trim());

            var items = new List<List<double>>();
            while (itemsCount-- > 0)
            {
                items.Add(Console.ReadLine()
                    .Split("-> ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToList());
            }

            items = items.OrderByDescending(x => x[0] / x[1]).ToList();

            var totalPrice = 0d;

            foreach (var item in items)
            {
                var weight = Math.Min(item[1], capacity);
                var percentage = weight / item[1];
                var price = item[0] * percentage;
                var percentageStr = weight == item[1] ? "100" : $"{percentage * 100d:F2}";

                Console.WriteLine($"Take {percentageStr}% of item with price {item[0]:F2} and weight {item[1]:F2}");

                totalPrice += price;
                capacity -= weight;

                if (capacity <= 0d)
                {
                    break;
                }
            }

            Console.WriteLine($"Total price: {totalPrice:F2}");
        }
    }
}
