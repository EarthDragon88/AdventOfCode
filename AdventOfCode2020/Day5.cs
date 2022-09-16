using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace AdventOfCode2020
{
    public class Day5 : AdventProblem
    {
        public override string SolvePuzzle1()
        {
            var lines = raw.Trim().Split('\n');

            var highestId = 0;

            for(int i = 0; i < lines.Length; i++)
            {
                var row = FindRow(lines[i].Substring(0, 7));
                var col = FindColumn(lines[i].Substring(7, 3));
                var id = row * 8 + col;

                if (id > highestId)
                    highestId = id;
            }

            return highestId.ToString();
        }

        private int FindRow(string line)
        {
            var minRow = 0;
            var maxRow = 127;

            for(int i = 0; i < line.Length; i++)
            {
                var diff = maxRow - minRow;
                var middle = diff / 2;
                if (line[i] == 'F')
                    maxRow = minRow + middle;
                else if (line[i] == 'B')
                    minRow = maxRow - middle;
            }

            return minRow;
        }

        private int FindColumn(string line)
        {
            var minRow = 0;
            var maxRow = 7;

            for (int i = 0; i < line.Length; i++)
            {
                var diff = maxRow - minRow;
                var middle = diff / 2;
                if (line[i] == 'L')
                    maxRow = minRow + middle;
                else if (line[i] == 'R')
                    minRow = maxRow - middle;
            }

            return minRow;
        }

        public override string SolvePuzzle2()
        {
            var lines = raw.Trim().Split('\n');

            var ids = new List<int>();

            for (int i = 0; i < lines.Length; i++)
            {
                var row = FindRow(lines[i].Substring(0, 7));
                var col = FindColumn(lines[i].Substring(7, 3));
                var id = row * 8 + col;

                ids.Add(id);
            }

            ids.Sort();

            for(int i = 0; i < ids.Count() - 1; i++)
                if(ids[i] + 1 != ids[i + 1])
                    return (ids[i] + 1).ToString();

            throw new Exception("Code should never get here!");
        }
    }
}
