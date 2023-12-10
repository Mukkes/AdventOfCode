using AdventOfCode.Year2023.Day05.Models;
using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.ExtensionClasses;
using AdventOfCodeLibrary.Solvers;

namespace AdventOfCode.Year2023.Day05.Solvers;

[Solver]
public class Solver : StringArraySolver
{
    public override int Year => 2023;

    public override int Day => 5;

    public override object? AnswerPartOne => 175622908L;

    public override object? AnswerPartTwo => 5200543L;

    public override object SolvePartOne()
    {
        var seeds = GetSeeds(Input[0]);
        var maps = GetMaps(Input[2..]);
        var min = long.MaxValue;
        foreach (var seed in seeds)
        {
            var s = seed;
            foreach (var map in maps)
            {
                s = map.Convert(s);
            }
            if (s < min)
            {
                min = s;
            }
        }
        return min;
    }

    public override object SolvePartTwo()
    {
        var seedRanges = GetSeedRanges(Input[0]);
        var maps = GetMaps(Input[2..]);
        maps.Reverse();
        for (var i = 0L; i < long.MaxValue; i++)
        {
            var seed = i;
            foreach (var map in maps)
            {
                seed = map.ConvertBack(seed);
            }
            if (SeedRangesContainsSeed(seedRanges, seed))
            {
                return i;
            }
        }
        return 0;
    }

    private List<long> GetSeeds(string input)
    {
        var seeds = new List<long>();
        var seedNumbers = input[7..].Split(' ');
        foreach (var seedNumber in seedNumbers)
        {
            seeds.Add(seedNumber.ExtractLong());
        }
        return seeds;
    }

    private List<Map> GetMaps(string[] input)
    {
        var maps = new List<Map>();
        var map = default(Map);
        foreach (var line in input)
        {
            if (line.Contains(":"))
            {
                map = new Map();
                continue;
            }
            if (line == string.Empty)
            {
                maps.Add(map);
                continue;
            }
            var numbers = line.Split(' ');
            map.Destinations.Add(numbers[0].ExtractLong());
            map.Sources.Add(numbers[1].ExtractLong());
            map.Ranges.Add(numbers[2].ExtractLong());
        }
        maps.Add(map);
        return maps;
    }

    private List<(long seed, long range)> GetSeedRanges(string input)
    {
        var seedRanges = new List<(long seed, long range)>();
        var seedNumbers = input[7..].Split(' ');
        for (var i = 0; i < seedNumbers.Length; i += 2)
        {
            seedRanges.Add((seedNumbers[i].ExtractLong(), seedNumbers[i + 1].ExtractLong()));
        }
        return seedRanges;
    }

    private bool SeedRangesContainsSeed(List<(long seed, long range)> seedRanges, long seed)
    {
        foreach (var seedRange in seedRanges)
        {
            if (seed >= seedRange.seed && seed <= seedRange.seed + seedRange.range)
            {
                return true;
            }
        }
        return false;
    }
}
