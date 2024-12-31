using AdventOfCode.Year2023.Day10.Models;
using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.Models;
using AdventOfCodeLibrary.Parsers;
using AdventOfCodeLibrary.Solvers;

namespace AdventOfCode.Year2023.Day10.Solvers;

[Solver]
public class Solver : BaseSolver<string[]>
{
    public override object? AnswerPartOne => 6773;

    public override object? AnswerPartTwo => null;

    protected override IInputParser<string[]> InputParser => new StringArrayParser();

    private LinkedList<Pipe> _pipes = new();

    public override object SolvePartOne()
    {
        if (_pipes.Count <= 0)
        {
            GeneratePipeSystem();
        }
        //PrintPath();
        return _pipes.Count / 2;
    }

    public override object SolvePartTwo()
    {
        if (_pipes.Count <= 0)
        {
            GeneratePipeSystem();
        }
        //var points = new HashSet<Point2D>(_pipes.Select(pipe => pipe.Point));
        //var map = new char[ParsedInput.Length][];
        //for (var y = 0; y < ParsedInput.Length; y++)
        //{
        //    map[y] = new char[ParsedInput[y].Length];
        //    for (var x = 0; x < ParsedInput[y].Length; x++)
        //    {
        //        if (points.Contains(new Point2D(x, y)))
        //        {
        //            //map[y][x] = ParsedInput[y][x];
        //            map[y][x] = ' ';
        //        }
        //        else
        //        {
        //            map[y][x] = '.';
        //        }
        //        Console.Write(map[y][x]);
        //    }
        //    Console.WriteLine();
        //}
        return 0;
    }

    private void GeneratePipeSystem()
    {
        var sPoint = FindS();
        var pipe = CreateFirstPipe(sPoint);
        _pipes.AddLast(pipe);
        while (true)
        {
            var point = GetNextPoint(pipe);
            var nextChar = GetCharFromInput(point);
            if (nextChar == 'S')
            {
                break;
            }
            pipe = PipeFactory.GetPipe(nextChar, point, pipe.CardinalDirection);
            _pipes.AddLast(pipe);
        }
    }

    private Point2D FindS()
    {
        for (var y = 0; y < ParsedInput.Length; y++)
        {
            for (var x = 0; x < ParsedInput[y].Length; x++)
            {
                if (ParsedInput[y][x] == 'S')
                {
                    return new Point2D(x, y);
                }
            }
        }
        throw new Exception();
    }

    private Pipe CreateFirstPipe(Point2D sPoint)
    {
        var northPoint = GetNextPoint(sPoint, Direction.North);
        var northChar = GetCharFromInput(northPoint);
        if (northChar == '|' || northChar == '7' || northChar == 'F')
        {
            return new SPipe(sPoint, Direction.North);
        }

        var southPoint = GetNextPoint(sPoint, Direction.South);
        var southChar = GetCharFromInput(southPoint);
        if (southChar == '|' || southChar == 'L' || southChar == 'J')
        {
            return new SPipe(sPoint, Direction.South);
        }

        var westPoint = GetNextPoint(sPoint, Direction.West);
        var westChar = GetCharFromInput(westPoint);
        if (westChar == '-' || westChar == 'L' || westChar == 'F')
        {
            return new SPipe(sPoint, Direction.West);
        }

        var eastPoint = GetNextPoint(sPoint, Direction.East);
        var eastChar = GetCharFromInput(eastPoint);
        if (eastChar == '-' || eastChar == 'J' || eastChar == '7')
        {
            return new SPipe(sPoint, Direction.East);
        }

        throw new Exception();
    }

    private Point2D GetNextPoint(Pipe pipe)
    {
        return GetNextPoint(pipe.Point, pipe.CardinalDirection);
    }

    private Point2D GetNextPoint(Point2D point, Direction cardinalDirection)
    {
        switch (cardinalDirection)
        {
            case Direction.North:
                return new Point2D(point.X, point.Y - 1);
            case Direction.South:
                return new Point2D(point.X, point.Y + 1);
            case Direction.West:
                return new Point2D(point.X - 1, point.Y);
            case Direction.East:
                return new Point2D(point.X + 1, point.Y);
        }
        throw new Exception();
    }

    //private Pipe GeneratePipeSystem()
    //{
    //    var startPipe = FindS();
    //    var pipe = FirstStep(startPipe);
    //    while (true)
    //    {
    //        var point = pipe.GetNext();
    //        var nextChar = GetCharFromInput(point);
    //        if (nextChar == 'S')
    //        {
    //            startPipe.Previous = pipe;
    //            break;
    //        }
    //        pipe = new Pipe(point, nextChar, pipe);
    //    }
    //    return startPipe;
    //}

    private char GetCharFromInput(Point2D point)
    {
        try
        {
            return ParsedInput[(int)point.Y][(int)point.X];
        }
        catch { }
        return '.';
    }

    //private List<Point2DOld> GetAllPipePoints(Pipe startPipe)
    //{
    //    var points = new List<Point2DOld>();
    //    do
    //    {
    //        points.Add(startPipe);
    //        startPipe = startPipe.Previous;
    //    } while (startPipe.Symbol != 'S');
    //    return points;
    //}

    private void PrintPath()
    {
        var points = new HashSet<Point2D>(_pipes.Select(pipe => pipe.Point));
        for (var y = 0; y < ParsedInput.Length; y++)
        {
            for (var x = 0; x < ParsedInput[y].Length; x++)
            {
                if (points.Contains(new Point2D(x, y)))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ResetColor();
                }
                Console.Write(ParsedInput[y][x]);
            }
            Console.WriteLine();
        }
    }
}
