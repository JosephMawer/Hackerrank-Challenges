using System;

namespace ArmyGame
{
    class Program
    {
        // https://www.hackerrank.com/challenges/game-with-cells/problem
        static void Main(string[] args)
        {
            // Given 'n' and 'm', what's the minimum number of packages
            // that Luke must drop to supply all of his bases?

            // example input, a 70 * 123 grid
            Console.WriteLine(gameWithCells(70, 123));
        }


        static int gameWithCells(int n, int m)
        {
            var p = n * m;
            int row = n, column = m;

            // base case 1. handle single columns/rows first
            if (row == 1 || column == 1)
            {
                // assume we have a single row or column means at most
                // we can only cover 2 cells
                return (int)Math.Ceiling(n * m / 2M);
            }

            // base case 2. handle known amount of cells
            if (p <= 2 || p == 4) return 1;

            int extraRow = 0,extraColumn = 0;
            if (row % 2 != 0) { // we need to calculate drop offs for an additional row
                extraRow = (int) Math.Ceiling(column / 2M);
            }

            if (column % 2 != 0) { // we need to calculate drop offs for an additional column
                extraColumn = (int)Math.Ceiling(row / 2M);
            }

            // handle case where both an extra row and extra column are provided as there will
            // be some overlap in bottom right corner of grid
            if (extraRow > 0 && extraColumn > 0) extraColumn -= 1; 

            var nt = (extraRow > 0) ? row - 1 : row;
            var ct = (extraColumn > 0) ? column - 1 : column;
            var area = nt * ct;
            var total = (area / 4) + extraRow + extraColumn;
            return total;
        }
    }
}