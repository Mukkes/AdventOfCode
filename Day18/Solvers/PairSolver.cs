using AdventOfCode2021.Day16.Solvers;
using AdventOfCode2021.Day18.Parsers;

namespace AdventOfCode2021.Day18.Solvers
{
    public abstract class PairSolver : BaseSolver<List<Pair>>
    {
        public PairSolver(string? input) : base(new PairParser(), input) { }
    }
}
