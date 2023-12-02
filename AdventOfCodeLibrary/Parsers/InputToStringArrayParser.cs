namespace AdventOfCodeLibrary.Parsers;

public class InputToStringArrayParser : IInputParser<string[]>
{
    public string[] Parse(string input)
    {
        return input.Split(Environment.NewLine);
    }
}
