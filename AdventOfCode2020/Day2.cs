using System;
using System.Collections.Generic;
using System.Text;
using Utility;

namespace AdventOfCode2020
{
    public class Day2 : AdventProblem
    {
        public override string SolvePuzzle1()
        {
            var lines = raw.Trim().Split("\n");
            var validCount = 0;

            foreach (var line in lines)
                if (IsValidPuzzle1(line))
                    validCount++;

            return validCount.ToString();
        }

        private bool IsValidPuzzle1(string policyAndPassword)
        {
            var parts = policyAndPassword.Split(' ');

            var numbers = parts[0].Split('-');
            var minimum = int.Parse(numbers[0]);
            var maximum = int.Parse(numbers[1]);

            var letter = parts[1][0];

            var occurenceCount = 0;
            for (int i = 0; i < parts[2].Length; i++)
                if (parts[2][i] == letter)
                    occurenceCount++;

            return occurenceCount >= minimum
                && occurenceCount <= maximum;
        }

        public override string SolvePuzzle2()
        {
            var lines = raw.Trim().Split("\n");
            var validCount = 0;

            foreach (var line in lines)
                if (IsValidPuzzle2(line))
                    validCount++;

            return validCount.ToString();
        }

        private bool IsValidPuzzle2(string policyAndPassword)
        {
            var parts = policyAndPassword.Split(' ');

            var numbers = parts[0].Split('-');
            var pos1 = int.Parse(numbers[0]) - 1;
            var pos2 = int.Parse(numbers[1]) - 1;

            var letter = parts[1][0];

            return parts[2][pos1] == letter
                ^ parts[2][pos2] == letter;
        }
    }
}
