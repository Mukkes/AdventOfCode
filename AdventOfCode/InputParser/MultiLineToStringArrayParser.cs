using System.IO;

namespace AdventOfCode.InputParser
{
    public class MultiLineToStringArrayParser : InputParser<string[]>
    {
        public MultiLineToStringArrayParser(string fileName) : base(fileName) { }

        protected override string[] Parse()
        {
            return GetInputFileContent();
        }
    }
}
