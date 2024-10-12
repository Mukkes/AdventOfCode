using AdventOfCodeLibrary.Parsers;

namespace AdventOfCodeLibrary.Solvers;

public abstract class BaseSolver<TOutputType> : IBaseSolver
{
    private readonly IInputParser<TOutputType> _inputParser;
    private readonly string _inputFileName;

    public abstract int Year { get; }
    public abstract int Day { get; }
    public virtual object? AnswerPartOne => null;
    public virtual object? AnswerPartTwo => null;

    private string _input;
    public string Input
    {
        private get => _input;
        set
        {
            _input = value;
            _parsedInput = default;
        }
    }

    private TOutputType? _parsedInput;
    protected TOutputType ParsedInput
    {
        get
        {
            if (Equals(_parsedInput, default(TOutputType)))
            {
                _parsedInput = _inputParser.Parse(_input);
            }
            if (_parsedInput == null)
            {
                throw new Exception("_parsedInput can't be null.");
            }
            return _parsedInput;
        }
    }

    public BaseSolver(IInputParser<TOutputType> inputParser)
    {
        _inputParser = inputParser;
        _inputFileName = "Year" + Year + @"\Day" + string.Format("{0:00}", Day) + @"\Input.txt";
        _input = File.ReadAllText(_inputFileName);
    }

    public abstract object SolvePartOne();
    public abstract object SolvePartTwo();

    public override string ToString()
    {
        return "Year: " + Year + " Day: " + Day;
    }
}
