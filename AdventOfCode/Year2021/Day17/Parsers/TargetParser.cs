using AdventOfCode.Year2021.Day17.Models;
using AdventOfCodeLibrary.Parsers;

namespace AdventOfCode.Year2021.Day17.Parsers;
internal class TargetParser : IInputParser<Target>
{
    public Target Parse(string input)
    {
        var s = Array.ConvertAll(input.Substring(15).Split([", y=", ".."], StringSplitOptions.None), int.Parse);
        return new Target(s[0], s[1], s[2], s[3]);
    }
}
