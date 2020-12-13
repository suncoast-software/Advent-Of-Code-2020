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

        public static int SolvePart2()
        {
            for (int i = 0; i < InstructionList().Length; i++)
            {
                var newInstructions = InstructionList();
                if (newInstructions[i].Instruction == "acc")
                {
                    continue;
                }
                if (newInstructions[i].Instruction == "nop")
                {
                    newInstructions[i].Instruction = "jmp";
                }
                else if (newInstructions[i].Instruction == "jmp")
                {
                    newInstructions[i].Instruction = "nop";
                }
                var (loop, acc) = ExecuteInstructions(newInstructions);
                if (loop == true)
                {
                    return acc;
                }
            }
            return 0;
        }

        private static (bool loop, int count) ExecuteInstructions(Instructions[] instructions)
        {
            int count = 0;
            int pos = 0;
            while (true)
            {
                if (pos >= instructions.Length)
                {
                    return (true, count);
                }
                if (instructions[pos].Executed)
                {
                    return (false, count);
                }
                instructions[pos].Executed = true;
                if (instructions[pos].Instruction == "jmp")
                {
                    pos += instructions[pos].Number;
                }
                else
                {
                    if (instructions[pos].Instruction == "acc")
                    {
                        count += instructions[pos].Number;
                    }
                    pos++;
                }
            }
        }

        private static Instructions[] InstructionList()
        {
            IEnumerable<Instructions> result = from instruction in System.IO.File.ReadAllLines(@"Day8/day8input.txt")
                                               select new Instructions()
                                               {
                                                   Instruction = instruction.Substring(0, 3),
                                                   Number = int.Parse(instruction.Substring(3).Trim()),
                                                   Executed = false
                                               };
            return result.ToArray();
        }

        public class Instructions
        {
            public string Instruction { get; set; }
            public int Number { get; set; }
            public bool Executed { get; set; }
        }
        public class Result
        {
            public bool infinate { get; set; }
            public int acc { get; set; }
        }
    }
}
