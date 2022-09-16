using System;
using System.Collections.Generic;
using System.Text;
using Utility;

namespace AdventOfCode2020
{
    public class Day6 : AdventProblem
    {
        public override string SolvePuzzle1()
        {
            var groups = raw.Trim().Split("\n\n");


            var sum = 0;
            
            foreach(var group in groups)
            {
                var awnsers = string
                    .Join( "", group.Split('\n') )
                    .ToCharArray();
                Array.Sort(awnsers);

                int count = 1;
                char lastUniqueAwnser = awnsers[0];
                for(int i = 1; i < awnsers.Length; i++)
                    if(awnsers[i] != awnsers[i - 1])
                    {
                        count++;
                        lastUniqueAwnser = awnsers[i];
                    }
                
                sum += count;
            }

            return sum.ToString();
        }

        public override string SolvePuzzle2()
        {
            var groups = raw.Trim().Split("\n\n");

            var sum = 0;

            foreach (var group in groups)
            {
                var groupAwnsers = group.Split('\n');
                var awnsers = string
                    .Join("", groupAwnsers)
                    .ToCharArray();
                Array.Sort(awnsers);

                var possibleGroupAwnsers = new List<char>();
                char lastUniqueAwnser = awnsers[0];
                possibleGroupAwnsers.Add(lastUniqueAwnser);

                for (int i = 1; i < awnsers.Length; i++)
                    if (awnsers[i] != awnsers[i - 1])
                    {
                        lastUniqueAwnser = awnsers[i];
                        possibleGroupAwnsers.Add(lastUniqueAwnser);
                    }

                var count = 0;
                foreach(var possibleAwnser in possibleGroupAwnsers)
                {
                    foreach(var groupAwnser in groupAwnsers)
                        if (!groupAwnser.Contains(possibleAwnser))
                            goto nonfound;
                    
                    count++;
                    nonfound: continue;
                }
                sum += count;
            }

            return sum.ToString();
        }
    }
}
