using AdventOfCodeLibrary.Parsers;

namespace AdventOfCodeLibrary.Solvers;

public abstract class IntArraySolver : BaseSolver<int[]>
{
    public IntArraySolver() : base(new InputToIntArrayParser()) { }
}
