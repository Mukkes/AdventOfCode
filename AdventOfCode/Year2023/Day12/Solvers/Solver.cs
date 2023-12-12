using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.ExtensionClasses;
using AdventOfCodeLibrary.Solvers;

namespace AdventOfCode.Year2023.Day12.Solvers;

[Solver]
public class Solver : StringArraySolver
{
    public override int Year => 2023;

    public override int Day => 12;

    public override object? AnswerPartOne => 7407;

    public override object? AnswerPartTwo => null;

    public override object SolvePartOne()
    {
        var sum = 0L;
        foreach (var line in Input)
        {
            sum += GetArrangements(line);
        }
        return sum;
    }

    public override object SolvePartTwo()
    {
        var sum = 0L;
        foreach (var line in Input)
        {
            var fi = GetArrangements(line);
            var first = GetArrangements(Unfold(line, 2));
            var second = GetArrangements(Unfold(line, 3));
            var y = first / fi;
            var x = second / first;
            if (y != x)
            {
                var fdsaf = 9;
            }
            sum += second * x * x;
        }
        return sum;
    }

    private string Unfold(string line, int times)
    {
        var result = string.Empty;
        var record = line.Split(' ');
        for (var j = 1; j < times; j++)
        {
            result += record[0] + '?';
        }
        result += record[0] + ' ';
        for (var j = 1; j < times; j++)
        {
            result += record[1] + ',';
        }
        result += record[1];
        return result;
    }

    private long GetArrangements(string line)
    {
        var record = line.Split(' ');
        var conditions = record[0];
        var criteria = record[1].ExtractIntArray();
        return GetArrangements(criteria, conditions);
    }

    private long GetArrangements(int[] criteria, string conditions)
    {
        var arrangements = 0L;
        while (conditions.Length >= criteria[0])
        {
            if (CanBeDamaged(conditions.Substring(0, criteria[0])))
            {
                var restConditions = conditions.Substring(criteria[0]);
                if (criteria.Length > 1)
                {
                    if (restConditions.Length > 0 &&
                        CanBeOperational(restConditions[0..1]) &&
                        conditions.Length >= criteria.Sum() + criteria.Length - 1)
                    {
                        arrangements += GetArrangements(criteria[1..], restConditions[1..]);
                    }
                }
                else if (CanBeOperational(restConditions))
                {
                    arrangements++;
                }
            }
            if (CanBeOperational(conditions[0..1]))
            {
                conditions = conditions.Substring(1);
            }
            else
            {
                conditions = string.Empty;
            }
        }
        return arrangements;
    }

    private bool CanBeOperational(string conditions)
    {
        return !conditions.Contains('#');
    }

    private bool CanBeDamaged(string conditions)
    {
        return !conditions.Contains('.');
    }
}
