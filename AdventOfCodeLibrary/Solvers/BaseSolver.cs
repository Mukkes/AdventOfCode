using AdventOfCodeLibrary.Parsers;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace AdventOfCodeLibrary.Solvers;

public abstract class BaseSolver<TOutputType> : IBaseSolver
{
    private readonly string _inputFileName;

    public virtual object? AnswerPartOne => null;
    public virtual object? AnswerPartTwo => null;
    protected abstract IInputParser<TOutputType> InputParser { get; }

    private int _year;
    public int Year
    {
        get
        {
            if (_year == default)
            {
                var year = Regex.Match(GetType().Namespace!, @"Year(?<year>\d{4})");
                if (!year.Success)
                {
                    throw new Exception("Namespace should contain \"Year****\"!");
                }
                _year = int.Parse(year.Groups["year"].Value);
            }
            return _year;
        }
    }

    private int _day;
    public int Day
    {
        get
        {
            if (_day == default)
            {
                var day = Regex.Match(GetType().Namespace!, @"Day(?<day>\d{2})");
                if (!day.Success)
                {
                    throw new Exception("Namespace should contain \"Day**\"!");
                }
                _day = int.Parse(day.Groups["day"].Value);
            }
            return _day;
        }
    }

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
    public TOutputType ParsedInput
    {
        get
        {
            if (Equals(_parsedInput, default(TOutputType)))
            {
                _parsedInput = InputParser.Parse(_input);
            }
            return _parsedInput!;
        }
    }

    public BaseSolver()
    {
        _inputFileName = "Year" + Year + @"\Day" + string.Format("{0:00}", Day) + @"\Input.txt";
        ResetInput();
    }

    [MemberNotNull(nameof(_input))]
    public void ResetInput()
    {
        _input = File.ReadAllText(_inputFileName);
        _parsedInput = default;
    }

    public abstract object SolvePartOne();
    public abstract object SolvePartTwo();

    public override string ToString()
    {
        return "Year: " + Year + " Day: " + Day;
    }
}
