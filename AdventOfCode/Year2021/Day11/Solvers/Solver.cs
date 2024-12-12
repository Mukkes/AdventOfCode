using AdventOfCode.Year2021.Day11.Parsers;
using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.Parsers;
using AdventOfCodeLibrary.Solvers;

namespace AdventOfCode.Year2021.Day11.Solvers;

[Solver]
public class Solver : BaseSolver<int[,]>
{
    public override object? AnswerPartOne => 1719;

    public override object? AnswerPartTwo => 232;

    protected override IInputParser<int[,]> InputParser => new Parser();

    public override object SolvePartOne()
    {
        var result = 0;
        var octopuses = (int[,])ParsedInput.Clone();
        for (int steps = 0; steps < 100; steps++)
        {
            IncrementOctopuses(octopuses);
            for (int i = 0; i < ParsedInput.Length; i++)
            {
                IncrementAdjacentOctopusesIfFlashing(octopuses, i / 10, i % 10);
            }
            result += CountFlasingOctopuses(octopuses);
        }
        return result;
    }

    public override object SolvePartTwo()
    {
        var steps = 1;
        var octopuses = (int[,])ParsedInput.Clone();
        while (true)
        {
            IncrementOctopuses(octopuses);
            for (int i = 0; i < ParsedInput.Length; i++)
            {
                IncrementAdjacentOctopusesIfFlashing(octopuses, i / 10, i % 10);
            }
            if (CountFlasingOctopuses(octopuses) == 100)
            {
                return steps;
            }
            steps++;
        }
    }

    private void IncrementOctopuses(int[,] octopuses)
    {
        for (int i = 0; i < ParsedInput.Length; i++)
        {
            octopuses[i / 10, i % 10]++;
        }
    }

    private void IncrementAdjacentOctopusesIfFlashing(int[,] octopuses, int x, int y)
    {
        if (!DoesOctopusExist(x, y))
        {
            return;
        }
        if (octopuses[x, y] > 9 && octopuses[x, y] != 0)
        {
            octopuses[x, y] = 0;
            IncrementAdjacentOctopuses(octopuses, x, y);
        }
    }

    private void IncrementAdjacentOctopuses(int[,] octopuses, int x, int y)
    {
        foreach (var octopus in GetAdjacentOctopuses(x, y))
        {
            if (DoesOctopusExist(octopus.x, octopus.y) && octopuses[octopus.x, octopus.y] != 0)
            {
                octopuses[octopus.x, octopus.y]++;
                IncrementAdjacentOctopusesIfFlashing(octopuses, octopus.x, octopus.y);
            }
        }
    }

    private List<(int x, int y)> GetAdjacentOctopuses(int x, int y)
    {
        return new List<(int x, int y)>
        {
            (x - 1, y - 1),
            (x - 1, y),
            (x - 1, y + 1),
            (x, y - 1),
            (x, y + 1),
            (x + 1, y - 1),
            (x + 1, y),
            (x + 1, y + 1),
        };
    }

    private int CountFlasingOctopuses(int[,] octopuses)
    {
        var result = 0;
        for (int i = 0; i < octopuses.Length; i++)
        {
            if (octopuses[i / 10, i % 10] == 0)
            {
                result++;
            }
        }
        return result;
    }

    private bool DoesOctopusExist(int x, int y)
    {
        return !(x < 0 || x >= 10 || y < 0 || y >= 10);
    }
}
