using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.ExtensionClasses;
using AdventOfCodeLibrary.Models;
using AdventOfCodeLibrary.Solvers;

namespace AdventOfCode.Year2023.Day13.Solvers;

[Solver]
public class Solver : StringArraySolver
{
    public override int Year => 2023;

    public override int Day => 13;

    public override object? AnswerPartOne => 30518L;

    public override object? AnswerPartTwo => null;

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
        return 0;
    }

    private List<Map2D<char>> GetMaps()
    {
        var maps = new List<Map2D<char>>();
        var map = new Map2D<char>();
        maps.Add(map);
        foreach (var line in Input)
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
}
