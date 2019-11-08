using System;
using System.Linq;

namespace Hackerrank_Challenges
{
    class Program
    {
        //https://www.hackerrank.com/challenges/s10-basic-statistics/problem
        // 10 Days Of Statistics
        // Day 0: Mean, Median, Mode
        static void Main(string[] args)
        {
            // First line is the number of elements in array
            var N = Console.ReadLine();
            // Second line is the elements of the array
            var input = Console.ReadLine()?.Split(' ');
            // Convert string into integer array
            var data = Array.ConvertAll(input, int.Parse);

            // calculate the mean
            var mean = (decimal)data.Average();

            // calculate the median
            // first, order the list 
            var ol = data.OrderBy(x => x).ToArray();
            // calculate median;  2 middle elements of the array div by 2
            var median = ((ol[(ol.Length / 2) - 1] + ol[ol.Length / 2]) / 2M);

            // calculate mode: i.e. the number that occurs most frequently in data set
            var mode = data.GroupBy(i => i) // group the data set, i.e. if a number occurs more than put it into its own group
                    .OrderByDescending(x => x.Count()) // order by the number of occurrences (largest first)
                    .ThenBy(x => x.Key)      // then order by the the values
                    .First();                // and take the first element, as it should have the most occurrences and be the smallest number in that grouping
 

            var nl = Environment.NewLine;
            Console.WriteLine($"{mean:F1}{nl}{median:F1}{nl}{mode.Key}");
        }
    }
}
