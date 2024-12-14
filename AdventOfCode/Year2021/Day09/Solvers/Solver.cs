using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.Models;
using AdventOfCodeLibrary.Parsers;
using AdventOfCodeLibrary.Solvers;

namespace AdventOfCode.Year2021.Day09.Solvers;

[Solver]
public class Solver : BaseSolver<string[]>
{
    public override object? AnswerPartOne => 564;

    public override object? AnswerPartTwo => 1038240;

    protected override IInputParser<string[]> InputParser => new StringArrayParser();

    public override object SolvePartOne()
    {
        var result = 0;
        for (int x = 0; x < ParsedInput.Length; x++)
        {
            for (int y = 0; y < ParsedInput[0].Length; y++)
            {
                if (IsLowest(x, y))
                {
                    result += int.Parse(ParsedInput[x][y].ToString()) + 1;
                }
            }
        }
        return result;
    }

    public override object SolvePartTwo()
    {
        var basinSizes = new List<int>();
        for (int x = 0; x < ParsedInput.Length; x++)
        {
            for (int y = 0; y < ParsedInput[0].Length; y++)
            {
                if (IsLowest(x, y))
                {
                    basinSizes.Add(BasinSize(new List<Point2D>(), x, y));
                }
            }
        }
        var s1 = basinSizes.Max();
        basinSizes.Remove(s1);
        var s2 = basinSizes.Max();
        basinSizes.Remove(s2);
        var s3 = basinSizes.Max();
        return s1 * s2 * s3;
    }

    private bool IsLowest(int x, int y)
    {
        var value = ParsedInput[x][y];
        // Up
        if (x - 1 >= 0 && value >= ParsedInput[x - 1][y])
        {
            return false;
        }
        // Down
        if (x + 1 < ParsedInput.Length && value >= ParsedInput[x + 1][y])
        {
            return false;
        }
        // Left
        if (y - 1 >= 0 && value >= ParsedInput[x][y - 1])
        {
            return false;
        }
        // Right
        if (y + 1 < ParsedInput[0].Length && value >= ParsedInput[x][y + 1])
        {
            return false;
        }
        return true;
    }

    private int BasinSize(List<Point2D> Points, int x, int y)
    {
        if (Points.Contains(new Point2D(x, y)))
        {
            return 0;
        }
        Points.Add(new Point2D(x, y));
        int size = 1;
        // Up
        if (x - 1 >= 0 && int.Parse(ParsedInput[x - 1][y].ToString()) < 9)
        {
            size += BasinSize(Points, x - 1, y);
        }
        // Down
        if (x + 1 < ParsedInput.Length && int.Parse(ParsedInput[x + 1][y].ToString()) < 9)
        {
            size += BasinSize(Points, x + 1, y);
        }
        // Left
        if (y - 1 >= 0 && int.Parse(ParsedInput[x][y - 1].ToString()) < 9)
        {
            size += BasinSize(Points, x, y - 1);
        }
        // Right
        if (y + 1 < ParsedInput[0].Length && int.Parse(ParsedInput[x][y + 1].ToString()) < 9)
        {
            size += BasinSize(Points, x, y + 1);
        }
        return size;
    }
}
