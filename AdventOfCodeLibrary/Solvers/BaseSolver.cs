using AdventOfCodeLibrary.Parsers;

namespace AdventOfCodeLibrary.Solvers;

public abstract class BaseSolver<TInput>
{
    private readonly string _inputFileName;

    private IInputParser<TInput> _inputParser;
    private string _input;

    public BaseSolver(IInputParser<TInput> inputParser) : this(inputParser, null) { }
    public BaseSolver(IInputParser<TInput> inputParser, string? input)
    {
        _inputFileName = "Year" + Year + @"\Day" + string.Format("{0:00}", Day) + @"\Input.txt";
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

    public abstract int Year { get; }
    public abstract int Day { get; }
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
