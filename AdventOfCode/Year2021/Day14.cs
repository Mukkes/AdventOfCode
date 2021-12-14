using AdventOfCode.InputParser;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2021
{
    public class Day14 : PuzzleSolution<List<string>, long>
    {
        public Day14() : this(false) { }
        public Day14(bool useExampleInput) : base(2021, 14, useExampleInput)
        {
            InputParser = new MultiLineToStringListParser(InputFile);
            CreateRules();
        }
        
        public override long ResultPartOne()
        {
            var s = ProcessSteps(PolymerTemplate, 10);
            var mostCommon = s.GroupBy(x => x).OrderByDescending(x => x.Count()).First().Key;//b,h
            var leastCommon = s.GroupBy(x => x).OrderBy(x => x.Count()).First().Key;//h,o
            var mostCommonValue = s.Count(x => x == mostCommon);
            var leastCommonValue = s.Count(x => x == leastCommon);
            var result = mostCommonValue - leastCommonValue;
            return result;
        }

        public override long ResultPartTwo()
        {
            var pairs = CreatePairs(PolymerTemplate);
            pairs = ProcessSteps2(pairs, 40);
            var mostCommon = 0L;
            var leastCommon = 0L;
            foreach (var pair in pairs)
            {
                if (pair.Key.Contains("HH"))
                {
                    mostCommon += pair.Value + pair.Value;
                }
                else if (pair.Key.Contains("H"))
                {
                    mostCommon += pair.Value;
                }
                if (pair.Key.Contains("OO"))
                {
                    leastCommon += pair.Value + pair.Value;
                }
                else if (pair.Key.Contains("O"))
                {
                    leastCommon += pair.Value;
                }
            }
            var result = (mostCommon / 2) - (leastCommon / 2);
            //var s = ProcessSteps(PolymerTemplate, 10);
            //var mostCommon = s.GroupBy(x => x).OrderByDescending(x => x.Count()).First().Key;
            //var leastCommon = s.GroupBy(x => x).OrderBy(x => x.Count()).First().Key;
            //var mostCommonValue = s.Count(x => x == mostCommon);
            //var leastCommonValue = s.Count(x => x == leastCommon);
            //var result = mostCommonValue - leastCommonValue;
            return result;
        }

        //private Dictionary<string, long> Pairs = new Dictionary<string, long>();

        private Dictionary<string, long> CreatePairs(List<char> input)
        {
            var pairs = new Dictionary<string, long>();
            for (int i = 0; i < input.Count - 1; i++)
            {
                if (pairs.ContainsKey(input[i].ToString() + input[i + 1].ToString()))
                {
                    pairs[input[i].ToString() + input[i + 1].ToString()]++;
                }
                else
                {
                    pairs.Add(input[i].ToString() + input[i + 1].ToString(), 1);
                }
            }
            return pairs;
        }

        private Dictionary<string, long> ProcessSteps2(Dictionary<string, long> pairs, int steps)
        {
            var result = new Dictionary<string, long>(pairs);
            for (int i = 0; i < steps; i++)
            {
                result = Step2(result);
            }
            return result;
        }

        private void IncrementOrInsert(Dictionary<string, long> pairs, string key, long value)
        {
            if (pairs.ContainsKey(key))
            {
                pairs[key] += value;
            }
            else
            {
                pairs.Add(key, value);
            }
        }

        private Dictionary<string, long> Step2(Dictionary<string, long> pairs)
        {
            var newPairs = new Dictionary<string, long>();
            foreach (var pair in pairs)
            {
                if (Rules.TryGetValue(pair.Key, out string v))
                {
                    IncrementOrInsert(newPairs, pair.Key[0] + v, pair.Value);
                    IncrementOrInsert(newPairs, v + pair.Key[1], pair.Value);
                }
                else
                {
                    IncrementOrInsert(newPairs, pair.Key, pair.Value);
                }
            }
            return newPairs;
        }

        private List<char> ProcessSteps(List<char> input, int steps)
        {
            var result = new List<char>(input);
            for (int i = 0; i < steps; i++)
            {
                result = Step(result);
            }
            return result;
        }

        private List<char> Step(List<char> input)
        {
            var list = new List<char>();
            for (int i = 0; i < input.Count - 1; i++)
            {
                list.Add(input[i]);
                if (Rules.TryGetValue(input[i].ToString() + input[i + 1].ToString(), out string result))
                {
                    list.Add(char.Parse(result));
                }
            }
            list.Add(input[input.Count - 1]);
            return list;
        }

        private List<char> PolymerTemplate
        {
            get
            {
                if (_useExampleInput)
                {
                    return "NNCB".ToList();
                }
                else
                {
                    return "HBCHSNFFVOBNOFHFOBNO".ToList();
                }
            }
        }

        private Dictionary<string, string> Rules = new Dictionary<string, string>();

        private void CreateRules()
        {
            foreach (var line in Input)
            {
                var pair = line.Split(" -> ");
                Rules.Add(pair[0], pair[1]);
            }
        }
    }
}
