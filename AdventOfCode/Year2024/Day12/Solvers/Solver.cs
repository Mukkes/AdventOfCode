using AdventOfCode.Year2024.Day12.Models;
using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.Models;
using AdventOfCodeLibrary.Parsers;
using AdventOfCodeLibrary.Solvers;
using AdventOfCodeLibrary.Util;
using System.Diagnostics.CodeAnalysis;

namespace AdventOfCode.Year2024.Day12.Solvers;

[Solver]
public class Solver : BaseSolver<Grid<char>>
{
    public override int Year => 2024;

    public override int Day => 12;

    public override object? AnswerPartOne => 1494342;

    public override object? AnswerPartTwo => 893676;

    protected override IInputParser<Grid<char>> InputParser => new CharGridParser();

    private List<Region>? _regions;
    private List<Region> Regions
    {
        get
        {
            if (_regions == default)
            {
                InitializeRegions();
            }
            return _regions;
        }
    }

    public override object SolvePartOne()
    {
        var sum = 0;
        foreach (var region in Regions)
        {
            sum += region.Areas.Count() * region.Perimeters.Count();
        }
        return sum;
    }

    public override object SolvePartTwo()
    {
        var sum = 0;
        foreach (var region in Regions)
        {
            sum += region.Areas.Count() * region.PerimeterSides();
        }
        return sum;
    }

    [MemberNotNull(nameof(_regions))]
    private void InitializeRegions()
    {
        _regions = new List<Region>();
        foreach (var keyValuePair in ParsedInput)
        {
            if (!Regions.Any(region => region.Areas.Contains(keyValuePair.Key)))
            {
                AddRegion(keyValuePair.Key, keyValuePair.Value);
            }
        }
    }

    private void AddRegion(Point2D area, char plant)
    {
        var region = new Region(plant);
        AddArea(region, area, plant);
        Regions.Add(region);
    }

    private void AddArea(Region region, Point2D area, char plant)
    {
        if (region.Areas.Contains(area))
        {
            return;
        }
        region.Areas.Add(area);
        foreach (var direction in DirectionUtil.GetBasicDirections())
        {
            var keyValuePair = ParsedInput.GetAdjacentOrDefault(area, direction);
            if (keyValuePair.Value == plant)
            {
                AddArea(region, keyValuePair.Key, plant);
            }
            else
            {
                region.Perimeters.Add((keyValuePair.Key, direction));
            }
        }
    }
}
