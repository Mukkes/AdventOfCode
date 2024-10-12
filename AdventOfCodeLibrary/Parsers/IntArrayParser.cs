namespace AdventOfCodeLibrary.Parsers;

public class IntArrayParser : StringArrayParser, IInputParser<int[]>
{
    public IntArrayParser() : base()
    {
    }

    public IntArrayParser(string separator) : base(separator)
    {
    }

    public new int[] Parse(string input)
    {
        return Array.ConvertAll(base.Parse(input), int.Parse);
    }
}
