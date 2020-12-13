using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_Of_Code.Day13
{
    public class Day13
    {
        public static string input = File.ReadAllText(@"Day13/day13input.txt").Trim();
        public static string testInput = File.ReadAllText(@"Day13/testinput.txt").Trim();
        public static int SolvePart1()
        {
            var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            int time = int.Parse(lines[0]);
            var buses = lines[1].Split(',');

            List<int> departTimes = new();
            foreach (var bus in buses)
            {
                if (bus != "x")
                    departTimes.Add(int.Parse(bus));
            }

            int minWait = int.MaxValue;
            int busId = 0;

            foreach (var bus in departTimes)
            {
                int clock = 0;
                while(true)
                {
                    clock += bus;
                    if (clock >= time)
                        break;
                }

                if (clock < minWait)
                {
                    minWait = clock;
                    busId = bus;
                }
            }
            int delta = minWait - time;
            Console.WriteLine($"Part 1: {delta * busId}");
            return 0;
        }

        public static int SolvePart2()
        {
            var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            var buses = lines[1].Split(',');

            int?[] busNums = new int?[buses.Length];
            for (int i = 0; i < buses.Length; i++)
            {
                if (buses[i] != "x")
                    busNums[i] = int.Parse(buses[i]);
            }

            long nProd = 0; // N
            for (int i = 0; i < busNums.Length; i++)
            {
                if (busNums[i] == null) continue;
                if (nProd == 0) nProd = (int)busNums[i];
                else nProd *= (int)busNums[i];
            } // ^ Total product of all modulus (the bus numbers).

            long[] nProds = new long[busNums.Length]; // Ni
            for (int i = 0; i < busNums.Length; i++)
            {
                if (busNums[i] == null) continue;
                nProds[i] = nProd / (int)busNums[i];
            } // ^ Total product for each without itself.

            long[] remainders = new long[busNums.Length]; // bi
            for (int i = 0; i < busNums.Length; i++)
            {
                if (busNums[i] == null) continue;
                remainders[i] = (int)busNums[i] - i;
            } // ^ The remainder timestamp % bus will have.

            int[] xVals = new int[busNums.Length]; // xi
            for (int i = 0; i < busNums.Length; i++)
            {
                if (busNums[i] == null) continue;
                int j = 1;
                while (true)
                {
                    if ((nProds[i] * j) % busNums[i] == 1)
                    {
                        break;
                    }
                    j++;
                }
                xVals[i] = j;
            } // The number of Ni needed % bus number for remainder 1.

            long total = 0;
            for (int i = 0; i < busNums.Length; i++)
            {
                if (busNums[i] == null) continue;
                total += remainders[i] * nProds[i] * xVals[i];
            }
            Console.WriteLine($"Part 2: {total % nProd}");
            // Sum of the product of each of those mod our N from earlier.

            return 0;
        }
    }
}
