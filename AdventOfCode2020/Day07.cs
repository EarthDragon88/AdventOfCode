using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace AdventOfCode2020
{
    public class Day07 : AdventProblem
    {

        public override object SolvePuzzle1()
        {
            var lines = raw.Trim().Split('\n');
            var bagDictionary = new Dictionary<string, string>();
            
            foreach(var line in lines)
            {
                var parts = line.Split(" bags contain ");
                var key = parts[0];
                var value = parts[1];
                bagDictionary.Add(key, value);
            }

            var bagTracker = new HashSet<string>();
            FindParentsColorCount("shiny gold", bagDictionary, bagTracker);

            return bagTracker.Count();
        }

        public void FindParentsColorCount(
            string key,
            Dictionary<string, string> dictionary,
            HashSet<string> tracker)
        {
            foreach(var kv in dictionary)
                if (kv.Value.Contains(key))
                {
                    tracker.Add(kv.Key);
                    FindParentsColorCount(kv.Key, dictionary, tracker);
                }
        }

        public override object SolvePuzzle2()
        {
            var lines = raw.Trim().Split('\n');

            var bagDictionary = new Dictionary<string, string>();

            foreach (var line in lines)
            {
                var parts = line.Split(" bags contain ");
                var key = parts[0];
                var value = parts[1];
                bagDictionary.Add(key, value);
            }

            var count = CountBags("shiny gold", bagDictionary);

            return count;
        }

        private int CountBags(
            string key,
            Dictionary<string, string> dictionary)
        {
            if (dictionary[key] == "no other bags.")
                return 0;

            var bagCount = 0;
            var containedBags = dictionary[key]
                .Split(",");

            foreach(var containedBag in containedBags)
            {
                var bagInfo = containedBag.Trim().Split(" ");
                var count = int.Parse(bagInfo[0]);
                var name = $"{bagInfo[1]} {bagInfo[2]}";
                bagCount += CountBags(name, dictionary) * count + count;
            }

            return bagCount;
        }
    }
}
