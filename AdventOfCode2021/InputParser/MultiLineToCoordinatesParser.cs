using System.Collections.Generic;

namespace AdventOfCode.InputParser
{
    public abstract class MultiLineToCoordinatesParser<ResultType> : MultiLineToStringArrayParser<ResultType>
    {
        public MultiLineToCoordinatesParser(string fileName) : base(fileName) { }

        protected List<(int x, int y)> ParseMultiLineToCoordinates()
        {
            var result = new List<(int x, int y)>();
            foreach (var line in ParseMultiLineToStringArray())
            {
                var lineArray = line.Split(',');
                result.Add((int.Parse(lineArray[0]), int.Parse(lineArray[1])));
            }
            return result;
        }
    }

    public sealed class MultiLineToCoordinatesParser : MultiLineToCoordinatesParser<List<(int x, int y)>>
    {
        public MultiLineToCoordinatesParser(string fileName) : base(fileName) { }

        protected override List<(int x, int y)> Parse()
        {
            return ParseMultiLineToCoordinates();
        }
    }
}
