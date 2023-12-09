using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.Solvers;

namespace AdventOfCode.Year2023.Day09.Solvers;

[Solver]
public class Solver : StringArraySolver
{
    public override int Year => 2023;

    public override int Day => 09;

    public override object SolvePartOne()
    {
        var sum = 0L;
        foreach (var line in Input)
        {
            var history = new List<long>();
            var values = line.Split(' ');
            foreach (var value in values)
            {
                history.Add(long.Parse(value));
            }
            sum += GetNextValue(history);
        }
        return sum;
    }

    public override object SolvePartTwo()
    {
        return 0;
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
        else
        {

            return GetNextValue(differences) + values.Last();
        }
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
