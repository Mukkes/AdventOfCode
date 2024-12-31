using AdventOfCode.Year2024.Day17.Models;
using AdventOfCodeLibrary.Parsers;
using System.Text.RegularExpressions;

namespace AdventOfCode.Year2024.Day17.Parsers;
public class ChronospatialComputerParser : VoidParser, IInputParser<ChronospatialComputer>
{
    public new ChronospatialComputer Parse(string input)
    {
        input = base.Parse(input);
        var registerA = Regex.Match(input, @"Register A: (?<registerA>\d*)").Groups["registerA"].Value;
        var registerB = Regex.Match(input, @"Register B: (?<registerB>\d*)").Groups["registerB"].Value;
        var registerC = Regex.Match(input, @"Register C: (?<registerC>\d*)").Groups["registerC"].Value;
        var program = Regex.Match(input, @"Program: (?<program>[\d|,]*)").Groups["program"].Value;
        return new ChronospatialComputer(int.Parse(registerA), int.Parse(registerB), int.Parse(registerC), Array.ConvertAll(program.Split(','), int.Parse));
    }
}
