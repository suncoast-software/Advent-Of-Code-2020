using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advent_Of_Code.Day14
{
    public class Day14
    {
        static string input = File.ReadAllText(@"Day14/day14input.txt");
        static readonly Dictionary<ulong, int> memory = new Dictionary<ulong, int>();
        static List<int> floatingIndex;

        public static ulong SolvePart1()
        {
            string[] inputSplit = input.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);

            Regex pattern = new Regex(@"mem\[(?<id>\d+)\] = (?<value>\d+)", RegexOptions.Compiled);
            Dictionary<int, ulong> memory = new Dictionary<int, ulong>();

            string mask = "";
            foreach (string line in inputSplit)
            {
                if (line.StartsWith("mask = "))
                {
                    mask = line.Substring(7);
                }
                else
                {
                    GroupCollection groups = pattern.Match(line).Groups;
                    string idVal = groups["id"].Value;
                    
                    int id = int.Parse(groups["id"].Value);
               
                    string val = Convert.ToString(int.Parse(groups["value"].Value), 2);

                    while (val.Length < mask.Length)
                    {
                        val = '0' + val;
                    }
                    StringBuilder sb = new StringBuilder(val);

                    for (int i = 0; i < mask.Length; i++)
                    {
                        if (mask[i] != 'X')
                        {
                            sb[i] = mask[i];
                        }
                    }
                    memory[id] = Convert.ToUInt64(sb.ToString(), fromBase: 2);
                }
            }

            ulong sum = 0;
            foreach (ulong v in memory.Values)
            {
                sum += v;
            }
            return sum;
        }

        public static ulong SolvePart2()
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

        static void GetPossibleCombinations(string id, int val, int n = 0)
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
    }
}
