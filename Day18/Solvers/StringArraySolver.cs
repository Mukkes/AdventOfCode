using AdventOfCode2021.Day16.Solvers;
using AdventOfCode2021.Day18.Parsers;

namespace AdventOfCode2021.Day18.Solvers
{
    public abstract class StringArraySolver : BaseSolver<string[]>
    {
        public StringArraySolver(string? input) : base(new InputToStringArrayParser(), input) { }
    }
}
