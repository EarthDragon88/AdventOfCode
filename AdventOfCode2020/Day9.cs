using System;
using System.Collections.Generic;
using System.Text;
using Utility;

namespace AdventOfCode2020
{
    public class Day9 : AdventProblem
    {
        public override string SolvePuzzle1()
        {
            var lines = raw.Trim().Split('\n');

            var numbers = new long[lines.Length];
            for (int i = 0; i < lines.Length; i++)
                numbers[i] = long.Parse(lines[i]);

            var stepSize = 25;

            for(int i = stepSize; i < numbers.Length; i++)
            {
                var sumNumbers = FindSums(
                    numbers,
                    i - stepSize,
                    i);

                if (!sumNumbers.Contains(numbers[i]))
                    return numbers[i].ToString();
            }

            throw new InvalidOperationException("Code should never get here");
        }

        public HashSet<long> FindSums(long[] arr, int startIndex, int endIndex)
        {
            var result = new HashSet<long>();

            for (int i = startIndex; i < endIndex; i++)
                for (int j = i; j < endIndex; j++)
                    result.Add(arr[i] + arr[j]);

            return result;
        }

        public override string SolvePuzzle2()
        {
            var lines = raw.Trim().Split('\n');

            var numbers = new long[lines.Length];
            for (int i = 0; i < lines.Length; i++)
                numbers[i] = long.Parse(lines[i]);

            long targetNum = 21806024;

            var currSetSize = 2;
            while (true)
            {
                for(int i = currSetSize - 1; i < numbers.Length; i++)
                {
                    long sum = 0;
                    for (int j = 0; j < currSetSize; j++)
                        sum += numbers[i - j];

                    if (sum == targetNum)
                    {
                        var smallest = long.MaxValue;
                        var largest = long.MinValue;
                        for (int j = 0; j < currSetSize; j++)
                        {
                            var currNum = numbers[i - j];
                            if (currNum < smallest)
                                smallest = currNum;
                            if (currNum > largest)
                                largest = currNum;
                        }

                        return (smallest + largest).ToString();
                    }
                        
                }

                currSetSize++;
            }

            throw new NotImplementedException();
        }
    }
}
