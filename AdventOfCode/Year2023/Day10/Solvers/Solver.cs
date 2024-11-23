using AdventOfCode.Year2023.Day10.Models;
using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.Models;
using AdventOfCodeLibrary.Parsers;
using AdventOfCodeLibrary.Solvers;

namespace AdventOfCode.Year2023.Day10.Solvers;

[Solver]
public class Solver : BaseSolver<string[]>
{
    public override int Year => 2023;

    public override int Day => 10;

    public override object? AnswerPartOne => 6773;

    public override object? AnswerPartTwo => null;

    protected override IInputParser<string[]> InputParser => new StringArrayParser();

    private LinkedList<Pipe> _pipes = new LinkedList<Pipe>();

    public override object SolvePartOne()
    {
        var startPipe = GeneratePipeSystem();
        return startPipe.Length() / 2;
    }

    public override object SolvePartTwo()
    {
        var startPipe = GeneratePipeSystem();
        var points = GetAllPipePoints(startPipe);
        var map = new char[ParsedInput.Length][];
        for (var x = 0; x < ParsedInput.Length; x++)
        {
            map[x] = new char[ParsedInput[x].Length];
            for (var y = 0; y < ParsedInput[x].Length; y++)
            {
                if (points.Contains(new Point2DOld(x, y)))
                {
                    //map[x][y] = ParsedInput[x][y];
                    map[x][y] = ' ';
                }
                else
                {
                    map[x][y] = '.';
                }
                Console.Write(map[x][y]);
            }
            Console.WriteLine();
        }
        return 0;
    }

    private Pipe GeneratePipeSystem()
    {
        var startPipe = FindS();
        var pipe = FirstStep(startPipe);
        while (true)
        {
            var point = pipe.GetNext();
            var nextChar = GetCharFromInput(point);
            if (nextChar == 'S')
            {
                startPipe.Previous = pipe;
                break;
            }
            pipe = new Pipe(point, nextChar, pipe);
        }
        return startPipe;
    }

    private Pipe? FindS()
    {
        for (var x = 0; x < ParsedInput.Length; x++)
        {
            for (var y = 0; y < ParsedInput[x].Length; y++)
            {
                if (ParsedInput[x][y] == 'S')
                {
                    return new Pipe(x, y, 'S');
                }
            }
        }
        return null;
    }

    private Pipe? FirstStep(Pipe currentPipe)
    {
        var northPoint = new Point2DOld(currentPipe.X - 1, currentPipe.Y);
        var northChar = GetCharFromInput(northPoint);
        if (northChar == '|' || northChar == '7' || northChar == 'F')
        {
            return new Pipe(northPoint, northChar, currentPipe);
        }

        var southPoint = new Point2DOld(currentPipe.X + 1, currentPipe.Y);
        var southChar = GetCharFromInput(southPoint);
        if (southChar == '|' || southChar == 'L' || southChar == 'J')
        {
            return new Pipe(southPoint, southChar, currentPipe);
        }

        var westPoint = new Point2DOld(currentPipe.X, currentPipe.Y - 1);
        var westChar = GetCharFromInput(westPoint);
        if (westChar == '-' || westChar == 'L' || westChar == 'F')
        {
            return new Pipe(westPoint, westChar, currentPipe);
        }

        var eastPoint = new Point2DOld(currentPipe.X, currentPipe.Y + 1);
        var eastChar = GetCharFromInput(eastPoint);
        if (eastChar == '-' || eastChar == 'J' || eastChar == '7')
        {
            return new Pipe(eastPoint, eastChar, currentPipe);
        }

        return null;
    }

    private char GetCharFromInput(Point2DOld point2D)
    {
        try
        {
            return ParsedInput[(int)point2D.X][(int)point2D.Y];
        }
        catch { }
        return '.';
    }

    private List<Point2DOld> GetAllPipePoints(Pipe startPipe)
    {
        var points = new List<Point2DOld>();
        do
        {
            points.Add(startPipe);
            startPipe = startPipe.Previous;
        } while (startPipe.Symbol != 'S');
        return points;
    }

    private void PrintPath(Pipe startPipe)
    {
        var points = GetAllPipePoints(startPipe);
        for (var x = 0; x < ParsedInput.Length; x++)
        {
            for (var y = 0; y < ParsedInput[x].Length; y++)
            {
                if (points.Contains(new Point2DOld(x, y)))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ResetColor();
                }
                Console.Write(ParsedInput[x][y]);
            }
            Console.WriteLine();
        }
    }
}
