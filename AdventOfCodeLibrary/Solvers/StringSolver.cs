using AdventOfCodeLibrary.Parsers;

namespace AdventOfCodeLibrary.Solvers;

public abstract class StringSolver : StringSolver<VoidParser>
{
}

public abstract class StringSolver<TParser> : BaseSolver<string>
    where TParser : IInputParser<string>, new()
{
    public StringSolver() : base(new TParser()) { }
}
