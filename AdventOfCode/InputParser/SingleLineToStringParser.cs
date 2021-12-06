namespace AdventOfCode.InputParser
{
    public class SingleLineToStringParser : InputParser<string>
    {
        public SingleLineToStringParser(string fileName) : base(fileName) { }

        protected override string Parse()
        {
            return GetInputFileContent()[0];
        }
    }
}
