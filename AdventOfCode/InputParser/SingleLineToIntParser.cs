namespace AdventOfCode.InputParser
{
    public class SingleLineToIntParser : InputParser<int>
    {
        public SingleLineToIntParser(string fileName) : base(fileName) { }

        protected override int Parse()
        {
            return int.Parse(GetInputFileContent()[0]);
        }
    }
}
