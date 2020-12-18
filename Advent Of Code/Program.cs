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
            var part1 =  Day18.Day18.Solve();
            Console.WriteLine($"Part 1: {part1}");

            //BenchmarkRunner.Run<Benchmark.Day16>();

            Console.ReadLine();
        }
    }
}
