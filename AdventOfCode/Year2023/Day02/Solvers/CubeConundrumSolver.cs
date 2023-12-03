using AdventOfCode.Year2023.Day02.Models;
using AdventOfCode.Year2023.Day02.Parsers;
using AdventOfCodeLibrary.Solvers;

namespace AdventOfCode.Year2023.Day02.Solvers;

public abstract class CubeConundrumSolver : BaseSolver<List<Game>>
{
    public CubeConundrumSolver() : base(new CubeConundrumParser()) { }
}
