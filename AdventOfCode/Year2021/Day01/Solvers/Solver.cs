using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.Parsers;
using AdventOfCodeLibrary.Solvers;

namespace AdventOfCode.Year2021.Day01.Solvers;

[Solver]
public class Solver : BaseSolver<int[]>
{
    public override object? AnswerPartOne => 1655;

    public override object? AnswerPartTwo => 1683;

    protected override IInputParser<int[]> InputParser => new IntArrayParser();

    public override object SolvePartOne()
    {
        var largerCount = 0;
        for (var i = 1; i < ParsedInput.Length; i++)
        {
            if (ParsedInput[i] > ParsedInput[i - 1])
            {
                largerCount++;
            }
        }
        return largerCount;
    }

    public override object SolvePartTwo()
    {
        var largerCount = 0;
        for (var i = 3; i < ParsedInput.Length; i++)
        {
            var previousDepth = ParsedInput[i - 3] + ParsedInput[i - 2] + ParsedInput[i - 1];
            var depth = ParsedInput[i - 2] + ParsedInput[i - 1] + ParsedInput[i];
            if (depth > previousDepth)
            {
                largerCount++;
            }
        }
        return largerCount;
    }
}
