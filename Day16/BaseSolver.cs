namespace AdventOfCode2021.Day16
{
    public abstract class BaseSolver<TInput>
    {
        private const string ExampleInputFileName = "ExampleInput.txt";
        private const string InputFileName = "Input.txt";

        protected bool UseExampleInput = false;

        public BaseSolver(IInputParser<TInput> inputParser)
        {
            InputParser = inputParser;
        }

        protected IInputParser<TInput> InputParser { get; private set; }

        private TInput _input = default(TInput)!;
        protected TInput Input
        {
            get
            {
                if (_input == null)
                {
                    _input = InputParser.Parse(GetInputFileName());
                }
                return _input;
            }
        }

        protected abstract object SolvePartOne();
        protected abstract object SolvePartTwo();

        private string GetInputFileName()
        {
            if (UseExampleInput)
            {
                return ExampleInputFileName;
            }
            return InputFileName;
        }

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
