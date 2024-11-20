using AdventOfCode.Year2021.Day15.Parsers;
using AdventOfCode.Year2021.Day15.Models;
using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.Parsers;
using AdventOfCodeLibrary.Solvers;

namespace AdventOfCode.Year2021.Day15.Solvers;

[Solver]
public class Solver : BaseSolver<int[,]>
{
    public override int Year => 2021;

    public override int Day => 15;

    public override object? AnswerPartOne => 741L;

    public override object? AnswerPartTwo => 2976L;

    protected override IInputParser<int[,]> InputParser => new Parser();

    public override object SolvePartOne()
    {
        var positions = CreatePositions(ParsedInput);
        SetNeighbors(positions);
        positions[0, 0].FirstCalculateLowestTotalRisk();
        var sqrt = (int)Math.Sqrt(positions.Length) - 1;
        var result = positions[sqrt, sqrt].LowestRisk;
        return result;
    }

    public override object SolvePartTwo()
    {
        var positions = CreatePositionsPartTwo(ParsedInput);
        SetNeighbors(positions);
        positions[0, 0].FirstCalculateLowestTotalRisk();
        var sqrt = (int)Math.Sqrt(positions.Length) - 1;
        var result = positions[sqrt, sqrt].LowestRisk;
        return result;
    }

    private Position[,] CreatePositionsPartTwo(int[,] input)
    {
        var oldPostions = CreatePositions(ParsedInput);
        var sqrt = (int)Math.Sqrt(input.Length);
        var size = sqrt * 5;
        var positions = new Position[size, size];
        for (int x = 0; x < oldPostions.Length; x++)
        {
            positions[x / sqrt, x % sqrt] = oldPostions[x / sqrt, x % sqrt];
        }
        for (int x = 0; x < positions.Length; x++)
        {
            if (positions[x / size, x % size] == null)
            {
                var pX = (x / size) - sqrt;
                var pY = x % size;
                if (pX < 0)
                {
                    pX = x / size;
                    pY = (x % size) - sqrt;
                }
                positions[x / size, x % size] = new Position(positions[pX, pY].RiskLevel + 1, x / size, x % size);
            }
        }
        return positions;
    }

    private Position[,] CreatePositions(int[,] input)
    {
        var sqrt = (int)Math.Sqrt(input.Length);
        var positions = new Position[sqrt, sqrt];
        for (int x = 0; x < input.Length; x++)
        {
            positions[x / sqrt, x % sqrt] = new Position(input[x / sqrt, x % sqrt], x / sqrt, x % sqrt);
        }
        return positions;
    }

    private void SetNeighbors(Position[,] positions)
    {
        var sqrt = (int)Math.Sqrt(positions.Length);
        for (int i = 0; i < positions.Length; i++)
        {
            var x = i / sqrt;
            var y = i % sqrt;
            var position = positions[x, y];
            try
            {
                position.Neighbors.Add(positions[x - 1, y]);
            }
            catch { }
            try
            {
                position.Neighbors.Add(positions[x + 1, y]);
            }
            catch { }
            try
            {
                position.Neighbors.Add(positions[x, y - 1]);
            }
            catch { }
            try
            {
                position.Neighbors.Add(positions[x, y + 1]);
            }
            catch { }
        }
    }
}
