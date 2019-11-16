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

        // calculate the number of drop off points for a n * m grid, given the fact that a single drop off
        // can cover at most 4 cells (if arranged in a 2*2 grid), otherwise at most 2 cells if arranged horizontally or vertically
        static int gameWithCells(int n, int m)
        {
            var area = n * m;
            int rows = n, columns = m;

            // base case 1. handle single columns/rows first
            if (rows == 1 || columns == 1) { // assume we have a single row or column means at most we can only cover 2 cells
                return (int)Math.Ceiling(n * m / 2M);
            }

            // base case 2. handle known amount of cells
            if (area <= 2 || area == 4) return 1;

            int extraRow = 0,extraColumn = 0;
            if (rows % 2 != 0) { // we need to calculate drop offs for an additional row
                extraRow = (int) Math.Ceiling(columns / 2M);
            }

            if (columns % 2 != 0) { // we need to calculate drop offs for an additional column
                extraColumn = (int)Math.Ceiling(rows / 2M);
            }

            // handle case where both an extra row and extra column are provided as there will
            // be some overlap in bottom right corner of grid
            if (extraRow > 0 && extraColumn > 0) extraColumn -= 1; 

            rows = (extraRow > 0) ? rows - 1 : rows;
            columns = (extraColumn > 0) ? columns - 1 : columns;
            
            // update the area to reflect the portion that is even divisible by 4
            area = rows * columns;
            var dropOffPoints = (area / 4) + extraRow + extraColumn;
            return dropOffPoints;
        }
    }
}