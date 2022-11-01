using AdventOfCode2021.Day16.Parsers;

namespace AdventOfCode2021.Day16.Solvers
{
    public abstract class StringSolver : StringSolver<InputToStringParser> { }

    public abstract class StringSolver<TParser> : BaseSolver<string>
        where TParser : IInputParser<string>, new()
    {
        public StringSolver() : base(new TParser()) { }
    }
}
