using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_Of_Code.Day18
{
   public class Day18
    {
        static string[] input = File.ReadAllLines(@"Day18\day18input.txt");
        public static long Solve()
        {
            long sum = 0;
            foreach (var line in input)
            {
                string work = line;
                while (work.Split('(').Length > 1)
                {
                    int closest = work.Length - 1;
                    for (int i = work.Length - 1; i >= 0; i--)
                    {
                        if (work[i] == ')') closest = i;
                        if (work[i] == '(')
                        {
                            string group = work.Substring(i + 1, closest - i - 1);
                            string total = WorkOutMath(group, false);
                            work = work.Replace($"({group})", total.ToString());
                            break;
                        }
                    }
                }
                sum += long.Parse(WorkOutMath(work, false));
            }
            return sum;
        }

        static string WorkOutMath(string math, bool part1)
        {
            while (math.Split(' ').Length > 1)
            {
                var mathbits = math.Split(' ');
                int n = 1;
                if (!part1)
                {
                    for (int i = 0; i < mathbits.Length; i++)
                    {
                        if (mathbits[i] == "+")
                        {
                            n = i;
                            break;
                        }
                    }
                }
                long n1 = long.Parse(mathbits[n - 1]);
                long n2 = long.Parse(mathbits[n + 1]);
                long total = mathbits[n] switch
                {
                    "+" => n1 + n2,
                    "*" => n1 * n2,
                    _ => throw new NotImplementedException()
                };
                string result = total.ToString();
                if (mathbits.Length > 3)
                {
                    for (int i = 0; i < mathbits.Length; i++)
                    {
                        if (i == n - 1)
                        {
                            if (i == 0) result = total.ToString();
                            else result += ' ' + total.ToString();
                            i += 2;
                        }
                        else
                        {
                            if (i == 0) result = mathbits[i];
                            else result += ' ' + mathbits[i];
                        }
                    }
                }
                math = result;
            }
            return math;
        }
    }
}
