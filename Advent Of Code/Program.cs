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
            //var part1Result = Day8.Day8.SolvePart1();
            var part2Result = Day8.Day8.SolvePart2();
             //Console.WriteLine($"Part 1: {part1Result}");
            Console.WriteLine($"Part 2: {part2Result}");

            // BenchmarkRunner.Run<Benchmark.Class1>();
            Console.ReadLine();
        }
    }
}
