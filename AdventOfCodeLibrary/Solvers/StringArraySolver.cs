using AdventOfCodeLibrary.Parsers;

namespace AdventOfCodeLibrary.Solvers;

public abstract class StringArraySolver : BaseSolver<string[]>
{
    public StringArraySolver(string? input) : base(new InputToStringArrayParser(), input) { }
}
