using AdventOfCode.InputParser;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2021
{
    class Day8 : PuzzleSolution<List<string>, int>
    {
        public Day8() : base(year: 2021, day: 8)
        {
            InputParser = new MultiLineToStringListParser(InputFile);
        }

        public override int ResultPartOne()
        {
            return Input
                .Select(s => new SevenSegmentEntry(s))
                .ToList()
                .Sum(s => s.NumberOfUniqueDigits());
        }

        public override int ResultPartTwo()
        {
            return Input
                .Select(s => new SevenSegmentEntry(s))
                .ToList()
                .Sum(s => s.GetOutputNumber());
        }
    }

    class SevenSegmentEntry
    {
        private readonly string[] _signalPattern;
        private readonly string[] _output;
        private readonly string _one;
        private readonly string _seven;
        private readonly string _four;

        public SevenSegmentEntry(string input)
        {
            var entry = input.Split(" | ");
            _signalPattern = entry[0].Split(" ", StringSplitOptions.RemoveEmptyEntries);
            _output = entry[1].Split(" ", StringSplitOptions.RemoveEmptyEntries);
            _one = _signalPattern.Single(s => s.Length == 2);
            _seven = _signalPattern.Single(s => s.Length == 3);
            _four = _signalPattern.Single(s => s.Length == 4);
        }

        public int NumberOfUniqueDigits()
        {
            return _output.Where(d => HasUniqueNumberOfSegments(d)).Count();
        }

        private bool HasUniqueNumberOfSegments(string digit)
        {
            return digit.Length == 2 || digit.Length == 3 || digit.Length == 4 || digit.Length == 7;
        }

        public int GetOutputNumber()
        {
            var result = "";
            foreach (var digit in _output)
            {
                result += ConvertDigitToInt(digit).ToString();
            }
            return int.Parse(result);
        }

        private int ConvertDigitToInt(string digit)
        {
            if (digit.Length == 2)
            {
                return 1;
            }
            if (digit.Length == 3)
            {
                return 7;
            }
            if (digit.Length == 4)
            {
                return 4;
            }
            if (digit.Length == 7)
            {
                return 8;
            }
            if (digit.Length == 6 && ContainsAllCharacters(digit, _four))
            {
                return 9;
            }
            if (digit.Length == 6 && ContainsAllCharacters(digit, _one))
            {
                return 0;
            }
            if (digit.Length == 6)
            {
                return 6;
            }
            if (digit.Length == 5 && ContainsAllCharacters(digit, _seven))
            {
                return 3;
            }
            if (digit.Length == 5 && ContainsAllCharacters(digit, _four.Replace(_one[0].ToString(), "").Replace(_one[1].ToString(), "")))
            {
                return 5;
            }
            return 2;
        }

        private static bool ContainsAllCharacters(string s, string value)
        {
            for (int i = 0; i < value.Length; i++)
            {
                if (!s.Contains(value[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
