using AdventOfCode2021.Day16.Parsers;

namespace AdventOfCode2021.Day16.Solvers
{
    public abstract class StringSolver : StringSolver<VoidParser> { }

    public abstract class StringSolver<TParser> : BaseSolver<string>
        where TParser : IInputParser<string>, new()
    {
        public StringSolver() : base(new TParser()) { }
        public StringSolver(string input) : base(new TParser(), input) { }
    }
}
