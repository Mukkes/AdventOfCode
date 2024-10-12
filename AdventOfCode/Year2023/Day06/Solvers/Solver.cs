using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.Solvers;

namespace AdventOfCode.Year2023.Day06.Solvers;

[Solver]
public class Solver : StringArraySolver
{
    public override int Year => 2023;

    public override int Day => 6;

    public override object? AnswerPartOne => 1084752;

    public override object? AnswerPartTwo => 28228952L;

    public override object SolvePartOne()
    {
        var time = Array.ConvertAll(ParsedInput[0][11..].Split(' ', StringSplitOptions.RemoveEmptyEntries), int.Parse);
        var distance = Array.ConvertAll(ParsedInput[1][11..].Split(' ', StringSplitOptions.RemoveEmptyEntries), int.Parse);
        var beatAmount = new int[time.Length];

        for (var i = 0; i < time.Length; i++)
        {
            for (var j = 0; j <= time[i]; j++)
            {
                if (j * (time[i] - j) > distance[i])
                {
                    beatAmount[i]++;
                }
            }
        }
        var sum = beatAmount[0];
        for (var i = 1; i < beatAmount.Length; i++)
        {
            sum *= beatAmount[i];
        }
        return sum;
    }

    public override object SolvePartTwo()
    {
        var time = new long[] { long.Parse(ParsedInput[0][11..].Replace(" ", "")) };
        var distance = new long[] { long.Parse(ParsedInput[1][11..].Replace(" ", "")) };
        var beatAmount = new long[time.Length];

        for (var i = 0L; i < time.Length; i++)
        {
            for (var j = 0L; j <= time[i]; j++)
            {
                if (j * (time[i] - j) > distance[i])
                {
                    beatAmount[i]++;
                }
            }
        }
        return beatAmount[0];
    }
}
