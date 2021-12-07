namespace AdventOfCode.InputParser
{
    public abstract class InputParser<ResultType> : IInputParser<ResultType>
    {
        protected readonly string _inputFile;

        public InputParser(string inputFile)
        {
            _inputFile = inputFile;
            Input = Parse();
        }

        public ResultType Input { get; private set; }

        protected abstract ResultType Parse();
    }
}
