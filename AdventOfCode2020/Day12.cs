using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace AdventOfCode2020
{
    public class Day12 : AdventProblem
    {

        private static char[] CardinalDirectoins = { 'N', 'E', 'S', 'W' };

        public override object SolvePuzzle1()
        {
            var instructions = raw.Trim().Split("\n");

            var posX = 0;
            var posY = 0;
            var faceDicrection = 'E';

            foreach(var instruction in instructions)
            {
                var letter = instruction[0];
                var number = int.Parse(instruction.Substring(1, instruction.Length - 1));

                if(CardinalDirectoins.Contains(letter))
                    Move(ref posX, ref posY, letter, number);
                else if (letter == 'F')
                    Move(ref posX, ref posY, faceDicrection, number);
                else if (letter == 'L')
                    faceDicrection = RotateLeft(faceDicrection, number);
                else if (letter == 'R')
                    faceDicrection = RotateRight(faceDicrection, number);
            }

            return Math.Abs(posX) + Math.Abs(posY);
        }

        private static void Move(ref int posX, ref int posY, char letter, int number)
        {
            switch (letter)
            {
                case 'N':
                    posY -= number;
                    break;
                case 'E':
                    posX += number;
                    break;
                case 'S':
                    posY += number;
                    break;
                case 'W':
                    posX -= number;
                    break;
                default:
                    throw new InvalidOperationException("Code should never get here");
            }
        }

        private static char RotateRight(char faceDicrection, int number)
        {
            var turns = number / 90;
            var directionPos = Array.IndexOf(CardinalDirectoins, faceDicrection);
            var newPos = ((directionPos + turns) % + CardinalDirectoins.Length)
                % CardinalDirectoins.Length;
            faceDicrection = CardinalDirectoins[newPos];
            return faceDicrection;
        }

        private static char RotateLeft(char faceDicrection, int number)
        {
            var turns = number / 90;
            var directionPos = Array.IndexOf(CardinalDirectoins, faceDicrection);
            var newPos = ((directionPos - turns) + CardinalDirectoins.Length)
                % CardinalDirectoins.Length;
            faceDicrection = CardinalDirectoins[newPos];
            return faceDicrection;
        }

        public override object SolvePuzzle2()
        {
            var instructions = raw.Trim().Split("\n");

            var shipPosX = 0;
            var shipPosY = 0;
            var waypointPosX = 10;
            var waypointPosY = 1;

            foreach (var instruction in instructions)
            {
                var letter = instruction[0];
                var number = int.Parse(instruction.Substring(1, instruction.Length - 1));

                if (CardinalDirectoins.Contains(letter))
                    MoveWaypoint(ref waypointPosX, ref waypointPosY, letter, number);
                else if (letter == 'F')
                    MoveTowardWaypoint(ref shipPosX, ref shipPosY, waypointPosX, waypointPosY, number);
                else if (letter == 'L')
                    RotateWaypointLeft(ref waypointPosX, ref waypointPosY, number);
                else if (letter == 'R')
                    RotateWaypointRight(ref waypointPosX, ref waypointPosY, number);
            }

            return Math.Abs(shipPosX) + Math.Abs(shipPosY);
        }

        private static void MoveTowardWaypoint(ref int shipPosX, ref int shipPosY, int waypointPosX, int waypointPosY, int number)
        {
            shipPosX += waypointPosX * number;
            shipPosY += waypointPosY * number;
        }

        private static void RotateWaypointRight(ref int waypointPosX, ref int waypointPosY, int number)
        {
            var turns = number / 90;

            for (int i = 0; i < turns; i++)
            {
                int tempWayPositionX = 0;
                int tempWayPositionY = 0;
                if (waypointPosX >= 0 && waypointPosY >= 0)
                {
                    tempWayPositionX = waypointPosY;
                    tempWayPositionY = -waypointPosX;
                }
                else if (waypointPosX >= 0 && waypointPosY <= 0)
                {
                    tempWayPositionX = waypointPosY;
                    tempWayPositionY = -waypointPosX;
                }
                else if (waypointPosX <= 0 && waypointPosY <= 0)
                {
                    tempWayPositionX = waypointPosY;
                    tempWayPositionY = -waypointPosX;
                }
                else if (waypointPosX <= 0 && waypointPosY >= 0)
                {
                    tempWayPositionX = waypointPosY;
                    tempWayPositionY = -waypointPosX;
                }

                waypointPosX = tempWayPositionX;
                waypointPosY = tempWayPositionY;
            }
        }

        private static void RotateWaypointLeft(ref int waypointPosX, ref int waypointPosY, int number)
        {
            var turns = number / 90;

            for (int i = 0; i < turns; i++)
            {
                int tempWayPositionX = 0;
                int tempWayPositionY = 0;

                if (waypointPosX >= 0 && waypointPosY >= 0)
                {
                    tempWayPositionX = -waypointPosY;
                    tempWayPositionY = waypointPosX;
                }
                else if (waypointPosX <= 0 && waypointPosY >= 0)
                {
                    tempWayPositionX = -waypointPosY;
                    tempWayPositionY = waypointPosX;
                }
                else if (waypointPosX <= 0 && waypointPosY <= 0)
                {
                    tempWayPositionX = -waypointPosY;
                    tempWayPositionY = waypointPosX;
                }
                else if (waypointPosX >= 0 && waypointPosY <= 0)
                {
                    tempWayPositionX = -waypointPosY;
                    tempWayPositionY = waypointPosX;
                }

                waypointPosX = tempWayPositionX;
                waypointPosY = tempWayPositionY;
            }
        }

        private static void MoveWaypoint(ref int waypointPosX, ref int waypointPosY, char letter, int number)
        {
            switch (letter)
            {
                case 'N':
                    waypointPosY += number;
                    break;
                case 'E':
                    waypointPosX += number;
                    break;
                case 'S':
                    waypointPosY -= number;
                    break;
                case 'W':
                    waypointPosX -= number;
                    break;
                default:
                    throw new InvalidOperationException("Code should never get here");
            }
        }
    }
}
