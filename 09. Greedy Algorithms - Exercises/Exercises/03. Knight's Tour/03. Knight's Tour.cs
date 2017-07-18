using System;
using System.Collections.Generic;

namespace _03.Knight_s_Tour
{
    internal class Program
    {
        private static readonly List<int[]> Moves = new List<int[]>
        {
            new [] { +1, +2 },
            new [] { -1, +2 },
            new [] { +1, -2 },
            new [] { -1, -2 },
            new [] { +2, +1 },
            new [] { +2, -1 },
            new [] { -2, +1 },
            new [] { -2, -1 },
        };

        private static void Main()
        {
            var matrixSize = int.Parse(Console.ReadLine());

            var matrix = new int[matrixSize, matrixSize];

            GenMoves(matrix, 0, 0, 1, matrixSize);

            PrintMatrix(matrix, matrixSize);
        }

        private static void PrintMatrix(int[,] matrix, int matrixSize)
        {
            for (var i = 0; i < matrixSize; i++)
            {
                for (var j = 0; j < matrixSize; j++)
                {
                    Console.Write(matrix[i, j].ToString().PadLeft(3, ' ') + " ");
                }
                Console.WriteLine();
            }
        }

        private static void GenMoves(int[,] matrix, int row, int col, int step, int matrixSize)
        {
            while (true)
            {
                matrix[row, col] = step++;

                var bestMove = new[] {0, 0};
                var bestMoveOptions = int.MaxValue;

                foreach (var move in Moves)
                {
                    var availableMoves = EvaluateMoves(matrix, row + move[0], col + move[1], matrixSize);

                    if (availableMoves >= bestMoveOptions || availableMoves == -1)
                    {
                        continue;
                    }

                    bestMoveOptions = availableMoves;
                    bestMove = move;
                }

                if (bestMoveOptions != int.MaxValue)
                {
                    row = row + bestMove[0];
                    col = col + bestMove[1];
                    continue;
                }

                break;
            }
        }

        private static int EvaluateMoves(int[,] matrix, int row, int col, int matrixSize)
        {
            if (!IsValid(matrix, row, col, matrixSize))
            {
                return -1;
            }

            var moves = 0;

            foreach (var move in Moves)
            {
                var nextRow = row + move[0];
                var nextCol = col + move[1];

                if (IsValid(matrix, nextRow, nextCol, matrixSize))
                {
                    moves++;
                }
            }

            return moves;
        }

        private static bool IsValid(int[,] matrix, int row, int col, int matrixSize)
        {
            return row >= 0
                && row < matrixSize
                && col >= 0
                && col < matrixSize
                && matrix[row, col] == 0;
        }
    }
}
