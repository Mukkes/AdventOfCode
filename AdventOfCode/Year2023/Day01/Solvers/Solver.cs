using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.Parsers;
using AdventOfCodeLibrary.Solvers;

namespace AdventOfCode.Year2023.Day01.Solvers;

[Solver]
public class Solver : BaseSolver<string>
{
    private readonly StringArrayParser _parser = new StringArrayParser();

    public override int Year => 2023;

    public override int Day => 1;

    public override object? AnswerPartOne => 54304;

    public override object? AnswerPartTwo => 54418;

    protected override IInputParser<string> InputParser => new VoidParser();

    public override object SolvePartOne()
    {
        return GetSumFromLines(ParsedInput);
    }

    public override object SolvePartTwo()
    {
        var input = ParsedInput.Replace("one", "o1e");
        input = input.Replace("two", "t2o");
        input = input.Replace("three", "t3e");
        input = input.Replace("four", "f4r");
        input = input.Replace("five", "f5e");
        input = input.Replace("six", "s6x");
        input = input.Replace("seven", "s7n");
        input = input.Replace("eight", "e8t");
        input = input.Replace("nine", "n9e");
        return GetSumFromLines(input);
    }

    private int GetSumFromLines(string input)
    {
        var sum = 0;
        foreach (var line in _parser.Parse(input))
        {
            var stringSum = string.Empty;
            stringSum += GetDigitFromLine(line);
            var reversedLine = line.Reverse();
            stringSum += GetDigitFromLine(reversedLine);
            sum += int.Parse(stringSum);
        }
        return sum;
    }

    private string GetDigitFromLine(IEnumerable<char> line)
    {
        foreach (var c in line)
        {
            if (char.IsDigit(c))
            {
                return c.ToString();
            }
        }
        return string.Empty;
    }
}
