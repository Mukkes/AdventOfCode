using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.InputParser
{
    public abstract class MultiLineToStringListParser<ResultType> : MultiLineToStringArrayParser<ResultType>
    {
        public MultiLineToStringListParser(string fileName) : base(fileName) { }

        protected List<string> ParseMultiLineToStringList()
        {
            return ParseMultiLineToStringArray().ToList();
        }
    }

    public sealed class MultiLineToStringListParser : MultiLineToStringListParser<List<string>>
    {
        public MultiLineToStringListParser(string fileName) : base(fileName) { }

        protected override List<string> Parse()
        {
            return ParseMultiLineToStringList();
        }
    }
}
