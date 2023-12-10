using AdventOfCode.Year2020.Day02.Models;
using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.Solvers;

namespace AdventOfCode.Year2020.Day02.Solvers;

[Solver]
public class Solver : StringArraySolver
{
    public override int Year => 2020;

    public override int Day => 02;

    public override object? AnswerPartOne => 640;

    public override object? AnswerPartTwo => 472;

    public override object SolvePartOne()
    {
        var count = 0;
        foreach (var row in Input)
        {
            var passwordPolicy = ExtractPasswordPolicy(row);
            if (passwordPolicy.IsValidPassword(ExtractPassword(row)))
            {
                count++;
            }
        }
        return count;
    }

    public override object SolvePartTwo()
    {
        var count = 0;
        foreach (var row in Input)
        {
            var passwordPolicy = ExtractPasswordPolicy(row);
            if (passwordPolicy.IsValidPasswordPartTwo(ExtractPassword(row)))
            {
                count++;
            }
        }
        return count;
    }

    private PasswordPolicy ExtractPasswordPolicy(string row)
    {
        var arr = row.Split(' ');
        var numbers = arr[0].Split('-');
        return new PasswordPolicy(int.Parse(numbers[0]), int.Parse(numbers[1]), arr[1].First());
    }

    private string ExtractPassword(string row)
    {
        var arr = row.Split(' ');
        return arr[2];
    }
}
