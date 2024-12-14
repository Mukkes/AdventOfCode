using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.ExtensionClasses;
using AdventOfCodeLibrary.Models;
using AdventOfCodeLibrary.Parsers;
using AdventOfCodeLibrary.Solvers;

namespace AdventOfCode.Year2023.Day13.Solvers;

[Solver]
public class Solver : BaseSolver<string[]>
{
    public override object? AnswerPartOne => 30518L;

    public override object? AnswerPartTwo => null;

    protected override IInputParser<string[]> InputParser => new StringArrayParser();

    public override object SolvePartOne()
    {
        var sum = 0L;
        var maps = GetMaps();
        foreach (var map in maps)
        {
            if (HasReflection(map.GetColumns(), out (int, int) reflection))
            {
                sum += reflection.Item2;
            }
            else if (HasReflection(map.GetRows(), out (int, int) reflection2))
            {
                sum += reflection2.Item2 * 100;
            }
        }
        return sum;
    }

    public override object SolvePartTwo()
    {
        var sum = 0L;
        var maps = GetMaps();
        foreach (var map in maps)
        {
            sum += FindReflectionWithSmudge(map);
        }
        return sum;
    }

    private long FindReflectionWithSmudge(Map2D<char> map)
    {
        var oldColumnReflection = default((int, int)?);
        if (HasReflection(map.GetColumns(), out (int, int) oldReflection))
        {
            oldColumnReflection = oldReflection;
        }
        var oldRowReflection = default((int, int)?);
        if (HasReflection(map.GetRows(), out (int, int) oldReflection2))
        {
            oldRowReflection = oldReflection2;
        }
        for (var x = 0; x < map.GetRowCount(); x++)
        {
            for (var y = 0; y < map.GetColumnCount(); y++)
            {
                map.SetCoord(x, y, ToggleSymbol(map.GetCoord(x, y)));
                if (HasReflection(map.GetColumns(), out (int, int) reflection) && reflection != oldColumnReflection)
                {
                    return reflection.Item2;
                }
                else if (HasReflection(map.GetRows(), out (int, int) reflection2) && oldRowReflection != reflection2)
                {
                    return reflection2.Item2 * 100;
                }
                map.SetCoord(x, y, ToggleSymbol(map.GetCoord(x, y)));
            }
        }
        if (HasReflection(map.GetColumns(), out (int, int) oldReflectiont))
        {
            return oldReflectiont.Item2;
        }
        if (HasReflection(map.GetRows(), out (int, int) oldReflection2t))
        {
            return oldReflection2t.Item2 * 100;
        }
        return 0;
    }

    private List<Map2D<char>> GetMaps()
    {
        var maps = new List<Map2D<char>>();
        var map = new Map2D<char>();
        maps.Add(map);
        foreach (var line in ParsedInput)
        {
            if (line.IsNullOrEmpty())
            {
                map = new Map2D<char>();
                maps.Add(map);
            }
            else
            {
                map.AddRow(line.ToCharArray());
            }
        }
        return maps;
    }

    private bool HasReflection(List<List<char>> map, out (int, int) reflection)
    {
        for (var i = 1; i < map.Count; i++)
        {
            if (map[i - 1].SequenceEqual(map[i]) &&
                IsMirrored(map, i - 1, i))
            {
                reflection = (i - 1, i);
                return true;
            }
        }
        reflection = default;
        return false;
    }

    private bool IsMirrored(List<List<char>> map, int column1, int column2)
    {
        for (var i = 1; column1 - i >= 0 && column2 + i < map.Count; i++)
        {
            if (!map[column1 - i].SequenceEqual(map[column2 + i]))
            {
                return false;
            }
        }
        return true;
    }

    private char ToggleSymbol(char c)
    {
        if (c == '#')
        {
            return '.';
        }
        return '#';
    }
}
