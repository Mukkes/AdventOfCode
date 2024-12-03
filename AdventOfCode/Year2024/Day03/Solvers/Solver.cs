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
        var sum = 0L;
        var mulInstructions = 
            Regex.Matches(ParsedInput, @"(mul\(\d{1,3},\d{1,3}\))")
            .Cast<Match>()
            .Select(match => match.Value);
        foreach (var mulInstruction in mulInstructions)
        {
            var numbers = 
                Regex.Matches(mulInstruction, @"(\d{1,3})")
                .Cast<Match>()
                .Select(match => int.Parse(match.Value))
                .ToList();
            sum += numbers[0] * numbers[1];
        }
        return sum;
    }

    public override object SolvePartTwo()
    {
        var sum = 0L;
        var stripedInput = Regex.Replace(ParsedInput, @"don't\(\)[\s\S]*?do\(\)" , "");
        var mulInstructions =
            Regex.Matches(stripedInput, @"(mul\(\d{1,3},\d{1,3}\))")
            .Cast<Match>()
            .Select(match => match.Value);
        foreach (var mulInstruction in mulInstructions)
        {
            var numbers =
                Regex.Matches(mulInstruction, @"(\d{1,3})")
                .Cast<Match>()
                .Select(match => int.Parse(match.Value))
                .ToList();
            sum += numbers[0] * numbers[1];
        }
        return sum;
    }
}
