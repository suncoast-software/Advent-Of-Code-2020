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
            
            var partOneCount = Day4.Day4.SolvePart1();
            var partTwoCount = Day4.Day4.SolvePart2();
            Console.WriteLine($"Valid Passports Part 1: {partOneCount}");
            Console.WriteLine($"Valid Passports Part 2: {partTwoCount}");
            Console.ReadLine();
        }
    }
}
