using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Advent_Of_Code.Helper;
using Advent_Of_Code.Models;

namespace Advent_Of_Code.Day5
{
    public class Day5
    {
        public static List<int> Indices;
        public static void SolvePart1()
        {
            var data = WebClientHelper.GetInput(5);

            Indices = data
                        .Replace("F", "0").Replace("L", "0").Replace("R", "1").Replace("B", "1")
                        .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(n => Convert.ToInt32(n, 2)).ToList();

        }

        public static int Part1()
        {
            return Indices.Max();
        }

        public static int Part2()
        {
            var min = Indices.Min();
            var max = Indices.Max();

            var range = Enumerable.Range(min, max - min);
            var missing = range.Except(Indices).First();
            return missing;
        }

     
    }
}
