using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.Solvers;

namespace AdventOfCode.Year2023.Day09.Solvers;

[Solver]
public class Solver : StringArraySolver
{
    public override int Year => 2023;

    public override int Day => 9;

    public override object? AnswerPartOne => 1819125966L;

    public override object? AnswerPartTwo => 1140L;

    public override object SolvePartOne()
    {
        var sum = 0L;
        foreach (var line in Input)
        {
            var values = line.Split(' ');
            var history = ParseStrings(values);
            sum += GetNextValue(history);
        }
        return sum;
    }

    public override object SolvePartTwo()
    {
        var sum = 0L;
        foreach (var line in Input)
        {
            var values = line.Split(' ');
            var history = ParseStrings(values.Reverse());
            sum += GetNextValue(history);
        }
        return sum;
    }

    private List<long> ParseStrings(IEnumerable<string> values)
    {
        var history = new List<long>();
        foreach (var value in values)
        {
            history.Add(long.Parse(value));
        }
        return history;
    }

    private long GetNextValue(List<long> values)
    {
        var differences = new List<long>();
        for (var i = 1; i < values.Count; i++)
        {
            differences.Add(values[i] - values[i - 1]);
        }
        if (AllZero(differences))
        {
            return 0 + values.Last();
        }
        return GetNextValue(differences) + values.Last();
    }

    private bool AllZero(List<long> values)
    {
        foreach (var value in values)
        {
            if (value != 0L)
            {
                return false;
            }
        }
        return true;
    }
}
