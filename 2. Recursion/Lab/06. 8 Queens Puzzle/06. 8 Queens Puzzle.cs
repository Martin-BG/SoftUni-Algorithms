using System;
using System.Collections.Generic;

namespace _06._8_Queens_Puzzle
{
    internal class Program
    {
        private static readonly bool[,] Board = new bool[8, 8];

        private static readonly HashSet<int> AttackedRows = new HashSet<int>();
        private static readonly HashSet<int> AttackedCols = new HashSet<int>();
        private static readonly HashSet<int> AttackedLeftDiagonals = new HashSet<int>();
        private static readonly HashSet<int> AttackedRightDiagonals = new HashSet<int>();

        private static void Main()
        {
            PlaceQueen(0);
        }

        private static void PlaceQueen(int row)
        {
            if (row == 8)
            {
                Prnt();
            }
            else
            {
                for (var col = 0; col < 8; col++)
                {
                    if (!CanPlaceQueen(row, col))
                    {
                        continue;
                    }

                    Mark(row, col);
                    PlaceQueen(row + 1);
                    UnMark(row, col);
                }
            }
        }

        private static void UnMark(int row, int col)
        {
            Board[row, col] = false;
            AttackedRows.Remove(row);
            AttackedCols.Remove(col);
            AttackedLeftDiagonals.Remove(row + col);
            AttackedRightDiagonals.Remove(row - col);
        }

        private static void Mark(int row, int col)
        {
            Board[row, col] = true;
            AttackedRows.Add(row);
            AttackedCols.Add(col);
            AttackedLeftDiagonals.Add(row + col);
            AttackedRightDiagonals.Add(row - col);
        }

        private static bool CanPlaceQueen(int row, int col)
        {
            return !AttackedRows.Contains(row)
                && !AttackedCols.Contains(col)
                && !AttackedLeftDiagonals.Contains(row + col)
                && !AttackedRightDiagonals.Contains(row - col);
        }

        private static void Prnt()
        {
            for (var row = 0; row < 8; row++)
            {
                for (var col = 0; col < 8; col++)
                {
                    Console.Write(Board[row, col] ? "* " : "- ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
