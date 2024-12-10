using AdventOfCode.Year2021.Day20.Models;
using AdventOfCodeLibrary.Models;
using AdventOfCodeLibrary.Parsers;

namespace AdventOfCode.Year2021.Day20.Parsers;
internal class TrenchMapParser : StringArrayParser, IInputParser<TrenchMap>
{
    public new TrenchMap Parse(string input)
    {
        var inputArray = base.Parse(input);
        var trenchMap = new TrenchMap(inputArray[0]);
        for (var i = 2; i < inputArray.Length; i++)
        {
            for (var j = 0; j < inputArray[i].Length; j++)
            {
                var point = new Point2D(i, j);
                var pixel = inputArray[i][j];
                trenchMap.AddPixel(point, pixel);
            }
        }
        return trenchMap;
    }
}
