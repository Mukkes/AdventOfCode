using AdventOfCodeLibrary.Parsers;

namespace AdventOfCode.Year2021.Day12.Parsers;

internal class Parser : StringListParser, IInputParser<List<string[]>>
{
    public new List<string[]> Parse(string input)
    {
        var result = new List<string[]>();
        foreach (var line in base.Parse(input))
        {
            var s = line.Split('-');
            result.Add(s);
        }
        return result;
    }
}
