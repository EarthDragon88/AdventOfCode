using Autofac;
using System;
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

            builder.RegisterAssemblyTypes(
                typeof(AdventOfCode2015.Day01).Assembly,
                typeof(AdventOfCode2016.Day01).Assembly,
                typeof(AdventOfCode2017.Day01).Assembly,
                typeof(AdventOfCode2018.Day01).Assembly,
                typeof(AdventOfCode2019.Day01).Assembly,
                typeof(AdventOfCode2020.Day01).Assembly,
                typeof(AdventOfCode2021.Day01).Assembly,
                typeof(AdventOfCode2022.Day01).Assembly
                )
                .Where(t => t.Name.StartsWith("Day"));

            var container = builder.Build();

            var problem = container.Resolve<AdventOfCode2015.Day01>();

            SolveAndDisplay(problem);

            Console.ReadKey();
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
    }
}
