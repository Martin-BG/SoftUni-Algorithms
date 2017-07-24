using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Move_Down_Right
{
    internal class Program
    {
        private static void Main()
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            var valuesMatrix = ReadMatrix(rows, cols);

            var pathMatrix = new long[rows, cols];

            for (var row = 0; row < rows; row++)
            {
                for (var col = 0; col < cols; col++)
                {
                    var maxPrevCell = long.MinValue;

                    if (col > 0 && pathMatrix[row, col - 1] > maxPrevCell)
                    {
                        maxPrevCell = pathMatrix[row, col - 1];
                    }

                    if (row > 0 && pathMatrix[row - 1, col] > maxPrevCell)
                    {
                        maxPrevCell = pathMatrix[row - 1, col];
                    }

                    pathMatrix[row, col] = valuesMatrix[row, col];

                    if (maxPrevCell != long.MinValue)
                    {
                        pathMatrix[row, col] += maxPrevCell;
                    }
                }
            }

            var currRow = rows - 1;
            var currCol = cols - 1;

            var path = new List<string>();

            while (!(currRow == 0 && currCol == 0))
            {
                path.Add($"[{currRow}, {currCol}]");

                if (currRow > 0 && currCol > 0)
                {
                    if (pathMatrix[currRow - 1, currCol] > pathMatrix[currRow, currCol - 1])
                    {
                        currRow--;
                    }
                    else
                    {
                        currCol--;
                    }
                }
                else if (currRow == 0)
                {
                    currCol--;
                }
                else
                {
                    currRow--;
                }
            }

            path.Add($"[0, 0]");

            path.Reverse();

            Console.WriteLine(string.Join(" ", path));
        }

        private static long[,] ReadMatrix(int rows, int cols)
        {
            var matrix = new long[rows, cols];

            for (var row = 0; row < rows; row++)
            {
                var currentRow = Console.ReadLine()
                    .Split()
                    .Select(long.Parse)
                    .ToArray();

                for (var col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            return matrix;
        }
    }
}
