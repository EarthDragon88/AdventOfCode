using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace AdventOfCode2020
{
    public class Day11 : AdventProblem
    {
        public override string SolvePuzzle1()
        {
            var input = raw.Trim();

            var lines = input.Split("\n");

            var width =  lines[0].Length;
            var height = lines.Length;

            var map = input.Replace("\n", "").ToCharArray();

            var equalsPreviousMap = false;
            int loops = 0;
            while (!equalsPreviousMap)
            {
                var stepResult = ExecuteSteps1(map, width, height);

                var isEqual = Enumerable.SequenceEqual(map, stepResult);
                if (isEqual)
                    equalsPreviousMap = true;
                
                map = stepResult;

                // Console.WriteLine(++loops);
            }

            var seatCount = 0;
            foreach (var seat in map)
                if (seat == '#')
                    seatCount++;

            return seatCount.ToString();
        }

        private static void PrintSeats(int width, int height, char[] stepResult)
        {
            Console.WriteLine();
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write(stepResult[i * width + j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private static void PrintSeats2(int width, int height, char[] stepResult)
        {
            Console.WriteLine();
            var sb = new StringBuilder();
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    sb.Append(stepResult[i * width + j]);
                }
                sb.Append('\n');
            };
            var mapString = sb.ToString();
            Console.WriteLine(mapString);
            Console.WriteLine();
        }

        private char[] ExecuteSteps1(char[] map, int width, int height)
        {
            var mapCopy = new char[map.Length];
            map.CopyTo(mapCopy, 0);

            for(int posY = 0; posY < height; posY++)
            {
                for(int posX = 0; posX < width; posX++)
                {
                    var currentSeat = map[posY * width + posX];

                    if (currentSeat == 'L')
                    {
                        var numOccupiedAjacentSeats =
                            CountAjacentCharacters1(map, width, height, posX, posY, '#');
                        if (numOccupiedAjacentSeats == 0)
                            mapCopy[posY * width + posX] = '#';
                    }
                    else if (currentSeat == '#')
                    {
                        var numOccupiedAjacentSeats =
                            CountAjacentCharacters1(map, width, height, posX, posY, '#');
                        if (numOccupiedAjacentSeats >= 4)
                            mapCopy[posY * width + posX] = 'L';
                    }
                }
            }

            return mapCopy;
        }

        private static int CountAjacentCharacters1(char[] map,
            int width,
            int height,
            int posX,
            int posY,
            char target)
        {

            var numOccupiedAjacentSeats = 0;

            if (posY - 1 >= 0 && map[(posY - 1) * width + posX] == target)
                numOccupiedAjacentSeats++;

            if (posY - 1 >= 0 && posX + 1 < width && map[(posY - 1) * width + posX + 1] == target)
                numOccupiedAjacentSeats++;

            if (posX + 1 < width && map[posY * width + (posX + 1)] == target)
                numOccupiedAjacentSeats++;

            if (posY + 1 < height && posX + 1 < width && map[(posY + 1) * width + (posX + 1)] == target)
                numOccupiedAjacentSeats++;

            if (posY + 1 < height && map[(posY + 1) * width + posX] == target)
                numOccupiedAjacentSeats++;

            if (posY + 1 < height && posX - 1 >= 0 && map[(posY + 1) * width + posX - 1] == target)
                numOccupiedAjacentSeats++;

            if (posX - 1 >= 0 && map[posY * width + (posX - 1)] == target)
                numOccupiedAjacentSeats++;

            if (posY - 1 >= 0 && posX - 1 >= 0 && map[(posY - 1) * width + (posX - 1)] == target)
                numOccupiedAjacentSeats++;

            return numOccupiedAjacentSeats;
        }

        public override string SolvePuzzle2()
        {
            var input = raw.Trim();

            var lines = input.Split("\n");

            var width = lines[0].Length;
            var height = lines.Length;

            var map = input.Replace("\n", "").ToCharArray();

            var equalsPreviousMap = false;
            int loops = 0;
            while (!equalsPreviousMap)
            {
                var stepResult = ExecuteSteps2(map, width, height);
                //PrintSeats(width, height, stepResult);

                var isEqual = Enumerable.SequenceEqual(map, stepResult);
                if (isEqual)
                    equalsPreviousMap = true;

                map = stepResult;

                // Console.WriteLine(++loops);
            }

            var seatCount = 0;
            foreach (var seat in map)
                if (seat == '#')
                    seatCount++;

            return seatCount.ToString();
        }

        private char[] ExecuteSteps2(char[] map, int width, int height)
        {
            var mapCopy = new char[map.Length];
            map.CopyTo(mapCopy, 0);

            for (int posY = 0; posY < height; posY++)
            {
                for (int posX = 0; posX < width; posX++)
                {
                    var currentSeat = map[posY * width + posX];

                    if (currentSeat == 'L')
                    {
                        var numOccupiedAjacentSeats =
                            CountAjacentCharacters2(map, width, height, posX, posY, '#', 'L');
                        if (numOccupiedAjacentSeats == 0)
                            mapCopy[posY * width + posX] = '#';
                    }
                    else if (currentSeat == '#')
                    {
                        var numOccupiedAjacentSeats =
                            CountAjacentCharacters2(map, width, height, posX, posY, '#', 'L');
                        if (numOccupiedAjacentSeats >= 5)
                            mapCopy[posY * width + posX] = 'L';
                    }
                }
            }

            return mapCopy;
        }

        private static int CountAjacentCharacters2(char[] map,
            int width,
            int height,
            int posX,
            int posY,
            char filledSeat,
            char emptySeat)
        {

            var numOccupiedAjacentSeats = 0;

            for(int y = posY - 1, x = posX; y >= 0; y--)
            { 
                if(map[y * width + x] == filledSeat)
                {
                    numOccupiedAjacentSeats++;
                    break;
                }
                else if (map[y * width + x] == emptySeat)
                {
                    break;
                }
            }

            for (int y = posY - 1, x = posX + 1; y >= 0 && x < width; y--, x++)
            {
                if (map[y * width + x] == filledSeat)
                {
                    numOccupiedAjacentSeats++;
                    break;
                }
                else if (map[y * width + x] == emptySeat)
                {
                    break;
                }
            }

            for (int y = posY, x = posX + 1; x < width; x++)
            {
                if (map[y * width + x] == filledSeat)
                {
                    numOccupiedAjacentSeats++;
                    break;
                }
                else if (map[y * width + x] == emptySeat)
                {
                    break;
                }
            }

            for (int y = posY + 1, x = posX + 1; y < height && x < width; y++, x++)
            {
                if (map[y * width + x] == filledSeat)
                {
                    numOccupiedAjacentSeats++;
                    break;
                }
                else if (map[y * width + x] == emptySeat)
                {
                    break;
                }
            }


            for (int y = posY + 1, x = posX; y < height; y++)
            {
                if (map[y * width + x] == filledSeat)
                {
                    numOccupiedAjacentSeats++;
                    break;
                }
                else if (map[y * width + x] == emptySeat)
                {
                    break;
                }
            }


            for (int y = posY + 1, x = posX - 1; y < height && x >= 0; y++, x--)
            {
                if (map[y * width + x] == filledSeat)
                {
                    numOccupiedAjacentSeats++;
                    break;
                }
                else if (map[y * width + x] == emptySeat)
                {
                    break;
                }
            }


            for (int y = posY, x = posX - 1; x >= 0; x--)
            {
                if (map[y * width + x] == filledSeat)
                {
                    numOccupiedAjacentSeats++;
                    break;
                }
                else if (map[y * width + x] == emptySeat)
                {
                    break;
                }
            }


            for (int y = posY - 1, x = posX - 1; y >= 0 && x >= 0; y--, x--)
            {
                if (map[y * width + x] == filledSeat)
                {
                    numOccupiedAjacentSeats++;
                    break;
                }
                else if (map[y * width + x] == emptySeat)
                {
                    break;
                }
            }


            return numOccupiedAjacentSeats;
        }
    }
}
