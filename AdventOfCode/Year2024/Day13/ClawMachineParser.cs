using AdventOfCodeLibrary.Models;
using AdventOfCodeLibrary.Parsers;
using System.Text.RegularExpressions;

namespace AdventOfCode.Year2024.Day13;
public class ClawMachineParser : StringArrayParser, IInputParser<List<ClawMachine>>
{
    public new List<ClawMachine> Parse(string input)
    {
        var clawMachines = new List<ClawMachine>();
        var clawMachine = default(ClawMachine);
        foreach (var line in base.Parse(input))
        {
            if (line == string.Empty)
            {
                continue;
            }
            if (line[0..8] == "Button A")
            {
                clawMachine = new ClawMachine();
                var match = Regex.Match(line, @"X\+(?<x>\d*), Y\+(?<y>\d*)");
                clawMachine.ButtonA = new Vector2D(int.Parse(match.Groups["x"].Value), int.Parse(match.Groups["y"].Value));
            }
            else if (line[0..8] == "Button B")
            {
                var match = Regex.Match(line, @"X\+(?<x>\d*), Y\+(?<y>\d*)");
                clawMachine!.ButtonB = new Vector2D(int.Parse(match.Groups["x"].Value), int.Parse(match.Groups["y"].Value));
            }
            else if (line[0..5] == "Prize")
            {
                var match = Regex.Match(line, @"X\=(?<x>\d*), Y\=(?<y>\d*)");
                clawMachine!.Prize = new Point2D(int.Parse(match.Groups["x"].Value), int.Parse(match.Groups["y"].Value));
                clawMachines.Add(clawMachine);
            }
        }
        return clawMachines;
    }
}
