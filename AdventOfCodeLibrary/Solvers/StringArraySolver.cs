using AdventOfCodeLibrary.Parsers;

namespace AdventOfCodeLibrary.Solvers;

public abstract class StringArraySolver : BaseSolver<string[]>
{
    public StringArraySolver() : base(new InputToStringArrayParser()) { }
}
