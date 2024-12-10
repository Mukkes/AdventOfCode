using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.Models;
using AdventOfCodeLibrary.Parsers;
using AdventOfCodeLibrary.Solvers;
using AdventOfCodeLibrary.Util;

namespace AdventOfCode.Year2024.Day10.Solvers;

[Solver]
public class Solver : BaseSolver<Grid<int>>
{
    public override int Year => 2024;

    public override int Day => 10;

    public override object? AnswerPartOne => 512;

    public override object? AnswerPartTwo => 1045;

    protected override IInputParser<Grid<int>> InputParser => new IntGridParser();

    public override object SolvePartOne()
    {
        var sum = 0;
        foreach (var keyValuePair in ParsedInput)
        {
            if (keyValuePair.Value == 0)
            {
                sum += GetTrailheads(keyValuePair).Distinct().Count();
            }
        }
        return sum;
    }

    public override object SolvePartTwo()
    {
        var sum = 0;
        foreach (var keyValuePair in ParsedInput)
        {
            if (keyValuePair.Value == 0)
            {
                sum += GetSumAllTrailheads(keyValuePair);
            }
        }
        return sum;
    }

    private List<Point2D> GetTrailheads(KeyValuePair<Point2D, int> keyValuePair)
    {
        if (keyValuePair.Value == 9)
        {
            return new List<Point2D>()
            {
                keyValuePair.Key
            };
        }
        var points = new List<Point2D>();
        var neighbors = ParsedInput.GetValidNeighbors(keyValuePair.Key);
        foreach (var neighbor in neighbors)
        {
            if (neighbor.Value == keyValuePair.Value + 1)
            {
                points.AddRange(GetTrailheads(neighbor));
            }
        }
        return points;
    }

    private int GetSumAllTrailheads(KeyValuePair<Point2D, int> keyValuePair)
    {
        if (keyValuePair.Value == 9)
        {
            return 1;
        }
        var sum = 0;
        var neighbors = ParsedInput.GetValidNeighbors(keyValuePair.Key);
        foreach (var neighbor in neighbors)
        {
            if (neighbor.Value == keyValuePair.Value + 1)
            {
                sum += GetSumAllTrailheads(neighbor);
            }
        }
        return sum;
    }
}
