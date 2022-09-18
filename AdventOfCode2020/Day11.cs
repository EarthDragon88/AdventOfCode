using System;
using System.Collections.Generic;
using System.Text;
using Utility;

namespace AdventOfCode2020
{
    public class Day11 : AdventProblem
    {
        public override string SolvePuzzle1()
        {
            var input = @"
#.##.##.##
#######.##
#.#.#..#..
####.##.##
#.##.##.##
#.#####.##
..#.#.....
##########
#.######.#
#.#####.##".Trim().Replace("\r\n", "\n");

            var lines = input.Split("\n");

            var width =  lines[0].Length;
            var height = lines.Length;

            var map = input.Replace("\n", "").ToCharArray();

            var equalsPreviousMap = false;
            while (!equalsPreviousMap)
            {
                var mapCopy = new char[map.Length];
                map.CopyTo(mapCopy, 0);
                // equalsPreviousMap = true;
            }

            throw new NotImplementedException();
        }

        public override string SolvePuzzle2()
        {
            throw new NotImplementedException();
        }
    }
}
