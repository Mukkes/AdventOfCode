using AdventOfCode.Year2024.Day05.Models;
using AdventOfCodeLibrary.Parsers;

namespace AdventOfCode.Year2024.Day05.Parsers;
public class ManualParser : StringArrayParser, IInputParser<Manual>
{
    public new Manual Parse(string input)
    {
        var manual = new Manual();
        foreach (var line in base.Parse(input))
        {
            if (line.Contains('|'))
            {
                var rule = Array.ConvertAll(line.Split('|'), int.Parse);
                manual.Rules.Add((rule[0], rule[1]));
            }
            if (line.Contains(','))
            {
                var update = Array.ConvertAll(line.Split(','), int.Parse).ToList();
                manual.Updates.Add(update);
            }
        }
        return manual;
    }
}
