using AdventOfCodeLibrary.Parsers;

namespace AdventOfCode.Year2021.Day07.Parsers;

public class IntListParser : IntArrayParser, IInputParser<List<int>>
{
    public IntListParser() : base()
    {
    }

    public IntListParser(string separator) : base(separator)
    {
    }

    public new List<int> Parse(string input)
    {
        return base.Parse(input).ToList();
    }
}