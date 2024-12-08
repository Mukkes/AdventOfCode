using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.Models;
using AdventOfCodeLibrary.Parsers;
using AdventOfCodeLibrary.Solvers;
using AdventOfCodeLibrary.Util;

namespace AdventOfCode.Year2024.Day06.Solvers;

[Solver]
public class Solver : BaseSolver<Grid<char>>
{
    public override int Year => 2024;

    public override int Day => 6;

    public override object? AnswerPartOne => 4789;

    public override object? AnswerPartTwo => 1304;

    protected override IInputParser<Grid<char>> InputParser => new GridParser();

    public HashSet<Point2D> PassedPositions = new HashSet<Point2D>();
    private HashSet<(Point2D, Direction)> _passedPositionsWithDirection = new HashSet<(Point2D, Direction)>();
    public HashSet<Point2D> NewObstructions = new HashSet<Point2D>();
    public HashSet<Point2D> OldObstructions = new HashSet<Point2D>();

    public override object SolvePartOne()
    {
        if (PassedPositions.Count == 0)
        {
            ProcessGrid();
        }
        return PassedPositions.Count;
    }

    public override object SolvePartTwo()
    {
        if (NewObstructions.Count == 0)
        {
            ProcessGrid();
        }
        return NewObstructions.Count();
    }

    private void ProcessGrid()
    {
        OldObstructions = new HashSet<Point2D>(ParsedInput.Where(x => x.Value == '#').Select(x => x.Key));

        var startPoint = ParsedInput.First(x => x.Value.Equals('^')).Key;
        var direction = Direction.North;
        var currentPosition = new KeyValuePair<Point2D, char>(startPoint, '.');
        while (true)
        {
            var nextPosition = ParsedInput.GetAdjacentOrDefault(currentPosition.Key, direction);
            if (nextPosition.Value == '#')
            {
                direction = GetNextDirection(direction);
                continue;
            }
            PassedPositions.Add(currentPosition.Key);
            _passedPositionsWithDirection.Add((currentPosition.Key, direction));
            if (nextPosition.Value == default)
            {
                break;
            }
            if (!PassedPositions.Contains(nextPosition.Key))
            {
                ProcessPartTwo(nextPosition.Key, direction, currentPosition.Key);
            }
            currentPosition = nextPosition;
        }
    }

    private Direction GetNextDirection(Direction direction)
    {
        return 
            DirectionUtil.GetBasicDirectionsClockWise()
            .GetNextOrFirst(direction);
    }

    private void ProcessPartTwo(Point2D obstruction, Direction direction, Point2D currentPoint)
    {
        var passedPositions = new HashSet<(Point2D, Direction)>();
        var currentPosition = new KeyValuePair<Point2D, char>(currentPoint, '.');
        while (true)
        {
            if (passedPositions.Contains((currentPosition.Key, direction)))
            {
                NewObstructions.Add(obstruction);
                break;
            }
            var nextPosition = ParsedInput.GetAdjacentOrDefault(currentPosition.Key, direction);
            passedPositions.Add((currentPosition.Key, direction));
            if (nextPosition.Value == '#')
            {
                direction = GetNextDirection(direction);
                continue;
            }
            if (nextPosition.Key == obstruction)
            {
                direction = GetNextDirection(direction);
                continue;
            }
            if (nextPosition.Value == default)
            {
                break;
            }
            currentPosition = nextPosition;
        }
    }
}
