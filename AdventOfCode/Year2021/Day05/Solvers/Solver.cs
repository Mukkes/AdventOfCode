using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.Parsers;
using AdventOfCodeLibrary.Solvers;
using System.Drawing;

namespace AdventOfCode.Year2021.Day05.Solvers;

[Solver]
public class Solver : BaseSolver<string[]>
{
    public override object? AnswerPartOne => 6856;

    public override object? AnswerPartTwo => 20666;

    protected override IInputParser<string[]> InputParser => new StringArrayParser();

    private Dictionary<Point, int> diagram;

    public override object SolvePartOne()
    {
        diagram = new Dictionary<Point, int>();
        foreach (var line in ParsedInput)
        {
            var coordinates = line.Split(new string[] { ",", " -> " }, StringSplitOptions.None).Select(int.Parse).ToArray();
            IncrementLine(coordinates);
        }
        var result = 0;
        foreach (var point in diagram)
        {
            if (point.Value > 1)
            {
                result++;
            }
        }
        return result;
    }

    public override object SolvePartTwo()
    {
        diagram = new Dictionary<Point, int>();
        foreach (var line in ParsedInput)
        {
            var coordinates = line.Split(new string[] { ",", " -> " }, StringSplitOptions.None).Select(int.Parse).ToArray();
            IncrementLine(coordinates);
            IncrementDiagonalLine(coordinates);
        }
        var result = 0;
        foreach (var point in diagram)
        {
            if (point.Value > 1)
            {
                result++;
            }
        }
        return result;
    }

    private void IncrementLine(int[] coordinates)
    {
        if (coordinates[0] == coordinates[2])
        {
            if (coordinates[1] > coordinates[3])
            {
                IncrementVerticalLine(coordinates[0], coordinates[3], coordinates[1]);
            }
            else
            {
                IncrementVerticalLine(coordinates[0], coordinates[1], coordinates[3]);
            }
        }
        else if (coordinates[1] == coordinates[3])
        {
            if (coordinates[0] > coordinates[2])
            {
                IncrementHorizontalLine(coordinates[1], coordinates[2], coordinates[0]);
            }
            else
            {
                IncrementHorizontalLine(coordinates[1], coordinates[0], coordinates[2]);
            }
        }
    }

    private void IncrementDiagonalLine(int[] coordinates)
    {
        if (coordinates[0] != coordinates[2] && coordinates[1] != coordinates[3])
        {
            IncrementDiagonalLine(coordinates[0], coordinates[1], coordinates[2], coordinates[3]);
        }
    }

    private void IncrementVerticalLine(int x, int y1, int y2)
    {
        for (var y = y1; y <= y2; y++)
        {
            IncrementPointInDiagram(new Point(x, y));
        }
    }

    private void IncrementHorizontalLine(int y, int x1, int x2)
    {
        for (var x = x1; x <= x2; x++)
        {
            IncrementPointInDiagram(new Point(x, y));
        }
    }

    private void IncrementDiagonalLine(int x1, int y1, int x2, int y2)
    {
        var incrementX = x1 > x2 ? -1 : 1;
        var incrementY = y1 > y2 ? -1 : 1;
        var x = x1;
        var y = y1;
        while (x != (x2 + incrementX))
        {
            IncrementPointInDiagram(new Point(x, y));
            x += incrementX;
            y += incrementY;
        }
    }

    private void IncrementPointInDiagram(Point point)
    {
        if (diagram.TryGetValue(point, out int value))
        {
            diagram.Remove(point);
            diagram.Add(point, ++value);
        }
        else
        {
            diagram.Add(point, 1);
        }
    }
}
