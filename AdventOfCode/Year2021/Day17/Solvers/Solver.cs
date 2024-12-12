using AdventOfCode.Year2021.Day17.Models;
using AdventOfCode.Year2021.Day17.Parsers;
using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.Parsers;
using AdventOfCodeLibrary.Solvers;
using System.Drawing;

namespace AdventOfCode.Year2021.Day17.Solvers;

[Solver]
public class Solver : BaseSolver<Target>
{
    public override object? AnswerPartOne => 9180;

    public override object? AnswerPartTwo => 3767;

    protected override IInputParser<Target> InputParser => new TargetParser();

    private int _height = int.MinValue;
    private int _count = 0;

    public override object SolvePartOne()
    {
        for (var x = 0; x < 200; x++)
        {
            for (var y = -1000; y < 1000; y++)
            {
                var velocity = new Point(x, y);
                TrajectoryWithinTarget(velocity);
            }
        }
        return _height;
    }

    public override object SolvePartTwo()
    {
        return _count;
    }

    private bool TrajectoryWithinTarget(Point velocity)
    {
        var height = int.MinValue;
        var probe = new Point(0, 0);
        while (probe.X <= ParsedInput.BottomRight.X && probe.Y >= ParsedInput.BottomRight.Y)
        {
            if (ParsedInput.IsInside(probe))
            {
                if (height > _height)
                {
                    _height = height;
                }
                _count++;
                return true;
            }
            if (probe.X + velocity.X > probe.X)
            {
                probe.X += velocity.X;
                velocity.X--;
            }
            probe.Y += velocity.Y;
            velocity.Y--;
            if (probe.Y > height)
            {
                height = probe.Y;
            }
        }
        return false;
    }
}
