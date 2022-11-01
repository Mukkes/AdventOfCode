namespace AdventOfCode.InputParser
{
    public abstract class SingleLineToIntParser<ResultType> : SingleLineToStringParser<ResultType>
    {
        public SingleLineToIntParser(string fileName) : base(fileName) { }

        protected int ParseSingleLineToInt()
        {
            return int.Parse(ParseSingleLineToString());
        }
    }

    public sealed class SingleLineToIntParser : SingleLineToIntParser<int>
    {
        public SingleLineToIntParser(string fileName) : base(fileName) { }

        protected override int Parse()
        {
            return ParseSingleLineToInt();
        }
    }
}
