using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Advent_Of_Code
{
    class Program
    {
        static void Main(string[] args)
        {
            var valid = DayTwo.DayTwo.ParsePasswordInput(); 
            Console.WriteLine($"result is : [{valid}]");
            Console.ReadLine();
        }
    }
}
