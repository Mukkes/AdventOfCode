using AdventOfCodeLibrary.Models;

namespace AdventOfCode.Year2023.Day10.Models;
public class LPipe : Pipe
{
    public LPipe(Point2D point, Direction cardinalDirection) : base(point)
    {
        if (cardinalDirection == Direction.West)
        {
            CardinalDirection = Direction.North;
        }
        else
        {
            CardinalDirection = Direction.East;
        }
    }

    public override char Symbol => 'L';

    public override Direction CardinalDirection { get; }
}
