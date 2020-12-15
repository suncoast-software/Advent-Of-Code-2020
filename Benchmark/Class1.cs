using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;

namespace Benchmark
{
    [MinColumn]
    [MaxColumn]
    public class Class1
    {
        string input = File.ReadAllText("day14input.txt");
        Dictionary<ulong, int> memory = new Dictionary<ulong, int>();
        List<int> floatingIndex;

        [Benchmark]
        public ulong SolvePart2()
        {
            string[] inputSplit = input.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);

            Regex pattern = new Regex(@"mem\[(?<id>\d+)\] = (?<value>\d+)", RegexOptions.Compiled);

            string mask = "";
            foreach (string line in inputSplit)
            {
                if (line.StartsWith("mask = "))
                {
                    mask = line[7..];
                }
                else
                {
                    GroupCollection groups = pattern.Match(line).Groups;
                    string id = Convert.ToString(int.Parse(groups["id"].Value), 2);
                    int val = int.Parse(groups["value"].Value);

                    while (id.Length < mask.Length)
                    {
                        id = '0' + id;
                    }
                    StringBuilder sb = new StringBuilder(id);

                    for (int i = 0; i < mask.Length; i++)
                    {
                        if (mask[i] != '0')
                        {
                            sb[i] = mask[i];
                        }
                    }
                    id = sb.ToString();

                    floatingIndex = new List<int>();
                    for (int i = 0; i < id.Length; i++)
                    {
                        if (id[i] == 'X')
                        {
                            floatingIndex.Add(i);
                        }
                    }
                    GetPossibleCombinations(id, val);

                    memory[Convert.ToUInt64(id.Replace('X', '0'), fromBase: 2)] = val;
                }
            }

            ulong sum = 0;
            foreach (int v in memory.Values)
            {
                sum += (ulong)v;
            }
            return sum;
        }

        void GetPossibleCombinations(string id, int val, int n = 0)
        {
            for (int i = n; i < floatingIndex.Count; i++)
            {
                StringBuilder sb = new StringBuilder(id);
                sb = sb.Replace('X', '0');
                sb[floatingIndex[i]] = '1';

                memory[Convert.ToUInt64(sb.ToString(), fromBase: 2)] = val;

                GetPossibleCombinations(sb.ToString(), val, i + 1);
            }
        }

        //[Benchmark]
        //public int SolvePart2()
        //{
        //    string[] input = File.ReadAllLines(@"input.txt");

        //    int GetBags(string bag)
        //    {
        //        var count = 0;
        //        foreach (var line in input.Where(r => r.StartsWith(bag)))
        //        {
        //            var ruleBags = Regex.Matches(line, @"(?<number>\d+) (?<color>.*?) bag");

        //            foreach (Match match in ruleBags)
        //            {
        //                count += int.Parse(match.Groups["number"].Value) * (1 + GetBags(match.Groups["color"].Value));
        //            }
        //        }

        //        return count;
        //    }
        //    return GetBags("shiny gold");
        //}
    }
}
