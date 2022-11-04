using AdventOfCode2021.Day16.Parsers;

namespace AdventOfCode2021.Day16.Solvers
{
    public abstract class BaseSolver<TInput>
    {
        private const string _inputFileName = "Input.txt";

        private IInputParser<TInput> _inputParser;
        private string _input;

        protected bool UseExampleInput = false;

        public BaseSolver(IInputParser<TInput> inputParser) : this(inputParser, null) { }
        public BaseSolver(IInputParser<TInput> inputParser, string? input)
        {
            _inputParser = inputParser;
            if (input == null)
            {
                _input = File.ReadAllText(_inputFileName);
            }
            else
            {
                _input = input;
            }
        }

        private TInput? _parsedInput;
        public TInput Input
        {
            get
            {
                if (_parsedInput == null)
                {
                    _parsedInput = _inputParser.Parse(_input);
                }
                return _parsedInput;
            }
        }

        public abstract object SolvePartOne();
        public abstract object SolvePartTwo();

        public void PrintResultPartOne()
        {
            Console.WriteLine(SolvePartOne());
        }

        public void PrintResultPartTwo()
        {
            Console.WriteLine(SolvePartTwo());
        }
    }
}
