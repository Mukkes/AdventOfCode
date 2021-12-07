using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.InputParser
{
    public abstract class SingleLineToIntListParser<ResultType> : SingleLineToStringParser<ResultType>
    {
        public SingleLineToIntListParser(string fileName) : base(fileName) { }

        protected List<int> ParseSingleLineToIntList()
        {
            return ParseSingleLineToString().Split(',').Select(int.Parse).ToList();
        }
    }

    public class SingleLineToIntListParser : SingleLineToIntListParser<List<int>>
    {
        public SingleLineToIntListParser(string fileName) : base(fileName) { }

        protected override List<int> Parse()
        {
            return ParseSingleLineToIntList();
        }
    }
}
