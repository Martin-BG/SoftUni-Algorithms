using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Best_Lectures_Schedule
{
    internal class Program
    {
        private static void Main()
        {
            var lecturesCount = int.Parse(
                Console.ReadLine()
                .Split(':')[1]
                .Trim());

            var lectures = new List<Lecture>();

            while (lecturesCount-- > 0)
            {
                lectures.Add(Lecture.Parse(Console.ReadLine()));
            }

            lectures = lectures.OrderBy(x => x.EndTime).ToList();
            var resut = new List<Lecture>();

            while (lectures.Count > 0)
            {
                var current = lectures[0];

                resut.Add(current);

                var toRemove = lectures
                    .Where(lecture => lecture.StartTime < current.EndTime)
                    .ToList();

                foreach (var lecture in toRemove)
                {
                    lectures.Remove(lecture);
                }
            }

            Console.WriteLine($"Lectures ({resut.Count}):");

            foreach (var lecture in resut)
            {
                Console.WriteLine(lecture);
            }
        }

        private class Lecture
        {
            private string Name { get; set; }
            public int StartTime { get; private set; }
            public int EndTime { get; private set; }

            public override string ToString()
            {
                return $"{StartTime}-{EndTime} -> {Name}";
            }

            public static Lecture Parse(string readLine)
            {
                return new Lecture
                {
                    Name = readLine.Split(':')[0].Trim(),
                    StartTime = int.Parse(readLine.Split(':')[1].Split('-')[0].Trim()),
                    EndTime = int.Parse(readLine.Split(':')[1].Split('-')[1].Trim())
                };
            }
        }
    }
}
