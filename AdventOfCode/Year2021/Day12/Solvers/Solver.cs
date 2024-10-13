using AdventOfCode.Year2021.Day12.Models;
using AdventOfCode.Year2021.Day12.Parsers;
using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.Parsers;
using AdventOfCodeLibrary.Solvers;

namespace AdventOfCode.Year2021.Day12.Solvers;

[Solver]
public class Solver : BaseSolver<List<string[]>>
{
    public override int Year => 2021;

    public override int Day => 12;

    public override object? AnswerPartOne => 3708;

    public override object? AnswerPartTwo => 93858;

    protected override IInputParser<List<string[]>> InputParser => new Parser();

    public override object SolvePartOne()
    {
        var startCave = CreateCaveSystem("start");
        var distinctPaths = CreateDistinctPaths(startCave, ContainsPartOne);
        return distinctPaths.Count;
    }

    public override object SolvePartTwo()
    {
        var startCave = CreateCaveSystem("start");
        var distinctPaths = CreateDistinctPaths(startCave, ContainsPartTwo);
        return distinctPaths.Count();
    }

    private Dictionary<string, Cave> caveSystem = new Dictionary<string, Cave>();

    private Cave CreateCaveSystem(string name)
    {
        if (caveSystem.TryGetValue(name, out Cave cave))
        {
            return cave;
        }
        var c = new Cave(name);
        caveSystem.Add(name, c);
        c.Paths = CreatePaths(name);
        return c;
    }

    private List<Cave> CreatePaths(string name)
    {
        var result = new List<Cave>();
        foreach (var line in ParsedInput)
        {
            if (line[0] == name)
            {
                result.Add(CreateCaveSystem(line[1]));
            }
            else if (line[1] == name)
            {
                result.Add(CreateCaveSystem(line[0]));
            }
        }
        return result;
    }

    private List<string> CreateDistinctPaths(Cave from, Func<Cave, string, bool> containsFunc)
    {
        var distinctPaths = new List<string>();
        CreateDistinctPaths(from, from.name + ",", distinctPaths, containsFunc);
        return distinctPaths;
    }

    private void CreateDistinctPaths(Cave from, string path, List<string> distinctPaths, Func<Cave, string, bool> containsFunc)
    {
        foreach (var cave in from.Paths)
        {
            if (cave.name == "end")
            {
                distinctPaths.Add(path + cave.name);
            }
            else if (from != cave && containsFunc(cave, path))
            {
                CreateDistinctPaths(cave, path + cave.name + ",", distinctPaths, containsFunc);
            }
        }
    }

    private bool ContainsPartOne(Cave cave, string path)
    {
        return cave.IsBig || (!cave.IsBig && !path.Contains(cave.name));
    }

    private bool ContainsPartTwo(Cave cave, string path)
    {
        if (cave.IsBig)
        {
            return true;
        }
        else
        {
            if (cave.name == "start")
            {
                return false;
            }
            var caveNames = path.Split(',', StringSplitOptions.RemoveEmptyEntries);
            var containsMultipleLowerCaves = caveNames.GroupBy(x => x)
                .Where(x => x.Key.All(char.IsLower) && x.Count() > 1)
                .Count() >= 1;
            if (containsMultipleLowerCaves && path.Contains(cave.name))
            {
                return false;
            }
        }
        return true;
    }
}
