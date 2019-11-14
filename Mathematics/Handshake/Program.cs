using System;
using System.Collections.Generic;

namespace demo
{
    // Constraints
    // 1 <= T <= 1000 
    // 0 <  N <  10e6
    // https://www.hackerrank.com/challenges/handshake/problem


    class Program
    {
        /// <summary>
        /// Main entry point into program
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Solution1();    // generate lookup table in memory and use that to get values
            Solution2();    // dynamically build lookup table that contains at most 2 element (previous/current)
        
            // TODO - benchmark the two solutions to see which is faster
        }
        static List<KVP> tbl = new List<KVP>(1_000_000);
        private struct KVP
        {
            public int x;
            public int y;
        }
        static void BuildLookupTable()
        {
            for (int i = 0; i < 1_000_000; i++)
            {
                // base case 2.
                if (i == 0) tbl.Add(new KVP { x = 1, y = 0 });
                // base case 3.
                else if (i == 1) tbl.Add(new KVP { x = 2, y = 1 });
                // everything else is calculated
                else tbl.Add(new KVP { x = i + 1, y = tbl[i - 1].x + tbl[i - 1].y });
            }
        }
        static void Solution1()
        {
            BuildLookupTable();

            // The first line contains the number of test cases T, T lines follow.
            var t = int.Parse(Console.ReadLine());
            for (int i = 0; i < t; i++)
            {
                // Each line then contains an integer N, the total number of Board of Directors of Acme. 
                var n = int.Parse(Console.ReadLine());
                Console.WriteLine(tbl[n - 1].y);  // print the precalculated value from table
            }
            tbl = null; // let this get cleaned up when we're done with it
        }
        

        static void Solution2()
        {
            //The first line contains the number of test cases T, T lines follow.
            var t = int.Parse(Console.ReadLine());
            for (int i = 0; i < t; i++)
            {
                // Each line then contains an integer N, the total number of Board of Directors of Acme. 
                var n = int.Parse(Console.ReadLine());
                Console.WriteLine(handshake(n));  // print the precalculated value from table
            }
        }
        // Initialize table with starting values
        static KVP[] tbl1 = new KVP[2]
        {
            new KVP{x=1,y=0},
            new KVP{x=2,y=1}
        };
        static KVP[] tmp = new KVP[2];       
        static int handshake(int n)
        {
            if (n == 1) return tbl1[0].y;
            else if (n == 2) return tbl1[1].y;
            else
            {
                // calculate
                var toggle = false; // to reduce memory we only keep at most 2 records in memory, current and previous
                for (int i = 2; i < n; i++)
                {
                    // base case 1.  - use values from 'tbl' to start the tmp array
                    if (i == 2)
                    {
                        tmp[0] = (new KVP { x = 3, y = tbl1[i - 1].x + tbl1[i - 1].y });
                        if (i == n - 1) return tmp[0].y;
                        toggle = true;
                        continue;
                    }

                    if (toggle)
                    {
                        tmp[1] = (new KVP { x = i + 1, y = tmp[0].x + tmp[0].y });
                        if (i == n - 1) return tmp[1].y;
                        toggle = !toggle;
                    }
                    else
                    {
                        tmp[0] = (new KVP { x = i + 1, y = tmp[1].x + tmp[1].y });
                        if (i == n - 1) return tmp[0].y;
                        toggle = !toggle;
                    }
                }
            }
            return 0;
        }
    }
}
