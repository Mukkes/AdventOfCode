using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.Models;
using AdventOfCodeLibrary.Parsers;
using AdventOfCodeLibrary.Solvers;

namespace AdventOfCode.Year2024.Day06.Solvers;

[Solver]
public class Solver : BaseSolver<Grid<char>>
{
    public override int Year => 2024;

    public override int Day => 6;

    //public override object? AnswerPartOne => ;

    //public override object? AnswerPartTwo => ;

    protected override IInputParser<Grid<char>> InputParser => new GridParser();

    private List<Direction> _directions = new List<Direction>()
    {
        Direction.North,
        Direction.East,
        Direction.South,
        Direction.West
    };

    public override object SolvePartOne()
    {
        var passedPositions = new HashSet<Point2D>();
        var startPoint = ParsedInput.FindValue('^');
        var direction = Direction.North;
        var currentPosition = new KeyValuePair<Point2D, char>(startPoint, '.');
        while (true)
        {
            var nextPosition = ParsedInput.GetAdjacent(currentPosition.Key, direction);
            if (nextPosition.Value == '#')
            {
                direction = GetNextDirection(direction);
                continue;
            }
            passedPositions.Add(currentPosition.Key);
            if (nextPosition.Value == default)
            {
                break;
            }
            currentPosition = nextPosition;
        }
        return passedPositions.Count;
    }

    public override object SolvePartTwo()
    {
        return 0;
    }

    private Direction GetNextDirection(Direction direction)
    {
        var index = _directions.IndexOf(direction);
        if (index + 1 < _directions.Count)
        {
            return _directions[index + 1];
        }
        return _directions.First();
    }
}
