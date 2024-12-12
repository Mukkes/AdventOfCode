using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.Models;
using AdventOfCodeLibrary.Parsers;
using AdventOfCodeLibrary.Solvers;

namespace AdventOfCode.Year2023.Day14.Solvers;

[Solver]
public class Solver : BaseSolver<string[]>
{
    public override object? AnswerPartOne => 108792L;

    public override object? AnswerPartTwo => 99118L;

    protected override IInputParser<string[]> InputParser => new StringArrayParser();

    public override object SolvePartOne()
    {
        var map = CreateMap();
        SlideNorth(map);
        return TotalLoad(map);
    }

    public override object SolvePartTwo()
    {
        var map = CreateMap();
        for (var i = 1; i <= 1000; i++)
        {
            SlideNorth(map);
            SlideWest(map);
            SlideSouth(map);
            SlideEast(map);

            Console.WriteLine(i + ": " + TotalLoad(map));
            // met de gegeven input krijg je na een paar honderd cycles om de 72 cycles weer dezelfde reeks.
            // Hiermee is uit te rekenen wat het antwoord moet zijn. Nog geen zin gehad om hier is voor te bedenken :)
        }
        return 0;
    }

    private Map2D<char> CreateMap()
    {
        var map = new Map2D<char>();
        foreach (var line in ParsedInput)
        {
            map.AddRow(line.ToCharArray());
        }
        return map;
    }

    private long TotalLoad(Map2D<char> map)
    {
        var sum = 0L;
        for (var x = 0; x < map.GetRowCount(); x++)
        {
            for (var y = 0; y < map.GetColumnCount(); y++)
            {
                if (map.GetCoord(x, y) == 'O')
                {
                    sum += map.GetRowCount() - x;
                }
            }
        }
        return sum;
    }

    private Map2D<char> RotateMap(Map2D<char> map)
    {
        var newMap = new Map2D<char>();
        foreach (var column in map.GetColumns())
        {
            newMap.AddRow(column.ToArray());
        }
        return newMap;
    }

    private void SlideNorth(Map2D<char> map)
    {
        var go = true;
        while (go)
        {
            go = false;
            for (var x = 1; x < map.GetRowCount(); x++)
            {
                for (var y = 0; y < map.GetColumnCount(); y++)
                {
                    if (map.GetCoord(x, y) == 'O' &&
                        map.GetCoord(x - 1, y) == '.')
                    {
                        map.SetCoord(x, y, '.');
                        map.SetCoord(x - 1, y, 'O');
                        go = true;
                    }
                }
            }
        }
    }

    private void SlideSouth(Map2D<char> map)
    {
        var go = true;
        while (go)
        {
            go = false;
            for (var x = map.GetRowCount() - 1; x > 0; x--)
            {
                for (var y = 0; y < map.GetColumnCount(); y++)
                {
                    if (map.GetCoord(x - 1, y) == 'O' &&
                        map.GetCoord(x, y) == '.')
                    {
                        map.SetCoord(x - 1, y, '.');
                        map.SetCoord(x, y, 'O');
                        go = true;
                    }
                }
            }
        }
    }

    private void SlideWest(Map2D<char> map)
    {
        var go = true;
        while (go)
        {
            go = false;
            for (var y = 1; y < map.GetColumnCount(); y++)
            {
                for (var x = 0; x < map.GetRowCount(); x++)
                {
                    if (map.GetCoord(x, y) == 'O' &&
                        map.GetCoord(x, y - 1) == '.')
                    {
                        map.SetCoord(x, y, '.');
                        map.SetCoord(x, y - 1, 'O');
                        go = true;
                    }
                }
            }
        }
    }

    private void SlideEast(Map2D<char> map)
    {
        var go = true;
        while (go)
        {
            go = false;
            for (var y = map.GetColumnCount() - 1; y > 0; y--)
            {
                for (var x = 0; x < map.GetRowCount(); x++)
                {
                    if (map.GetCoord(x, y - 1) == 'O' &&
                        map.GetCoord(x, y) == '.')
                    {
                        map.SetCoord(x, y - 1, '.');
                        map.SetCoord(x, y, 'O');
                        go = true;
                    }
                }
            }
        }
    }

    private void PrintMap(Map2D<char> map)
    {
        for (var x = 0; x < map.GetRowCount(); x++)
        {
            for (var y = 0; y < map.GetColumnCount(); y++)
            {
                Console.Write(map.GetCoord(x, y));
            }
            Console.WriteLine();
        }
    }
}
