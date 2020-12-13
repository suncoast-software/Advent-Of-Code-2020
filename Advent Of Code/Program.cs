using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using BenchmarkDotNet.Running;
using Advent_Of_Code._2019.Day1;

namespace Advent_Of_Code
{
    class Program
    {
        static void Main(string[] args)
        {
            Day13.Day13.SolvePart2();
            //var part2Result = Day13.Day13.SolvePart2();
             //Console.WriteLine($"Part 1: {part1Result}");
            //Console.WriteLine($"Part 2: {part2Result}");

            // BenchmarkRunner.Run<Benchmark.Class1>();
            Console.ReadLine();
        }
    }
}
