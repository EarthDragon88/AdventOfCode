using System;
using System.Collections.Generic;
using System.Text;
using Utility;

namespace AdventOfCode2020
{
    public class Day10 : AdventProblem
    {
        public override string SolvePuzzle1()
        {
            var lines = raw.Trim().Split('\n');

            var numbers = new int[lines.Length];
            for (int i = 0; i < lines.Length; i++)
                numbers[i] = int.Parse(lines[i]);

            Array.Sort(numbers);

            var diffs = new List<int>();

            diffs.Add(numbers[0]);

            for(int i = 1; i < numbers.Length; i++)
            {
                diffs.Add(numbers[i] - numbers[i - 1]);
            }

            diffs.Add(3);

            var size1Diffs = 0;
            var size3Diffs = 0;

            foreach(var diff in diffs)
            {
                if (diff == 1) size1Diffs++;
                if (diff == 3) size3Diffs++;
            }

            return (size1Diffs * size3Diffs).ToString();
        }

        public override string SolvePuzzle2()
        {
            var lines = raw.Trim().Split('\n');

            var numbers = new int[lines.Length + 1];
            for (int i = 0; i < lines.Length; i++)
                numbers[i] = int.Parse(lines[i]);

            Array.Sort(numbers);

            var cacheDictionary = new Dictionary<int, long>();
            var count = CountArrangements(0, numbers, cacheDictionary);
            return count.ToString();
        }

        private long CountArrangements(int index, int[] arr, Dictionary<int, long> cache)
        {
            if (index >= arr.Length - 1)
                return 1l;

            var maxVal = arr[index] + 3;

            var sum = 0l;

            for(int i = index + 1; i < arr.Length && arr[i] <= maxVal; i++)
            {
                if(cache.ContainsKey(i))
                    sum += cache[i];
                else
                {
                    var cnt = CountArrangements(i, arr, cache);
                    cache[i] = cnt;
                    sum += cnt;
                }
            }

            return sum;
        }
    }
}
