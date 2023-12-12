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
        var sum = 0;
        foreach (var line in Input)
        {
            var record = line.Split(' ');
            var conditions = record[0];
            var criteria = record[1].ExtractIntArray();
            sum += GetArrangements(criteria, conditions);
        }
        return sum;
    }

    public override object SolvePartTwo()
    {
        return 0;
    }

    private int GetArrangements(int[] criteria, string conditions)
    {
        var arrangements = 0;
        while (conditions.Length >= criteria[0])
        {
            if (CanBeDamaged(conditions.Substring(0, criteria[0])))
            {
                var restConditions = conditions.Substring(criteria[0]);
                if (criteria.Length > 1)
                {
                    if (restConditions.Length > 0 &&
                        CanBeOperational(restConditions[0..1]))
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
