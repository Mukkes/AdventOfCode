using System.IO;

namespace AdventOfCode.InputParser
{
    public abstract class MultiLineToStringArrayParser<ResultType> : InputParser<ResultType>
    {
        public MultiLineToStringArrayParser(string fileName) : base(fileName) { }

        protected string[] ParseMultiLineToStringArray()
        {
            return File.ReadAllLines(_inputFile);
        }
    }

    public sealed class MultiLineToStringArrayParser : MultiLineToStringArrayParser<string[]>
    {
        public MultiLineToStringArrayParser(string fileName) : base(fileName) { }

        protected override string[] Parse()
        {
            return ParseMultiLineToStringArray();
        }
    }
}
