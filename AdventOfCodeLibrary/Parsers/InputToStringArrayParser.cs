namespace AdventOfCodeLibrary.Parsers;

public class InputToStringArrayParser : IInputParser<string[]>
{
    private readonly string _separator;

    public InputToStringArrayParser() : this(Environment.NewLine)
    {
    }

    public InputToStringArrayParser(string separator)
    {
        _separator = separator;
    }

    public string[] Parse(string input)
    {
        return input.Split(_separator);
    }
}
