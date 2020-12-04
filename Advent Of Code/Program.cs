using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Advent_Of_Code
{
    class Program
    {
        static void Main(string[] args)
        {
            var valid = DayThree.DayThree.CountTrees(3,1);
            var partTwo = DayThree.DayThree.FindPartTwo();
            Console.WriteLine($"Part One is : [{valid}]");
            Console.WriteLine($"Part Two is : [{partTwo}]");
            Console.ReadLine();
        }
    }
}
