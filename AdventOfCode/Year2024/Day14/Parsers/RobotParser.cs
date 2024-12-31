using AdventOfCode.Year2024.Day14.Models;
using AdventOfCodeLibrary.Models;
using AdventOfCodeLibrary.Parsers;

namespace AdventOfCode.Year2024.Day14.Parsers;
public class RobotParser : StringArrayParser, IInputParser<List<Robot>>
{
    public new List<Robot> Parse(string input)
    {
        var robots = new List<Robot>();
        foreach (var line in base.Parse(input))
        {
            var data = 
                line
                .Replace("p=", string.Empty)
                .Replace("v=", string.Empty)
                .Split(" ");
            var p = Array.ConvertAll(data[0].Split(","), int.Parse);
            var v = Array.ConvertAll(data[1].Split(","), int.Parse);
            var robot = new Robot(new Point2D(p[0], p[1]), new Vector2D(v[0], v[1]));
            robots.Add(robot);
        }
        return robots;
    }
}
