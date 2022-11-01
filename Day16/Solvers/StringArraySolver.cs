using AdventOfCode2021.Day16.Parsers;

namespace AdventOfCode2021.Day16.Solvers
{
    public abstract class StringArraySolver : BaseSolver<string[]>
    {
        public StringArraySolver() : base(new InputToStringArrayParser()) { }
    }
}
