using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.Parsers;
using AdventOfCodeLibrary.Solvers;

namespace AdventOfCode.Year2024.Day04.Solvers;

[Solver]
public class Solver : BaseSolver<string[]>
{
    public override int Year => 2024;

    public override int Day => 4;

    //public override object? AnswerPartOne => ;

    //public override object? AnswerPartTwo => ;

    protected override IInputParser<string[]> InputParser => new StringArrayParser();

    public override object SolvePartOne()
    {
        for (var y = 0; y < ParsedInput.Length; y++)
        {
            for (var x = 0; x < ParsedInput[y].Length; x++)
            {
                if (ParsedInput[y][x] == 'X')
                {

                }
            }
        }
        return 0;
    }

    public override object SolvePartTwo()
    {
        return 0;
    }
}
