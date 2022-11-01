namespace AdventOfCode.InputParser
{
    public abstract class SingleLineToStringParser<ResultType> : MultiLineToStringArrayParser<ResultType>
    {
        public SingleLineToStringParser(string fileName) : base(fileName) { }

        protected string ParseSingleLineToString()
        {
            return ParseMultiLineToStringArray()[0];
        }
    }

    public sealed class SingleLineToStringParser : SingleLineToStringParser<string>
    {
        public SingleLineToStringParser(string fileName) : base(fileName) { }

        protected override string Parse()
        {
            return ParseSingleLineToString();
        }
    }
}
