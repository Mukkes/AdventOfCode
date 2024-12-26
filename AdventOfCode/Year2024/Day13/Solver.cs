using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.Parsers;
using AdventOfCodeLibrary.Solvers;

namespace AdventOfCode.Year2024.Day13;

[Solver]
public class Solver : BaseSolver<List<ClawMachine>>
{
    //public override object? AnswerPartOne => ;

    //public override object? AnswerPartTwo => ;

    protected override IInputParser<List<ClawMachine>> InputParser => new ClawMachineParser();

    public override object SolvePartOne()
    {
        var totalTokens = 0;
        foreach (var clawMachine in ParsedInput)
        {
            if (WinPrize(clawMachine, out int tokens))
            {
                totalTokens += tokens;
            }
        }
        return totalTokens;
    }

    public override object SolvePartTwo()
    {
        return 0;
    }

    private bool WinPrize(ClawMachine clawMachine, out int tokens)
    {
        tokens = int.MaxValue;
        for (var a = 0; a <= 100; a++)
        {
            for (var b = 0; b <= 100; b++)
            {
                var x = (clawMachine.ButtonA.X * a) + (clawMachine.ButtonB.X * b);
                var y = (clawMachine.ButtonA.Y * a) + (clawMachine.ButtonB.Y * b);
                if (clawMachine.Prize.X == x && clawMachine.Prize.Y == y)
                {
                    var t = (a * 3) + b;
                    if (tokens > t)
                    {
                        tokens = t;
                    }
                }
            }
        }
        for (var b = 0; b <= 100; b++)
        {
            for (var a = 0; a <= 100; a++)
            {
                var x = (clawMachine.ButtonA.X * a) + (clawMachine.ButtonB.X * b);
                var y = (clawMachine.ButtonA.Y * a) + (clawMachine.ButtonB.Y * b);
                if (clawMachine.Prize.X == x && clawMachine.Prize.Y == y)
                {
                    var t = (a * 3) + b;
                    if (tokens > t)
                    {
                        tokens = t;
                    }
                }
            }
        }
        return tokens != int.MaxValue;
    }
}
