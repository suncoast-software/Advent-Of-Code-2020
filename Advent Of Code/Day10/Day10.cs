using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advent_Of_Code.Helper;

namespace Advent_Of_Code.Day10
{
   public class Day10
    {
        public static int SolvePart1()
        {
            var input = File.ReadAllLines(@"Day10/day10input.txt");
            var numbers = ConvertArrayToInt(input);
            numbers.Sort();

            int dif1 = 1;
            int dif3 = 1;
            for (int i = 1; i < numbers.Count; i++)
            {
                int diff = numbers[i] - numbers[i - 1];
               
                if (diff == 1)
                {
                    dif1++;
                }
                else if (diff == 3)
                    dif3++;
                else
                    continue;
            }
            Console.WriteLine($"{dif1} : {dif3}");
            return dif1 * dif3;
        }

        public static long SolvePart2()
        {
            var input = File.ReadAllLines(@"Day10/day10input.txt");
            var numbers = ConvertArrayToInt(input);
            numbers.Sort();

            long ways0 = 0;
            long ways1 = 0;
            long ways2 = 1;

            int prev0 = int.MinValue;
            int prev1 = int.MinValue;
            int prev2 = 0;

            foreach (var num in numbers)
            {
                long ways = ways2;
                if (num - prev1 <= 3)
                {
                    ways += ways1;
                    if (num - prev0 <= 3)
                    {
                        ways += ways0;
                    }
                }

                prev0 = prev1;
                prev1 = prev2;
                prev2 = num;

                ways0 = ways1;
                ways1 = ways2;
                ways2 = ways;
            }
            return ways2;
        }

        private static List<int> ConvertArrayToInt(string[] array)
        {
            List<int> nums = new List<int>();
            foreach (var num in array)
            {
                nums.Add(int.Parse(num));
            }

            return nums;
        }
    }
}
