using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.Models;
using AdventOfCodeLibrary.Parsers;
using AdventOfCodeLibrary.Solvers;
using AdventOfCodeLibrary.Util;

namespace AdventOfCode.Year2023.Day11.Solvers;

[Solver]
public class Solver : BaseSolver<string[]>
{
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
                for (var galaxyIndex = 0; galaxyIndex < galaxies.Count; galaxyIndex++)
                {
                    if (galaxies[galaxyIndex].X > (x + totalExpandingDistance))
                    {
                        galaxies[galaxyIndex] = new Point2D(galaxies[galaxyIndex].X + (int)expandingDistance, galaxies[galaxyIndex].Y);
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
            for (var galaxyIndex = 0; galaxyIndex < galaxies.Count; galaxyIndex++)
            {
                if (galaxies[galaxyIndex].Y > (y + totalExpandingDistance))
                {
                    galaxies[galaxyIndex] = new Point2D(galaxies[galaxyIndex].X, galaxies[galaxyIndex].Y + (int)expandingDistance);
                }
            }
            totalExpandingDistance += expandingDistance;
        }
    }
}
