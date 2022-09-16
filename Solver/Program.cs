using AdventOfCode2020;
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

            builder.RegisterAssemblyTypes(GetAssemblyByName("AdventOfCode2020"))
                .Where(t => t.Name.StartsWith("Day"));

            var container = builder.Build();

            var problem = container.Resolve<Day3>();

            SolveAndDisplay(problem);

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static void SolveAndDisplay(AdventProblem problem)
        {
            Console.WriteLine($"Class: {problem.GetType().FullName}");

            try
            {
                var solution1 = problem.SolvePuzzle1();
                Console.WriteLine($"Solution1: |{solution1}|");
            }
            catch (NotImplementedException)
            {
                Console.WriteLine($"Solution1: |NOT IMPLEMENTED|");
            }

            try
            {
                var solution1 = problem.SolvePuzzle2();
                Console.WriteLine($"Solution2: |{solution1}|");
            }
            catch (NotImplementedException)
            {
                Console.WriteLine($"Solution2: |NOT IMPLEMENTED|");
            }
        }

        private static Assembly GetAssemblyByName(string name)
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .SingleOrDefault(assembly => assembly.GetName().Name == name);
        }
    }
}
