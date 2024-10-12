using AdventOfCodeLibrary.Parsers;

namespace AdventOfCodeLibrary.Solvers;

public abstract class IntArraySolver : IntArraySolver<InputToIntArrayParser>
{
}

public abstract class IntArraySolver<TParser> : BaseSolver<int[]>
    where TParser : IInputParser<int[]>, new()
{
    public IntArraySolver() : base(new TParser()) { }
}
