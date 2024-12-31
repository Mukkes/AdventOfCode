using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.Parsers;
using AdventOfCodeLibrary.Solvers;

namespace AdventOfCode.Year2024.Day13;

[Solver]
public class Solver : BaseSolver<List<ClawMachine>>
{
    public override object? AnswerPartOne => 35997;

    //public override object? AnswerPartTwo => ;

    protected override IInputParser<List<ClawMachine>> InputParser => new ClawMachineParser();

    public override object SolvePartOne()
    {
        var totalTokens = 0L;
        foreach (var clawMachine in ParsedInput)
        {
            if (WinPrize(clawMachine, out long tokens))
            {
                totalTokens += tokens;
            }
        }
        return totalTokens;
    }

    public override object SolvePartTwo()
    {
        //var totalTokens = 0L;
        //foreach (var clawMachine in ParsedInput)
        //{
        //    clawMachine.Prize = new Point2D(clawMachine.Prize.X + 10000000000000L, clawMachine.Prize.Y + 10000000000000L);
        //    if (WinPrize(clawMachine, out long tokens))
        //    {
        //        totalTokens += tokens;
        //    }
        //}
        //return totalTokens;
        return 0;
    }

    private bool WinPrize(ClawMachine clawMachine, out long tokens)
    {
        tokens = long.MaxValue;
        var buttonADirection = (double)clawMachine.ButtonA.X / (double)clawMachine.ButtonA.Y;
        var buttonBDirection = (double)clawMachine.ButtonB.X / (double)clawMachine.ButtonB.Y;
        var prizeDirection = (double)clawMachine.Prize.X / (double)clawMachine.Prize.Y;
        var a = 1L;
        var b = 0L;
        var x = clawMachine.ButtonA.X;
        var y = clawMachine.ButtonA.Y;
        var direction = (double)x / (double)y;
        while (true)
        {
            if (x > clawMachine.Prize.X ||
                y > clawMachine.Prize.Y)
            {
                return false;
            }
            var amount = clawMachine.Prize.X / x;
            if (((clawMachine.ButtonA.X * a * amount) + (clawMachine.ButtonB.X * b * amount) == clawMachine.Prize.X) &&
            ((clawMachine.ButtonA.Y * a * amount) + (clawMachine.ButtonB.Y * b * amount) == clawMachine.Prize.Y))
            {
                tokens = (a * amount * 3) + b * amount;
                return true;
            }
            if (direction > prizeDirection)
            {
                if (buttonADirection < buttonBDirection)
                {
                    a++;
                    x += clawMachine.ButtonA.X;
                    y += clawMachine.ButtonA.Y;
                }
                else
                {
                    b++;
                    x += clawMachine.ButtonB.X;
                    y += clawMachine.ButtonB.Y;
                }
            }
            else
            {
                if (buttonADirection > buttonBDirection)
                {
                    a++;
                    x += clawMachine.ButtonA.X;
                    y += clawMachine.ButtonA.Y;
                }
                else
                {
                    b++;
                    x += clawMachine.ButtonB.X;
                    y += clawMachine.ButtonB.Y;
                }
            }
            direction = (double)x / (double)y;
        }
    }
}
