using System;
using System.Collections.Generic;
using System.Text;
using Utility;

namespace AdventOfCode2020
{
    public class Day08 : AdventProblem
    {
        public override string SolvePuzzle1()
        {
            var instructions = raw.Split('\n');

            var executedInstructions = new bool[instructions.Length];

            var accumulator = 0;
            var position = 0;

            while (true)
            {
                if (executedInstructions[position])
                    break;
                executedInstructions[position] = true;

                if(instructions[position].StartsWith("nop")) {
                    position++;
                }
                else if (instructions[position].StartsWith("acc"))
                {
                    var parts = instructions[position].Split(" ");
                    var num = int.Parse(parts[1]);
                    accumulator += num;
                    position++;
                }
                else if (instructions[position].StartsWith("jmp"))
                {
                    var parts = instructions[position].Split(" ");
                    var num = int.Parse(parts[1]);
                    position += num;
                }
                else
                {
                    throw new InvalidOperationException("Invalid instruction");
                }
            }

            return accumulator.ToString();
        }

        public override string SolvePuzzle2()
        {
            var instructions = raw.Trim().Split('\n');

            for(int i = 0; i < instructions.Length; i++)
            {
                if(instructions[i].StartsWith("nop"))
                {
                    instructions[i] = instructions[i].Replace("nop", "jmp");
                    var result = IsValidProgram(instructions);
                    if (!result.Item2)
                        instructions[i] = instructions[i].Replace("jmp", "nop");
                    else
                        return result.Item1.ToString();
                }
                else if (instructions[i].StartsWith("jmp"))
                {
                    instructions[i] = instructions[i].Replace("jmp", "nop");
                    var result = IsValidProgram(instructions);
                    if (!result.Item2)
                        instructions[i] = instructions[i].Replace("nop", "jmp");
                    else
                        return result.Item1.ToString();
                }
            }

            throw new InvalidOperationException("Code should never get here!");
        }

        private Tuple<int, bool> IsValidProgram(string[] instructions)
        {
            var executedInstructions = new bool[instructions.Length];
            var accumulator = 0;
            var position = 0;

            while (position < instructions.Length)
            {
                if (executedInstructions[position])
                    return new Tuple<int, bool>(accumulator, false);

                executedInstructions[position] = true;

                if (instructions[position].StartsWith("nop"))
                    position++;
                else if (instructions[position].StartsWith("acc"))
                {
                    var parts = instructions[position].Split(" ");
                    var num = int.Parse(parts[1]);
                    accumulator += num;
                    position++;
                }
                else if (instructions[position].StartsWith("jmp"))
                {
                    var parts = instructions[position].Split(" ");
                    var num = int.Parse(parts[1]);
                    position += num;
                }
                else
                    throw new InvalidOperationException("Invalid instruction");
            }

            return new Tuple<int, bool>(accumulator, true);
        }
    }
}
