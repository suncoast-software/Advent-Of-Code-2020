using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Advent_Of_Code.Helper;

namespace Advent_Of_Code.Day6
{
   public class Day6
    {
        private  static string[] _groups2;
        public static int SolvePart1()
        {
            var input = WebClientHelper.GetInput(6).Replace("\r", "").Replace("\n\n", "@").Split("@", StringSplitOptions.RemoveEmptyEntries);
            int count = 0;

            for (int i = 0; i < input.Length; i++)
            {
                var distinct = input[i].Replace("\r", "").Replace("\n", "");
                count += distinct.Distinct().Count();
            }
            return count;
        }

        public static int SolvePart2()
        {
            var input = WebClientHelper.GetInput(6);
            List<HashSet<char>> answers = new List<HashSet<char>>();
            int result = 0;
            var groups = input.Replace("\r", "").Replace("\n\n", "@").Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var group in groups)
            {
                string[] people = group.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                HashSet<char> everyBody = new HashSet<char>(people[0]);
                for (int i = 0; i < people.Length; ++i)
                {
                    everyBody.IntersectWith(new HashSet<char>(people[i]));
                    if (everyBody.Count == 0) break;
                    
                }
                answers.Add(everyBody);
                result += everyBody.Count();
            }
            return result;
        }

    }
}
