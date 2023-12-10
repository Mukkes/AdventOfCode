using AdventOfCodeLibrary.Attributes;

namespace AdventOfCode.Year2023.Day02.Solvers;

[Solver]
public class Solver : CubeConundrumSolver
{
    public override int Year => 2023;

    public override int Day => 2;

    public override object? AnswerPartOne => 2006;

    public override object? AnswerPartTwo => 84911;

    public override object SolvePartOne()
    {
        var maxBlue = 14;
        var maxGreen = 13;
        var maxRed = 12;
        var sum = 0;
        foreach (var game in Input)
        {
            if (game.MaxBlue > maxBlue)
            {
                continue;
            }
            if (game.MaxGreen > maxGreen)
            {
                continue;
            }
            if (game.MaxRed > maxRed)
            {
                continue;
            }
            sum += game.Id;
        }
        return sum;
    }

    public override object SolvePartTwo()
    {
        var sum = 0;
        foreach (var game in Input)
        {
            sum += game.MaxBlue * game.MaxGreen * game.MaxRed;
        }
        return sum;
    }
}
