using System;

namespace AdventOfCode.InputParser
{
    public abstract class MultiLineToIntArrayParser<ResultType> : MultiLineToStringArrayParser<ResultType>
    {
        public MultiLineToIntArrayParser(string fileName) : base(fileName) { }

        protected int[] ParseMultiLineToIntArray()
        {
            var input = ParseMultiLineToStringArray();
            return Array.ConvertAll(input, int.Parse);
        }
    }

    public class MultiLineToIntArrayParser : MultiLineToIntArrayParser<int[]>
    {
        public MultiLineToIntArrayParser(string fileName) : base(fileName) { }

        protected override int[] Parse()
        {
            return ParseMultiLineToIntArray();
        }
    }
}
