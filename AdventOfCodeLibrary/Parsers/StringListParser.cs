namespace AdventOfCodeLibrary.Parsers;

public class StringListParser : StringArrayParser, IInputParser<List<string>>
{
    public StringListParser() : base()
    {
    }

    public StringListParser(string separator) : base(separator)
    {
    }

    public new List<string> Parse(string input)
    {
        return base.Parse(input).ToList();
    }
}