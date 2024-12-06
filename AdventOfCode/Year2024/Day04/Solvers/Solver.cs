using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.ExtensionClasses;
using AdventOfCodeLibrary.Models;
using AdventOfCodeLibrary.Parsers;
using AdventOfCodeLibrary.Solvers;

namespace AdventOfCode.Year2024.Day04.Solvers;

[Solver]
public class Solver : BaseSolver<string[]>
{
    public override int Year => 2024;

    public override int Day => 4;

    public override object? AnswerPartOne => 2370;

    public override object? AnswerPartTwo => 1908;

    protected override IInputParser<string[]> InputParser => new StringArrayParser();

    public override object SolvePartOne()
    {
        var sum = 0;
        for (var y = 0; y < ParsedInput.Length; y++)
        {
            for (var x = 0; x < ParsedInput[y].Length; x++)
            {
                if (ParsedInput[y][x] == 'X')
                {
                    var point = new Point2D(x, y);
                    foreach (var direction in EnumExtensions.GetValues<Direction>())
                    {
                        if (GetNextThreeCharacter(point, direction) == "MAS")
                        {
                            sum++;
                        }
                    }
                }
            }
        }
        return sum;
    }

    public override object SolvePartTwo()
    {
        var sum = 0;
        for (var y = 0; y < ParsedInput.Length; y++)
        {
            for (var x = 0; x < ParsedInput[y].Length; x++)
            {
                if (ParsedInput[y][x] == 'A')
                {
                    var point = new Point2D(x, y);
                    if (IsX_MAS(point))
                    {
                        sum++;
                    }
                }
            }
        }
        return sum;
    }

    private bool IsX_MAS(Point2D point)
    {
        var s1 = string.Empty + GetCharFromInput(point.GetAdjacentPoint(Direction.Northwest)) + GetCharFromInput(point.GetAdjacentPoint(Direction.Southeast));
        var s2 = string.Empty + GetCharFromInput(point.GetAdjacentPoint(Direction.Northeast)) + GetCharFromInput(point.GetAdjacentPoint(Direction.Southwest));
        return (s1 == "MS" || s1 == "SM") && (s2 == "MS" || s2 == "SM");
    }

    private string GetNextThreeCharacter(Point2D point, Direction direction)
    {
        var result = string.Empty;
        var nextPoint = point;
        for (var i = 0; i < 3; i++)
        {
            nextPoint = nextPoint.GetAdjacentPoint(direction);
            result += GetCharFromInput(nextPoint);
        }
        return result;
    }

    private char GetCharFromInput(Point2D point)
    {
        try
        {
            return ParsedInput[point.Y][point.X];
        }
        catch { }
        return '.';
    }
}
