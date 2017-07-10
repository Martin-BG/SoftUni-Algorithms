using System;
using System.Collections.Generic;

namespace _06.Connected_Areas_in_Matrix
{
    internal class Program
    {
        private static void Main()
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            var matrix = ReadMatrix(rows, cols);

            var areas = new List<Area>();

            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    FindConnectedArea(matrix, i, j, areas);
                }
            }

            areas.Sort();

            Console.WriteLine($"Total areas found: {areas.Count}");

            var positionCount = 1;

            foreach (var area in areas)
            {
                Console.WriteLine($"Area #{positionCount++} {area}");
            }
        }

        private static void FindConnectedArea(char[,] matrix, int row, int col, List<Area> areas)
        {
            if (matrix[row, col] == '*' || matrix[row, col] == 'v')
            {
                return;
            }

            var area = new Area(row, col);

            FillArea(matrix, row, col, area);

            areas.Add(area);
        }

        private static void FillArea(char[,] matrix, int row, int col, Area area)
        {
            if (!IsInBoundaries(matrix, row, col) ||
                matrix[row, col] == 'v' ||
                matrix[row, col] == '*')
            {
                return;
            }

            matrix[row, col] = 'v';

            area.Size++;

            FillArea(matrix, row + 1, col, area);
            FillArea(matrix, row, col + 1, area);
            FillArea(matrix, row - 1, col, area);
            FillArea(matrix, row, col - 1, area);
        }

        private static bool IsInBoundaries(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                   col >= 0 && col < matrix.GetLength(1);
        }

        private static char[,] ReadMatrix(int rows, int cols)
        {
            var matrix = new char[rows, cols];

            for (var row = 0; row < rows; row++)
            {
                var currentRow = Console.ReadLine()
                    .ToCharArray();

                for (var col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            return matrix;
        }

        private class Area : IComparable<Area>
        {
            private readonly int _row;
            private readonly int _col;

            public int Size;

            public Area(int row, int col)
            {
                _row = row;
                _col = col;

                Size = 0;
            }

            public int CompareTo(Area other)
            {
                var cmp = other.Size.CompareTo(Size);

                if (cmp == 0)
                {
                    cmp = _row.CompareTo(other._row);
                }

                if (cmp == 0)
                {
                    cmp = _col.CompareTo(other._col);
                }

                return cmp;
            }

            public override string ToString()
            {
                return $"at ({_row}, {_col}), size: {Size}";
            }
        }
    }
}
