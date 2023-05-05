using Autofac;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Utility;

namespace Solver
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();

            LoadReferencedAssemblies();
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

            builder.RegisterAssemblyTypes(
                assemblies
                    .Where(x => x.FullName.StartsWith("AdventOfCode"))
                    .ToArray()
                )
                .Where(t => t.Name.StartsWith("Day"));

            var container = builder.Build();


            var projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            var targetsFile = projectDirectory + "\\" + "TARGETS.TXT";
            var targetsContent = File.ReadAllText(targetsFile).Trim();
            List<string> targets = null;
            if (targetsContent.Contains("\r\n")) // Windows file
                targets = targetsContent.Split("\r\n")
                    .Select(x => x.Trim())
                    .ToList();
            else
                targets = targetsContent.Split("\n") // Linux file
                    .Select(x => x.Trim())
                    .ToList();

            RunProblems(assemblies, container, targets);

            Console.ReadKey();
        }

        private static void RunProblems(Assembly[] assemblies, IContainer container, List<string> targets)
        {
            foreach (var target in targets)
            {
                var targetParts = target.Split(".");
                var year = targetParts[0];
                var day = targetParts[1];
                var Namespace = $"AdventOfCode{year}";
                var Class = $"Day{day.PadLeft(2, '0')}";

                var assembly = assemblies.Where(x => x.FullName.StartsWith(Namespace))
                    .Single();
                var type = assembly.GetType($"{Namespace}.{Class}");

                var problem = container.Resolve(type) as AdventProblem;
                SolveAndDisplay(problem);
            }
        }

        private static void SolveAndDisplay(AdventProblem problem)
        {
            Console.WriteLine($"Class: {problem.GetType().FullName}");

            Console.WriteLine($"Solution1: |{SolveProblem(problem.SolvePuzzle1)}|");
            Console.WriteLine($"Solution2: |{SolveProblem(problem.SolvePuzzle2)}|");
        }

        private static string SolveProblem(Func<object> problem)
        {
            string result = null;
            try
            {
                result = problem().ToString();
            }
            catch (NotImplementedException)
            {
                result = "NOT IMPLEMENTED";
            }
            return result;
        }

        private static void LoadReferencedAssemblies()
        {
            var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
            var loadedPaths = loadedAssemblies.Select(a => a.Location).ToArray();

            var referencedPaths = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll");
            var toLoad = referencedPaths.Where(r => !loadedPaths.Contains(r, StringComparer.InvariantCultureIgnoreCase)).ToList();

            toLoad.ForEach(path => loadedAssemblies.Add(AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(path))));
        }
    }
}
