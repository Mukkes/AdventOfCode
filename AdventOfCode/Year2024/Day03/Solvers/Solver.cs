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
        return
            Regex.Matches(input, @"(mul\((?<num1>\d{1,3}),(?<num2>\d{1,3})\))")
            .Select(match => int.Parse(match.Groups["num1"].Value) * int.Parse(match.Groups["num2"].Value))
            .Sum();
    }
}
