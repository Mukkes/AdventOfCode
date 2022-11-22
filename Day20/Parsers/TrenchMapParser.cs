using AdventOfCode2021.Day16.Parsers;
using AdventOfCode2021.Day18.Parsers;

namespace AdventOfCode2021.Day20.Parsers
{
    public class TrenchMapParser : InputToStringArrayParser, IInputParser<TrenchMap>
    {
        public new TrenchMap Parse(string input)
        {
            var inputArray = base.Parse(input);
            var trenchMap = new TrenchMap(inputArray[0]);
            for (var i = 2; i < inputArray.Length; i++)
            {
                for (var j = 0; j < inputArray[i].Length; j++)
                {
                    var point = new Point(i, j);
                    var pixel = inputArray[i][j];
                    trenchMap.AddPixel(point, pixel);
                }
            }
            return trenchMap;
        }
    }
}
