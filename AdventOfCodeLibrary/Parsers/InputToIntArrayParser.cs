namespace AdventOfCodeLibrary.Parsers;

public class InputToIntArrayParser : InputToStringArrayParser, IInputParser<int[]>
{
    public InputToIntArrayParser() : base()
    {
    }

    public InputToIntArrayParser(string separator) : base(separator)
    {
    }

    public new int[] Parse(string input)
    {
        return Array.ConvertAll(base.Parse(input), int.Parse);
    }
}
