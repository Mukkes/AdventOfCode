using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.Parsers;
using AdventOfCodeLibrary.Solvers;

namespace AdventOfCode.Year2021.Day07.Solvers;

[Solver]
public class Solver : BaseSolver<List<int>>
{
    public override int Year => 2021;

    public override int Day => 7;

    public override object? AnswerPartOne => 336131;

    public override object? AnswerPartTwo => 92676646;

    protected override IInputParser<List<int>> InputParser => new IntListParser(",");

    public override object SolvePartOne()
    {
        var leastFuel = int.MaxValue;
        var lowestPosition = ParsedInput.Min();
        var highestPosition = ParsedInput.Max();
        for (var position = lowestPosition; position <= highestPosition; position++)
        {
            var fuel = 0;
            foreach (var number in ParsedInput)
            {
                fuel += Math.Abs(number - position);
            }
            if (fuel < leastFuel)
            {
                leastFuel = fuel;
            }
        }
        return leastFuel;
    }

    public override object SolvePartTwo()
    {
        var leastFuel = int.MaxValue;
        var lowestPosition = ParsedInput.Min();
        var highestPosition = ParsedInput.Max();
        for (var position = lowestPosition; position <= highestPosition; position++)
        {
            var fuel = 0;
            foreach (var number in ParsedInput)
            {
                var n = Math.Abs(number - position);
                fuel += TriangularNumber(n);
            }
            if (fuel < leastFuel)
            {
                leastFuel = fuel;
            }
        }
        return leastFuel;
    }

    private int TriangularNumber(int n)
    {
        return n * (n + 1) / 2;
    }
}
