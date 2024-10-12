namespace AdventOfCodeLibrary.Parsers;

public class StringArrayParser : IInputParser<string[]>
{
    private readonly string _separator;

    public StringArrayParser() : this(Environment.NewLine)
    {
    }

    public StringArrayParser(string separator)
    {
        _separator = separator;
    }

    public string[] Parse(string input)
    {
        return input.Split(_separator);
    }
}
