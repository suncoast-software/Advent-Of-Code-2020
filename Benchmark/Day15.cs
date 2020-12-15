using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace Benchmark
{
    public class Day15
    {
        int[] input = new int[] { 1, 0, 18, 10, 19, 6 };

        [Benchmark]
        public int SolvePart2()
        {
            var spokenNums = new int[300000000];
            int i = 1;
            foreach (var num in input)
            {
                spokenNums[num] = i++;
            }

            int cur = 0;
            while (i < 30000000)
            {
                int prev = spokenNums[cur];
                int value = prev == 0 ? 0 : i - prev;
                spokenNums[cur] = i++;
                cur = value;
            }
            return cur;
        }
    }
}
