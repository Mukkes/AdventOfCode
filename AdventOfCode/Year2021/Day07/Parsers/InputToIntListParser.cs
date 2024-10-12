using AdventOfCodeLibrary.Parsers;

namespace AdventOfCode.Year2021.Day07.Parsers;

public class InputToIntListParser : InputToIntArrayParser, IInputParser<List<int>>
{
    public InputToIntListParser() : base()
    {
    }

    public InputToIntListParser(string separator) : base(separator)
    {
    }

    public new List<int> Parse(string input)
    {
        var inputArray = base.Parse(input);
        return inputArray.ToList();
    }
}