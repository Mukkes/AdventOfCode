﻿using AdventOfCode.Year2024.Day12.Models;
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

    //public override object? AnswerPartOne => ;

    //public override object? AnswerPartTwo => ;

    protected override IInputParser<Grid<char>> InputParser => new CharGridParser();

    private Dictionary<Point2D, Region>? _regions;
    private Dictionary<Point2D, Region> Regions
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
        foreach (var region in Regions.Values.Distinct())
        {
            sum += region.Areas.Count() * region.Perimeters.Count();
        }
        return sum;
    }

    public override object SolvePartTwo()
    {
        var sum = 0;
        foreach (var region in Regions.Values.Distinct())
        {
            sum += region.Areas.Count() * region.PerimeterSides();
        }
        return sum;
    }

    [MemberNotNull(nameof(_regions))]
    private void InitializeRegions()
    {
        _regions = new Dictionary<Point2D, Region>();
        foreach (var keyValuePair in ParsedInput)
        {
            if (!Regions.ContainsKey(keyValuePair.Key))
            {
                AddRegion(new Region(keyValuePair.Value), keyValuePair.Key, keyValuePair.Value);
            }
        }
    }

    private void AddRegion(Region region, Point2D point, char plant)
    {
        if (Regions.ContainsKey(point))
        {
            return;
        }
        region.Areas.Add(point);
        Regions.Add(point, region);
        var neighbors = ParsedInput.GetNeighbors(point);
        foreach (var keyValuePair in neighbors)
        {
            if (keyValuePair.Value == plant)
            {
                AddRegion(region, keyValuePair.Key, plant);
            }
            else
            {
                region.Perimeters.Add(keyValuePair.Key);
            }
        }
    }
}
