using AdventOfCode.Year2024.Day07.Models;
using AdventOfCode.Year2024.Day07.Parsers;
using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.Parsers;
using AdventOfCodeLibrary.Solvers;

namespace AdventOfCode.Year2024.Day07.Solvers;

[Solver]
public class Solver : BaseSolver<List<Equation>>
{
    public override int Year => 2024;

    public override int Day => 7;

    public override object? AnswerPartOne => 6392012777720L;

    public override object? AnswerPartTwo => 61561126043536L;

    protected override IInputParser<List<Equation>> InputParser => new EquationParser();

    public override object SolvePartOne()
    {
        var sum = 0L;
        foreach (var equation in ParsedInput)
        {
            if (CalcPartOne(equation.Numbers[0], equation.Numbers.GetRange(1, equation.Numbers.Count - 1), equation.TestValue))
            {
                sum += equation.TestValue;
            }
        }
        return sum;
    }

    public override object SolvePartTwo()
    {
        var sum = 0L;
        foreach (var equation in ParsedInput)
        {
            if (CalcPartTwo(equation.Numbers[0], equation.Numbers.GetRange(1, equation.Numbers.Count - 1), equation.TestValue))
            {
                sum += equation.TestValue;
            }
        }
        return sum;
    }

    private bool CalcPartOne(long result, List<long> numbers, long testValue)
    {
        if (numbers.Count == 0)
        {
            return result == testValue;
        }
        return 
            CalcPartOne(result + numbers[0], numbers.GetRange(1, numbers.Count - 1), testValue) ||
            CalcPartOne(result * numbers[0], numbers.GetRange(1, numbers.Count - 1), testValue);
    }

    private bool CalcPartTwo(long result, List<long> numbers, long testValue)
    {
        if (numbers.Count == 0)
        {
            return result == testValue;
        }
        return 
            CalcPartTwo(result + numbers[0], numbers.GetRange(1, numbers.Count - 1), testValue) || 
            CalcPartTwo(result * numbers[0], numbers.GetRange(1, numbers.Count - 1), testValue) ||
            CalcPartTwo(long.Parse(result.ToString() + numbers[0].ToString()), numbers.GetRange(1, numbers.Count - 1), testValue);
    }
}
