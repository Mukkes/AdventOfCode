using AdventOfCode.Year2023.Day02.Models;
using AdventOfCodeLibrary.ExtensionClasses;
using AdventOfCodeLibrary.Parsers;

namespace AdventOfCode.Year2023.Day02.Parsers;

public class CubeConundrumParser : InputToStringArrayParser, IInputParser<List<Game>>
{
    public new List<Game> Parse(string input)
    {
        var inputArray = base.Parse(input);
        var games = new List<Game>();
        foreach (var line in inputArray)
        {
            var split = line.Split(':');
            var game = new Game(StringExtensions.ExtractInteger(split[0]));
            var sets = split[1].Split(';');
            foreach (var set in sets)
            {
                var colors = set.Split(',');
                var blue = GetNumberOfCubes(colors, "blue");
                var green = GetNumberOfCubes(colors, "green");
                var red = GetNumberOfCubes(colors, "red");
                game.AddSet(blue, green, red);
            }
            games.Add(game);
        }
        return games;
    }

    private int GetNumberOfCubes(string[] colors, string name)
    {
        foreach (var color in colors)
        {
            if (color.Contains(name))
            {
                return StringExtensions.ExtractInteger(color);
            }
        }
        return 0;
    }
}