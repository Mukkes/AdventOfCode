using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.Models;
using AdventOfCodeLibrary.Parsers;
using AdventOfCodeLibrary.Solvers;

namespace AdventOfCode.Year2024.Day08.Solvers;

[Solver]
public class Solver : BaseSolver<Grid<char>>
{
    public override int Year => 2024;

    public override int Day => 8;

    //public override object? AnswerPartOne => ;

    //public override object? AnswerPartTwo => ;

    protected override IInputParser<Grid<char>> InputParser => new GridParser();

    private Dictionary<char, List<Point2D>> _antennas = new Dictionary<char, List<Point2D>>();

    public override object SolvePartOne()
    {
        if (_antennas.Count == 0)
        {
            FindAntennas();
        }
        return GetAntinodes().Count;
    }

    public override object SolvePartTwo()
    {
        return 0;
    }

    private void FindAntennas()
    {
        foreach (var pair in ParsedInput)
        {
            if (pair.Value == '.')
            {
                continue;
            }
            if (!_antennas.ContainsKey(pair.Value))
            {
                _antennas.Add(pair.Value, new List<Point2D>());
            }
            _antennas[pair.Value].Add(pair.Key);
        }
    }

    private HashSet<Point2D> GetAntinodes()
    {
        var antinodes = new HashSet<Point2D>();
        foreach (var pair in _antennas)
        {
            for (var i = 0; i < pair.Value.Count; i++)
            {
                for (var j = 0; j < pair.Value.Count; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    var vector = pair.Value[i] - pair.Value[j];
                    var antinode = pair.Value[i] + vector;
                    if (ParsedInput.IsInsideGrid(antinode))
                    {
                        antinodes.Add(antinode);
                    }
                }
            }
        }
        return antinodes;

        for (var y = 0; y <= ParsedInput.YUpperBound; y++ )
        {
            for (var x = 0; x <= ParsedInput.XUpperBound; x++)
            {

            }
        }
    }
}
