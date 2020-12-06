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
            
            Day5.Day5.SolvePart1();
            var missing = Day5.Day5.Part2();
            Console.WriteLine($"Missing Seat ID: {missing}");
           
            Console.ReadLine();
        }
    }
}
