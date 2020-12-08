using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_Of_Code._2019.Day1
{
   public class Day1
    {
        private static string[] input = File.ReadAllLines(@"2019\Input\day1input.txt");
        public static ulong SolvePart1()
        {
            double result = 0;
            foreach (var num in input)
            {
                if (double.TryParse(num, out double temp))
                {
                    var t = Math.Floor(temp);
                    var tempNum = (t / 3) - 2;
                    result += Math.Floor(tempNum);
                }
               
            }
            return Convert.ToUInt64(result);
        }

        public static ulong SolvePart2()
        {
            double result = 0;
            foreach (var num in input)
            {
                if (double.TryParse(num, out double temp))
                {
                    var t = Math.Floor(temp);
                    var tempNum = (t / 3) - 2;
                    result += Math.Floor(tempNum);
                }

            }
            return Convert.ToUInt64(result);
        }
    }
}
