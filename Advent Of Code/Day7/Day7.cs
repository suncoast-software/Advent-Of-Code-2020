using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Advent_Of_Code.Helper;

namespace Advent_Of_Code.Day7
{
    public class Day7
    {
        public static int SolvePart1()
        {
            string[] testInput = File.ReadAllLines(@"Day7\testinput.txt");
            var input = File.ReadAllLines(@"Day7\Day7input.txt");

            var count = 0;
            HashSet<string> bags = new HashSet<string> { " shiny gold" };
            GetBags(" shiny gold");

            void GetBags(string bag)
            {
                foreach (var line in input.Where(r => r.Contains(bag)))
                {
                    var currentBag = $" {line.Split(" bags ")[0]}";
                    if (!bags.Contains(currentBag))
                    {
                        count++;
                        bags.Add(currentBag);
                        GetBags(currentBag);
                    }
                }
            }
            return count;
        }

        public static int SolvePart2()
        {
            string[] input = File.ReadAllLines(@"Day7\day7input.txt");

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
