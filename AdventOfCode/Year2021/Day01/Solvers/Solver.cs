using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.Solvers;

namespace AdventOfCode.Year2021.Day01.Solvers;

[Solver]
public class Solver : IntArraySolver
{
    public override int Year => 2021;

    public override int Day => 1;

    public override object? AnswerPartOne => 1655;

    public override object? AnswerPartTwo => 1683;

    public override object SolvePartOne()
    {
        var largerCount = 0;
        for (var i = 1; i < Input.Length; i++)
        {
            if (Input[i] > Input[i - 1])
            {
                largerCount++;
            }
        }
        return largerCount;
    }

    public override object SolvePartTwo()
    {
        var largerCount = 0;
        for (var i = 3; i < Input.Length; i++)
        {
            var previousDepth = Input[i - 3] + Input[i - 2] + Input[i - 1];
            var depth = Input[i - 2] + Input[i - 1] + Input[i];
            if (depth > previousDepth)
            {
                largerCount++;
            }
        }
        return largerCount;
    }
}
