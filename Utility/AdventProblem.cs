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
            var type = this.GetType().FullName.Split(".");
            var className = type[type.Length - 1].ToLower();

            var assemblyName = this.GetType().Namespace;
            var inputaddition = assemblyName.Substring(assemblyName.Length - 4);


            var dirPath = Path.GetDirectoryName(this.GetType().Assembly.Location);

            var file = Directory.GetFiles(dirPath + "/input" + inputaddition)
                .Where(x => x.ToLower().Contains($"{className}"))
                .Single();

            raw = File.ReadAllText(file);
        }

        public abstract object SolvePuzzle1();

        public abstract object SolvePuzzle2();
    }
}
