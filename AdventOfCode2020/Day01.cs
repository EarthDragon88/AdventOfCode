using System;
using System.Collections.Generic;
using System.Text;
using Utility;

namespace AdventOfCode2020
{
    public class Day01 : AdventProblem
    {
        public override string SolvePuzzle1()
        {
            int[] numbers = ConvertToNumbers();

            for (int i = 0; i < numbers.Length; i++)
                for (int j = i; j < numbers.Length; j++)
                    if (numbers[i] + numbers[j] == 2020)
                        return (numbers[i] * numbers[j]).ToString();

            throw new InvalidOperationException("Code should never get here");
        }

        public override string SolvePuzzle2()
        {
            int[] numbers = ConvertToNumbers();

            for (int i = 0; i < numbers.Length; i++)
                for (int j = i; j < numbers.Length; j++)
                    for(int k = j; k < numbers.Length; k++)
                        if (numbers[i] + numbers[j] + numbers[k] == 2020)
                            return (numbers[i] * numbers[j] * numbers[k]).ToString();

            throw new InvalidOperationException("Code should never get here");
        }

        private int[] ConvertToNumbers()
        {
            var lines = raw.Trim().Split('\n');
            var numbers = new int[lines.Length];
            for (int i = 0; i < lines.Length; i++)
                numbers[i] = int.Parse(lines[i]);
            return numbers;
        }
    }
}
