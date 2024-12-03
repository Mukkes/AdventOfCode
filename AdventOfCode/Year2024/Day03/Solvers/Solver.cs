using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.Parsers;
using AdventOfCodeLibrary.Solvers;
using System.Text.RegularExpressions;

namespace AdventOfCode.Year2024.Day03.Solvers;

[Solver]
public class Solver : BaseSolver<string>
{
    public override int Year => 2024;

    public override int Day => 3;

    public override object? AnswerPartOne => 161085926L;

    public override object? AnswerPartTwo => 82045421L;

    protected override IInputParser<string> InputParser => new VoidParser();

    public override object SolvePartOne()
    {
        return GetSumMulInstructions(ParsedInput);
    }

    public override object SolvePartTwo()
    {
        var strippedInput = Regex.Replace(ParsedInput, @"don't\(\)[\s\S]*?do\(\)" , "");
        return GetSumMulInstructions(strippedInput);
    }

    private long GetSumMulInstructions(string input)
    {
        var sum = 0L;
        var mulInstructions =
            Regex.Matches(input, @"(mul\(\d{1,3},\d{1,3}\))")
            .Select(match => match.Value);
        foreach (var mulInstruction in mulInstructions)
        {
            var numbers =
                Regex.Matches(mulInstruction, @"(\d{1,3})")
                .Select(match => int.Parse(match.Value))
                .ToList();
            sum += numbers[0] * numbers[1];
        }
        return sum;
    }
}
