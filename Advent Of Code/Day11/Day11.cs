using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advent_Of_Code.Helper;

namespace Advent_Of_Code.Day11
{
   public class Day11
    {
        private static string inputFull = WebClientHelper.GetInput(10);
        public static string[] inputSplit = inputFull.Split(new[] { '\r', 'n' }, StringSplitOptions.RemoveEmptyEntries);
        private static string[] testInput = File.ReadAllLines(@"Day11/testinput.txt");
        public static int SolvePart1()
        {
            for (int row = 0; row < inputSplit.Count(); row++)
            {
                for (int col = 0; col < testInput.Count(); col++)
                {

                }
            }
            return 0;
        }

        public static int SolvePart2()
        {
            return 0;
        }
    }
}
