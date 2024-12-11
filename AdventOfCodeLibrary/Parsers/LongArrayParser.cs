namespace AdventOfCodeLibrary.Parsers;

public class LongArrayParser : StringArrayParser, IInputParser<long[]>
{
    public LongArrayParser() : base()
    {
    }

    public LongArrayParser(string separator) : base(separator)
    {
    }

    public new long[] Parse(string input)
    {
        return Array.ConvertAll(base.Parse(input), long.Parse);
    }
}
