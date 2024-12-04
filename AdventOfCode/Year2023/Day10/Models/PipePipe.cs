using AdventOfCodeLibrary.Models;

namespace AdventOfCode.Year2023.Day10.Models;
public class PipePipe : Pipe
{
    public PipePipe(Point2D point, Direction cardinalDirection) : base(point)
    {
        if (cardinalDirection == Direction.North)
        {
            CardinalDirection = Direction.North;
        }
        else
        {
            CardinalDirection = Direction.South;
        }
    }

    public override char Symbol => '|';

    public override Direction CardinalDirection { get; }
}
