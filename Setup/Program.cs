using System.Reflection;

namespace Setup
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var currProjectDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            var solutionDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
            var sessionKey = File.ReadAllText(currProjectDir + "\\" + "SESSIONKEY.TXT").Trim();

            var targets = new List<string>()
            {
                "AdventOfCode2015",
                "AdventOfCode2016",
                "AdventOfCode2017",
                "AdventOfCode2018",
                "AdventOfCode2019",
                "AdventOfCode2020",
                "AdventOfCode2021",
                "AdventOfCode2022",
            };

            foreach (var target in targets)
            {
                var projectDir = solutionDir + "\\" + target;
                var year = target.Substring(target.Length - 4);

                CreateProjectClasses(projectDir, year, target);
                await CreateProjectFiles(projectDir, year, sessionKey);
            }
        }

        private static void CreateProjectClasses(string projectDir, string year, string @namespace)
        {
            for(int day = 1; day <= 25; day++)
            {
                var number = day.ToString().PadLeft(2, '0');
                var @class = $"Day{number}";
                var fileName = $"{@class}.cs";
                var fileFullName = projectDir + "\\" + fileName;

                if(!File.Exists(fileFullName))
                {
                    using (var sw = new StreamWriter(fileFullName, false))
                    {
                        var generated = ClassTemplate(@namespace, @class, year, day.ToString());
                        sw.Write(generated);
                    }
                }
            }
        }

        private static async Task CreateProjectFiles(string projectDir, string year, string sessionKey)
        {
            var fileFolder = "input"+year;
            var fileFolderFullName = projectDir + "\\" + fileFolder;

            if (!Directory.Exists(fileFolderFullName))
                Directory.CreateDirectory(fileFolderFullName);

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Cookie", $"session={sessionKey}");

            for (int day = 1; day <= 25; day++)
            {
                var number = day.ToString().PadLeft(2, '0');
                var @class = $"Day{number}";
                var fileName = $"{@class}.txt";
                var fileFullName = fileFolderFullName + "\\" + fileName;

                if (!File.Exists(fileFullName))
                {
                    var response = await client.GetAsync(@"https://adventofcode.com/" + year + @"/day/" + day + "/input");
                    var responseBody = await response.Content.ReadAsStringAsync();
                    using (var sw = new StreamWriter(fileFullName, false))
                    {
                        sw.Write(responseBody);
                        Console.WriteLine($"Created input for year {year} day {day}");
                    }
                }

            }
        }

        private static string ClassTemplate(string @namespace, string @class, string year, string day)
        {
            return
@"﻿using Utility;

//" + $" https://adventofcode.com/{year}/day/{day}" +@"
namespace " + @namespace + @"
{
    public class " + @class + @": AdventProblem
    {
        public override object SolvePuzzle1()
        {
            throw new NotImplementedException();
        }

        public override object SolvePuzzle2()
        {
            throw new NotImplementedException();
        }
    }
}";
        }
    }
}