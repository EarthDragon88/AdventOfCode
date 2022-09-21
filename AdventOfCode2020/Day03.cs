using System;
using System.Collections.Generic;
using System.Text;
using Utility;

namespace AdventOfCode2020
{
    public class Day03 : AdventProblem
    {

        public override object SolvePuzzle1()
        {
            var lines = raw.Trim().Split('\n');
            var height = lines.Length;
            var width = lines[0].Length;

            var count = 0;

            var posx = 3;
            var posy = 1;

            while (posy < height)
            {
                var currLine = lines[posy];
                var square = currLine[posx % width];

                if (square == '#')
                    count++;

                posx += 3;
                posy += 1;
            }

            return count;
        }

        public override object SolvePuzzle2()
        {
            var lines = raw.Trim().Split('\n');

            long slope1 = CountSlopes(lines, 1, 1);
            long slope2 = CountSlopes(lines, 3, 1);
            long slope3 = CountSlopes(lines, 5, 1);
            long slope4 = CountSlopes(lines, 7, 1);
            long slope5 = CountSlopes(lines, 1, 2);

            return (slope1 * slope2 * slope3 * slope4 * slope5);
        }

        private int CountSlopes(string[] lines, int slopeX, int slopeY)
        {
            var height = lines.Length;
            var width = lines[0].Length;

            var count = 0;

            var posX = slopeX;
            var posY = slopeY;

            while (posY < height)
            {
                var currLine = lines[posY];
                var square = currLine[posX % width];

                if (square == '#')
                    count++;

                posX += slopeX;
                posY += slopeY;
            }

            return count;
        }
    }
}
