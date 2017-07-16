using System;
using System.Collections.Generic;

namespace _07.Paths_in_Labyrinth
{
    class Program
    {
        static void Main()
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            var lab = ReadLab(rows, cols);
            var path = new List<char>();

            FindPaths(lab, 0, 0, 'S', path);
        }

        private static void FindPaths(
            char[,] lab, int row, int col, char direction, List<char> path)
        {
            if (!IsValid(lab, row, col))
            {
                return;
            }

            path.Add(direction);

            if (IsExit(lab, row, col))
            {
                PrintPath(path);
            }
            else if (!IsVisited(lab, row, col))
            {
                Mark(lab, row, col);
                FindPaths(lab, row, col + 1, 'R', path);
                FindPaths(lab, row + 1, col, 'D', path);
                FindPaths(lab, row, col - 1, 'L', path);
                FindPaths(lab, row - 1, col, 'U', path);
                UnMark(lab, row, col);
            }

            path.RemoveAt(path.Count - 1);
        }

        private static void UnMark(char[,] lab, int row, int col)
        {
            lab[row, col] = '-';
        }

        private static void Mark(char[,] lab, int row, int col)
        {
            lab[row, col] = 'v';
        }

        private static bool IsVisited(char[,] lab, int row, int col)
        {
            return lab[row, col] == 'v';
        }

        private static void PrintPath(List<char> path)
        {
            Console.WriteLine(string.Concat(path).Substring(1));
        }

        private static bool IsExit(char[,] lab, int row, int col)
        {
            return lab[row, col] == 'e';
        }

        private static bool IsValid(char[,] lab, int row, int col)
        {
            return row >= 0 && row < lab.GetLength(0)
                   && col >= 0 && col < lab.GetLength(1)
                   && lab[row, col] != '*';
        }

        private static char[,] ReadLab(int rows, int cols)
        {
            var lab = new char[rows, cols];

            for (var row = 0; row < rows; row++)
            {
                var line = Console.ReadLine()
                    .ToCharArray();

                for (var col = 0; col < cols; col++)
                {
                    lab[row, col] = line[col];
                }
            }

            return lab;
        }
    }
}
