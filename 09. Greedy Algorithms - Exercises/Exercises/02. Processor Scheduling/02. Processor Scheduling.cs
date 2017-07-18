using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Processor_Scheduling
{
    internal class Program
    {
        private static void Main()
        {
            var tasksCount = int.Parse(
                Console.ReadLine()
                .Split(':')[1]
                .Trim());

            var tasks = new List<List<int>>();
            
            for (var i = 1; i <= tasksCount; i++)
            {// 0 - Value, 1 - Deadline, 2 - Index
                tasks.Add(Console.ReadLine()
                    .Split('-')
                    .Select(x => int.Parse(x.Trim()))
                    .ToList());

                tasks[i - 1].Add(i);
            }

            tasks = tasks
                .OrderByDescending(task => task[0])
                .ThenBy(task => task[1])
                .ToList();

            var maxDeadLine = tasks.Max(x => x[1]);

            var slots = new bool[maxDeadLine];

            var result = new List<List<int>>();

            foreach (var task in tasks)
            {
                for (var i = task[1] - 1; i >= 0; i--)
                {
                    if (slots[i])
                    {
                        continue;
                    }

                    slots[i] = true;
                    result.Add(task);
                    break;
                }
            }

            var schedule = result
                .OrderBy(x => x[1])
                .ThenByDescending(x => x[0])
                .Select(x => x[2])
                .ToList();

            Console.WriteLine($"Optimal schedule: {string.Join(" -> ", schedule)}");
            Console.WriteLine($"Total value: {result.Sum(x => x[0])}");
        }
    }
}
