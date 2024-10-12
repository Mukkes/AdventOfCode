using AdventOfCode.Year2023.Day02.Models;
using AdventOfCode.Year2023.Day02.Parsers;
using AdventOfCodeLibrary.Parsers;
using AdventOfCodeLibrary.Solvers;

namespace AdventOfCode.Year2023.Day02.Solvers;

public abstract class CubeConundrumSolver : BaseSolver<List<Game>>
{
    protected override IInputParser<List<Game>> InputParser => new CubeConundrumParser();
}
