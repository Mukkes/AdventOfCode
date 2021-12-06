using System.IO;

namespace AdventOfCode.InputParser
{
    public abstract class InputParser<ResultType> : IInputParser
    {
        protected readonly string _inputFile;

        public InputParser(string inputFile)
        {
            _inputFile = inputFile;
            Input = Parse();
        }

        public ResultType Input { get;  private set; }

        protected abstract ResultType Parse();

        protected string[] GetInputFileContent()
        {
            return File.ReadAllLines(_inputFile);
        }

        public void ReParse()
        {
            Input = Parse();
        }
    }
}
