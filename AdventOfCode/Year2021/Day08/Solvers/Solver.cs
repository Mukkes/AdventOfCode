using AdventOfCode.Year2021.Day08.Models;
using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.Parsers;
using AdventOfCodeLibrary.Solvers;

namespace AdventOfCode.Year2021.Day08.Solvers;

[Solver]
public class Solver : BaseSolver<List<string>>
{
    public override object? AnswerPartOne => 493;

    public override object? AnswerPartTwo => 1010460;

    protected override IInputParser<List<string>> InputParser => new StringListParser();

    public override object SolvePartOne()
    {
        return ParsedInput
                .Select(s => new SevenSegmentEntry(s))
                .ToList()
                .Sum(s => s.NumberOfUniqueDigits());
    }

    public override object SolvePartTwo()
    {
        return ParsedInput
                .Select(s => new SevenSegmentEntry(s))
                .ToList()
                .Sum(s => s.GetOutputNumber());
    }
}
