using System.IO;

namespace AdventOfCode.InputParser
{
    public abstract class MultiLineToMultidimensionalIntArrayParser<ResultType> : MultiLineToStringArrayParser<ResultType>
    {
        public MultiLineToMultidimensionalIntArrayParser(string fileName) : base(fileName) { }

        protected int[,] ParseMultiLineToMultidimensionalIntArray()
        {
            var input = File.ReadAllLines(_inputFile);
            var result = new int[input.Length, input[0].Length];
            for (int x = 0; x < input.Length; x++)
            {
                for (int y = 0; y < input[0].Length; y++)
                {
                    result[x, y] = int.Parse(input[x][y].ToString());
                }
            }
            return result;
        }
    }

    public sealed class MultiLineToMultidimensionalIntArrayParser : MultiLineToMultidimensionalIntArrayParser<int[,]>
    {
        public MultiLineToMultidimensionalIntArrayParser(string fileName) : base(fileName) { }

        protected override int[,] Parse()
        {
            return ParseMultiLineToMultidimensionalIntArray();
        }
    }
}
