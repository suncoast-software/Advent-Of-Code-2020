using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_Of_Code.Day9
{
   public class Day9
    {
        public static long SolvePart1()
        {
            var preambleSize = 25;
            var input = System.IO.File.ReadAllLines(@"Day9/day9input.txt").ToList().ConvertAll(long.Parse);
            long target = 0;

            for (int i = preambleSize; i < input.Count; i++)
            {
                target = input[i];
                var numbers = new HashSet<long>();
                var found = false;
                for (int j = i - preambleSize; j < input.Count; j++)
                {
                    if (!numbers.Contains(target - input[j]))
                    {
                        numbers.Add(input[j]);
                    }
                    else if (input[j] * 2 == target)
                    {
                        continue;
                    }
                    else
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    break;
                }
            }
            return target;
        }

        public static long SolvePart2()
        {
            var input = System.IO.File.ReadAllLines(@"Day9/day9input.txt").ToList().ConvertAll(long.Parse);
            var preambleSize = 25;
            long target = 0;

            for (int i = preambleSize; i < input.Count; i++)
            {
                target = input[i];
                var numbers = new HashSet<long>();
                var found = false;
                for (int j = i - preambleSize; j < input.Count; j++)
                {
                    if (!numbers.Contains(target - input[j]))
                    {
                        numbers.Add(input[j]);
                    }
                    else if (input[j] * 2 == target)
                    {
                        continue;
                    }
                    else
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    break;
                }
            }

            for (int x = 0; x < input.Count; x++)
            {
                var found = false;
                long sum = input[x];
                long smallest = input[x];
                long largest = input[x];
                for (int y = x + 1; y < input.Count; y++)
                {
                    if (input[y] < smallest) smallest = input[y];
                    if (input[y] > largest) largest = input[y];
                    sum += input[y];
                    if (sum == target)
                    {
                        target = smallest + largest;
                        found = true;
                        break;
                    }
                    else if (sum > target)
                    {
                        break;
                    }
                }
                if (found)
                {
                    break;
                }
            }
            return target;
        }
    }
}
