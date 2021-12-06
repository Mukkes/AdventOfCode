using System;

namespace AdventOfCode.InputParser
{
    public class MultiLineToIntArrayParser : InputParser<int[]>
    {
        public MultiLineToIntArrayParser(string fileName) : base(fileName) { }

        protected override int[] Parse()
        {
            var input = GetInputFileContent();
            return Array.ConvertAll(input, int.Parse);
        }
    }
}
