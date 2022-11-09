using AdventOfCode2021.Day16.Parsers;

namespace AdventOfCode2021.Day16.Solvers
{
    public abstract class BaseSolver<TInput>
    {
        private const string _inputFileName = "Input.txt";

        private IInputParser<TInput> _inputParser;
        private string _input;

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

        public TInput Input => _inputParser.Parse(_input);

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
