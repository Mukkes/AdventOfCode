using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.Models;
using AdventOfCodeLibrary.Parsers;
using AdventOfCodeLibrary.Solvers;
using System.Collections.Generic;

namespace AdventOfCode.Year2023.Day11.Solvers;

[Solver]
public class Solver : BaseSolver<string[]>
{
    public override int Year => 2023;

    public override int Day => 11;

    public override object? AnswerPartOne => 9605127L;

    public override object? AnswerPartTwo => 458191688761L;

    protected override IInputParser<string[]> InputParser => new StringArrayParser();

    public override object SolvePartOne()
    {
        var galaxies = GetGalaxies();
        Expand(galaxies, 1);
        var sum = 0L;
        for (int i = 1; i <= galaxies.Count; i++)
        {
            for (int j = i + 1; j <= galaxies.Count; j++)
            {
                var distance = galaxies[i - 1].GetDistance(galaxies[j - 1]);
                //Console.WriteLine("Between galaxy " + i + " and galaxy " + j + ": " + distance);
                sum += distance;
            }
        }
        return sum;
    }

    public override object SolvePartTwo()
    {
        var galaxies = GetGalaxies();
        Expand(galaxies, 999999);
        var sum = 0L;
        for (int i = 1; i <= galaxies.Count; i++)
        {
            for (int j = i + 1; j <= galaxies.Count; j++)
            {
                var distance = galaxies[i - 1].GetDistance(galaxies[j - 1]);
                //Console.WriteLine("Between galaxy " + i + " and galaxy " + j + ": " + distance);
                sum += distance;
            }
        }
        return sum;
    }

    private List<Point2D> GetGalaxies()
    {
        var galaxies = new List<Point2D>();
        for (var x = 0; x < ParsedInput.Length; x++)
        {
            for (var y = 0; y < ParsedInput[x].Length; y++)
            {
                if (ParsedInput[x][y] == '#')
                {
                    galaxies.Add(new Point2D(x, y));
                }
            }
        }
        return galaxies;
    }

    private void Expand(List<Point2D> galaxies, long expandingDistance)
    {
        ExpandX(galaxies, expandingDistance);
        ExpandY(galaxies, expandingDistance);
    }

    private void ExpandX(List<Point2D> galaxies, long expandingDistance)
    {
        var totalExpandingDistance = 0L;
        for (var x = 0; x < ParsedInput.Length; x++)
        {
            if (!ParsedInput[x].Contains('#'))
            {
                foreach (var galaxy in galaxies)
                {
                    if (galaxy.X > (x + totalExpandingDistance))
                    {
                        galaxy.X += expandingDistance;
                    }
                }
                totalExpandingDistance += expandingDistance;
            }
        }
    }

    private void ExpandY(List<Point2D> galaxies, long expandingDistance)
    {
        var totalExpandingDistance = 0L;
        for (var y = 0; y < ParsedInput[0].Length; y++)
        {
            var noGalaxies = true;
            for (var x = 0; x < ParsedInput.Length; x++)
            {
                if (ParsedInput[x][y] == '#')
                {
                    noGalaxies = false;
                }
            }
            if (!noGalaxies)
            {
                continue;
            }
            foreach (var galaxy in galaxies)
            {
                if (galaxy.Y > (y + totalExpandingDistance))
                {
                    galaxy.Y += expandingDistance;
                }
            }
            totalExpandingDistance += expandingDistance;
        }
    }
}
