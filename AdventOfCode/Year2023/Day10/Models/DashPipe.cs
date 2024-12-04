using AdventOfCodeLibrary.Models;

namespace AdventOfCode.Year2023.Day10.Models;
public class DashPipe : Pipe
{
    public DashPipe(Point2D point, Direction cardinalDirection) : base(point)
    {
        if (cardinalDirection == Direction.East)
        {
            CardinalDirection = Direction.East;
        }
        else
        {
            CardinalDirection = Direction.West;
        }
    }

    public override char Symbol => '-';

    public override Direction CardinalDirection { get; }
}
