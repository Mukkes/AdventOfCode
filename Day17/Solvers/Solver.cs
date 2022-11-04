using System.Drawing;
using AdventOfCode2021.Day16.Solvers;

namespace AdventOfCode2021.Day17.Solvers
{
    internal class Solver : StringSolver
    {
        private Target _target = new Target(150, 193, -136, -86);
        //private Target _target = new Target(20, 30, -10, -5);
        private int _height = int.MinValue;
        private int _count = 0;

        public override object SolvePartOne()
        {
            for (int x = 0; x < 200; x++)
            {
                for (int y = -1000; y < 1000; y++)
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
            while (probe.X <= _target.BottomRight.X && probe.Y >= _target.BottomRight.Y)
            {
                if (_target.IsInside(probe))
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
}
