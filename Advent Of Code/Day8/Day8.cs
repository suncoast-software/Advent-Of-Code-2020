using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_Of_Code.Day8
{
   public class Day8
    {
        private static string[] testInput = File.ReadAllLines(@"Day8\testinput.txt");
        private static string[] input = File.ReadAllLines(@"Day8\day8input.txt");
        private static int globalAcc;
        private static int pc;
        public static int SolvePart1()
        {
            globalAcc = 0;
            pc = 0;
            List<int> visitedPcs = new List<int>();

            bool run = true;
            while (run)
            {
                visitedPcs.Add(pc);
                string op = input[pc];
                string[] opandArgs = op.Split(" ");

                switch (opandArgs[0])
                {
                    case "nop":
                        pc++;
                        break;
                    case "acc":
                        globalAcc += int.Parse(opandArgs[1]);
                        pc++;
                        break;
                    case "jmp":
                        pc += int.Parse(opandArgs[1]);
                        break;
                }

                if (visitedPcs.Contains(pc))
                    run = false;
            
                
            }
            Console.WriteLine($"part 1 : {globalAcc}");
            return globalAcc;
        }

        public static Result SolvePart2()
        {
            Result toReturn = new Result();
            globalAcc = 0;
            pc = 0;
            List<int> visitedPcs = new List<int>();

            bool run = true;
            while (run)
            {
                visitedPcs.Add(pc);
                string op = input[pc];
                string[] opandArgs = op.Split(" ");

                switch (opandArgs[0])
                {
                    case "nop":
                        pc++;
                        break;
                    case "acc":
                        globalAcc += int.Parse(opandArgs[1]);
                        pc++;
                        break;
                    case "jmp":
                        pc += int.Parse(opandArgs[1]);
                        break;
                }

                if (visitedPcs.Contains(pc))
                {
                    run = false;
                    toReturn.infinate = true;
                    toReturn.acc = globalAcc;
                }
                else if (pc >= input.Length)
                {
                    run = false;
                    toReturn.infinate = false;
                    toReturn.acc = globalAcc;
                }
                    


            }
            Console.WriteLine($"part 1 : {globalAcc}");
            return toReturn;
        }
        public class Result
        {
            public bool infinate { get; set; }
            public int acc { get; set; }
        }
    }
}
