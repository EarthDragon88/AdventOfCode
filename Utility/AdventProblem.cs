using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

            var file = Directory.GetFiles("./input")
                .Where(x => x.ToLower().Contains($"{className}"))
                .Single();

            raw = File.ReadAllText(file);
        }

        public abstract string SolvePuzzle1();

        public abstract string SolvePuzzle2();
    }
}
