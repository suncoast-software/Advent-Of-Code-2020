using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_Of_Code.Day15
{
    public class Day15
    {
        static int[] input = new int[] { 1, 0, 18, 10, 19, 6 };
        public static int SolvePart1()
        {
            var spokenNums = new int[300000000];
            int i = 1;
            foreach (var num in input)
            {
                spokenNums[num] = i++;
            }

            int cur = 0;
            while(i < 2020)
            {
                int prev = spokenNums[cur];
                int value = prev == 0 ? 0 : i - prev;
                spokenNums[cur] = i++;
                cur = value;
            }
            return cur;
        }

        public static int SolvePart2()
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
