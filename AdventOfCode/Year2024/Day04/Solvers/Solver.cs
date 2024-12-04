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

    //public override object? AnswerPartOne => ;

    //public override object? AnswerPartTwo => ;

    protected override IInputParser<string[]> InputParser => new StringArrayParser();

    public override object SolvePartOne()
    {
        var sum = 0;
        var directions = EnumExtensions.GetValues<Direction>();
        for (var y = 0; y < ParsedInput.Length; y++)
        {
            for (var x = 0; x < ParsedInput[y].Length; x++)
            {
                if (ParsedInput[y][x] == 'X')
                {
                    var point = new Point2D(x, y);
                    foreach (var direction in directions)
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
        return 0;
    }

    private string GetNextThreeCharacter(Point2D point, Direction direction)
    {
        var result = string.Empty;
        var nextPoint = point;
        for (var i = 0; i < 3; i++)
        {
            nextPoint = nextPoint.GetNextPoint(direction);
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
