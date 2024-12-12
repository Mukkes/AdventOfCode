using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.Models;
using AdventOfCodeLibrary.Parsers;
using AdventOfCodeLibrary.Solvers;

namespace AdventOfCode.Year2024.Day08.Solvers;

[Solver]
public class Solver : BaseSolver<Grid<char>>
{
    public override object? AnswerPartOne => 354;

    public override object? AnswerPartTwo => 1263;

    protected override IInputParser<Grid<char>> InputParser => new CharGridParser();

    private Dictionary<char, List<Point2D>> _antennas = new Dictionary<char, List<Point2D>>();
    private HashSet<Point2D> _antinodesPartOne = new HashSet<Point2D>();
    private HashSet<Point2D> _antinodesPartTwo = new HashSet<Point2D>();

    public override object SolvePartOne()
    {
        if (_antennas.Count == 0)
        {
            FindAntennas();
            FindAntinodes();
        }
        return _antinodesPartOne.Count;
    }

    public override object SolvePartTwo()
    {
        if (_antennas.Count == 0)
        {
            FindAntennas();
            FindAntinodes();
        }
        return _antinodesPartTwo.Count;
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

    private void FindAntinodes()
    {
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
                        _antinodesPartOne.Add(antinode);
                    }
                    _antinodesPartTwo.Add(pair.Value[i]);
                    _antinodesPartTwo.Add(pair.Value[j]);
                    while (ParsedInput.IsInsideGrid(antinode))
                    {
                        _antinodesPartTwo.Add(antinode);
                        antinode += vector;
                    }
                }
            }
        }
    }
}
