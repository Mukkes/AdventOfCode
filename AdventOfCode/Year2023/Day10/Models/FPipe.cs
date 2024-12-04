using AdventOfCodeLibrary.Models;

namespace AdventOfCode.Year2023.Day10.Models;
public class FPipe : Pipe
{
    public FPipe(Point2D point, Direction cardinalDirection) : base(point)
    {
        if (cardinalDirection == Direction.North)
        {
            CardinalDirection = Direction.East;
        }
        else
        {
            CardinalDirection = Direction.South;
        }
    }

    public override char Symbol => 'F';

    public override Direction CardinalDirection { get; }
}
