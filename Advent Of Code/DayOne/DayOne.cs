using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Advent_Of_Code
{
   public class DayOne
    {
        public static int PartOne()
        {
            var nums = new List<string>();
            var timer = new Stopwatch();
            timer.Start();
            using (var reader = new StreamReader("input.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    nums.Add(line);
                }
            }

            for (int i = 0; i < nums.Count - 2; i++)
            {
                for (int j = 1; j < nums.Count - 1; j++)
                {
                    var firstNum = int.Parse(nums[i]);
                    var secondNum = int.Parse(nums[j]);

                    if (firstNum + secondNum == 2020)
                    {
                        var numFinal = firstNum * secondNum;
                        
                        timer.Stop();
                        Console.WriteLine($"finished in {timer.Elapsed} m/s");
                        return numFinal;
                    }
                }
            }

            return 0;
        }
        public static int PartTwo()
        {
            var nums = new List<string>();
            var timer = new Stopwatch();
            timer.Start();
            using (var reader = new StreamReader("input.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    nums.Add(line);
                }
            }

            for (int i = 0; i < nums.Count - 2; i++)
            {
                for (int j = 1; j < nums.Count - 1; j++)
                {
                    for (int a = 2; a < nums.Count; a++)
                    {
                        var firstNum = int.Parse(nums[i]);
                        var secondNum = int.Parse(nums[j]);
                        var thirdNum = int.Parse(nums[a]);

                        if (firstNum + secondNum + thirdNum == 2020)
                        {
                            var numFinal = firstNum * secondNum * thirdNum;
                           
                            timer.Stop();
                            Console.WriteLine($"finished in {timer.Elapsed} m/s");
                            return numFinal;
                        }
                    }
                }
            }

            return 0;
        }
    }
}
