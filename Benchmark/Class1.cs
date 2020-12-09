using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;

namespace Benchmark
{
    [MinColumn]
    [MaxColumn]
    public class Class1
    {
        [Benchmark]
        public int SolvePart2()
        {
            string[] input = File.ReadAllLines(@"input.txt");

            int GetBags(string bag)
            {
                var count = 0;
                foreach (var line in input.Where(r => r.StartsWith(bag)))
                {
                    var ruleBags = Regex.Matches(line, @"(?<number>\d+) (?<color>.*?) bag");

                    foreach (Match match in ruleBags)
                    {
                        count += int.Parse(match.Groups["number"].Value) * (1 + GetBags(match.Groups["color"].Value));
                    }
                }

                return count;
            }
            return GetBags("shiny gold");
        }
    }
}
