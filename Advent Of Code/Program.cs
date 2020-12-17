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
            //var testInput = "this iS a sample Input string To count The index values";
            //string letters = "abcdefghijklmnopqrstuvwxyz";
            //int score = 0, index = 0;
            //foreach (var letr in testInput.ToLower())
            //{
            //    index = letters.IndexOf(letr);
            //    score += index;
            //}
            var part1 =  Day16.Day16.SolvePart1();
            Console.WriteLine($"Part 1: {part1}");

            //BenchmarkRunner.Run<Benchmark.Day15>();

            Console.ReadLine();
        }
    }
}
