using AdventOfCodeLibrary.Parsers;

namespace AdventOfCodeLibrary.Solvers;

public abstract class BaseSolver<TInput> : IBaseSolver
{
    private readonly IInputParser<TInput> _inputParser;
    private readonly string _inputFileName;
    private readonly string _originalInput;

    public abstract int Year { get; }
    public abstract int Day { get; }
    public virtual object? AnswerPartOne => null;
    public virtual object? AnswerPartTwo => null;
    public TInput Input { get; private set; }

    public BaseSolver(IInputParser<TInput> inputParser)
    {
        _inputParser = inputParser;
        _inputFileName = "Year" + Year + @"\Day" + string.Format("{0:00}", Day) + @"\Input.txt";
        _originalInput = File.ReadAllText(_inputFileName);
        SetInput(_originalInput);
    }

    public abstract object SolvePartOne();
    public abstract object SolvePartTwo();

    public void SetInput(string input)
    {
        Input = _inputParser.Parse(input);
    }

    public override string ToString()
    {
        return "Year: " + Year + " Day: " + Day + ")";
    }
}
