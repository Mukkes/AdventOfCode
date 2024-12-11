namespace AdventOfCodeLibrary.Parsers;

public class LongListParser : LongArrayParser, IInputParser<List<long>>
{
    public LongListParser() : base()
    {
    }

    public LongListParser(string separator) : base(separator)
    {
    }

    public new List<long> Parse(string input)
    {
        return base.Parse(input).ToList();
    }
}