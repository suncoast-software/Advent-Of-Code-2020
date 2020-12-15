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
            //var part2 =  Day15.Day15.SolvePart2();
            //Console.WriteLine($"Part 2: {part2}");

            BenchmarkRunner.Run<Benchmark.Day15>();

            Console.ReadLine();
        }
    }
}
