using AdventOfCode.Year2024.Day17.Models;
using AdventOfCode.Year2024.Day17.Parsers;
using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.Parsers;
using AdventOfCodeLibrary.Solvers;

namespace AdventOfCode.Year2024.Day17.Solvers;

[Solver]
public class Solver : BaseSolver<ChronospatialComputer>
{
    //public override object? AnswerPartOne => ;

    //public override object? AnswerPartTwo => ;

    protected override IInputParser<ChronospatialComputer> InputParser => new ChronospatialComputerParser();

    public override object SolvePartOne()
    {
        var x = ParsedInput;
        return 0;
    }

    public override object SolvePartTwo()
    {
        return 0;
    }
}
