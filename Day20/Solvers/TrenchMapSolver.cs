using AdventOfCode2021.Day16.Solvers;
using AdventOfCode2021.Day20.Parsers;

namespace AdventOfCode2021.Day20.Solvers
{
    public abstract class TrenchMapSolver : BaseSolver<TrenchMap>
    {
        public TrenchMapSolver(string? input) : base(new TrenchMapParser(), input) { }
    }
}
