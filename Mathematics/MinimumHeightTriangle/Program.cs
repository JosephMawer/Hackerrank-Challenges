using System;

namespace MinimumHeightTriangle
{
    // https://www.hackerrank.com/challenges/lowest-triangle/problem

    class Program
    {
        static int lowestTriangle(int tbase, int area)
            => (int)Math.Ceiling((area * 2) / (decimal)tbase);

        static void Main(string[] args)
        {
            string[] tokens_base = Console.ReadLine().Split(' ');
            var tbase = Convert.ToInt32(tokens_base[0]);
            var area = Convert.ToInt32(tokens_base[1]);
            var height = lowestTriangle(tbase, area);
            Console.WriteLine(height);
        }
    }
}
