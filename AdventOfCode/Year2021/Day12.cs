using AdventOfCode.InputParser;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2021
{
    public class Day12 : PuzzleSolution<List<string[]>, int>
    {
        public Day12() : this(false) { }
        public Day12(bool useExampleInput) : base(2021, 12, useExampleInput)
        {
            InputParser = new MultiLineToPathParser(InputFile);
        }

        public override int ResultPartOne()
        {
            var startCave = CreateCaveSystem("start");
            var distinctPaths = CreateDistinctPaths(startCave, ContainsPartOne);
            return distinctPaths.Count;
        }

        public override int ResultPartTwo()
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
            foreach (var line in Input)
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

    class Cave
    {
        public readonly string name;
        public List<Cave> Paths { get; set; } = new List<Cave>();
        public bool IsBig => name.All(char.IsUpper);

        public Cave(string name)
        {
            this.name = name;
        }
    }

    sealed class MultiLineToPathParser : MultiLineToStringListParser<List<string[]>>
    {
        public MultiLineToPathParser(string fileName) : base(fileName) { }

        protected override List<string[]> Parse()
        {
            var result = new List<string[]>();
            foreach (var line in ParseMultiLineToStringList())
            {
                var s = line.Split('-');
                result.Add(s);
            }
            return result;
        }
    }
}
