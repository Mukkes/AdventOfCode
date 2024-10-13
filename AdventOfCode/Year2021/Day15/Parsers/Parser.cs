using AdventOfCodeLibrary.Parsers;

namespace AdventOfCode.Year2021.Day15.Parsers;
internal class Parser : StringArrayParser, IInputParser<int[,]>
{
    public new int[,] Parse(string input)
    {
        var stringArray = base.Parse(input);
        var result = new int[stringArray.Length, stringArray[0].Length];
        for (int x = 0; x < stringArray.Length; x++)
        {
            for (int y = 0; y < stringArray[0].Length; y++)
            {
                result[x, y] = int.Parse(stringArray[x][y].ToString());
            }
        }
        return result;
    }
}
