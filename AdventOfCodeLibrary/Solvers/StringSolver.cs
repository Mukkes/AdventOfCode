using AdventOfCodeLibrary.Parsers;

namespace AdventOfCodeLibrary.Solvers;

public abstract class StringSolver : StringSolver<VoidParser>
{
    public StringSolver() : base() { }
    public StringSolver(string? input) : base(input) { }
}

public abstract class StringSolver<TParser> : BaseSolver<string>
    where TParser : IInputParser<string>, new()
{
    public StringSolver() : base(new TParser()) { }
    public StringSolver(string? input) : base(new TParser(), input) { }
}
