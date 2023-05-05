using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Utility
{
    public abstract class AdventProblem
    {
        protected string raw;

        public AdventProblem()
        {
            string solutionDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;

            var type = this.GetType().FullName.Split(".");
            var className = type[type.Length - 1].ToLower();

            var assemblyName = this.GetType().Namespace;
            var inputaddition = assemblyName.Substring(assemblyName.Length - 4);

            var dirPath = solutionDir + "\\" + assemblyName + "\\" +"input" + inputaddition;

            var file = Directory.GetFiles(dirPath)
                .Where(x => x.ToLower().Contains($"{className}"))
                .Single();

            raw = File.ReadAllText(file);

            if (raw.Contains("\r\n"))
            {
                var temp = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"File {file} contains window style newlines!" +
                    $" This should basically never happen, did you perhaps edit the" +
                    $" file and save it in windows?");
                Console.ForegroundColor = temp;
            }
        }

        public abstract object SolvePuzzle1();

        public abstract object SolvePuzzle2();
    }
}
