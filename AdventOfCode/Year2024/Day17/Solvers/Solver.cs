using AdventOfCode.Year2024.Day17.Models;
using AdventOfCode.Year2024.Day17.Parsers;
using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.Parsers;
using AdventOfCodeLibrary.Solvers;

namespace AdventOfCode.Year2024.Day17.Solvers;

[Solver]
public class Solver : BaseSolver<ChronospatialComputer>
{
    public override object? AnswerPartOne => "1,2,3,1,3,2,5,3,1";

    //public override object? AnswerPartTwo => ;

    protected override IInputParser<ChronospatialComputer> InputParser => new ChronospatialComputerParser();

    public override object SolvePartOne()
    {
        var computer = ParsedInput;
        computer.Run();
        return computer.GetOutputAsString();
    }

    public override object SolvePartTwo()
    {
        return 0;
    }
}
