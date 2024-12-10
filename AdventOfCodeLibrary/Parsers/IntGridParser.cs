using AdventOfCodeLibrary.Models;

namespace AdventOfCodeLibrary.Parsers;
public class IntGridParser : StringArrayParser, IInputParser<Grid<int>>
{
    public new Grid<int> Parse(string input)
    {
        var grid = new Grid<int>();
        var parsedInput = base.Parse(input);
        for (int y = 0; y < parsedInput.Length; y++)
        {
            for (int x = 0; x < parsedInput[y].Length; x++)
            {
                grid.Add(new Point2D(x, y), int.Parse(parsedInput[y][x].ToString()));
            }
        }
        return grid;
    }
}
