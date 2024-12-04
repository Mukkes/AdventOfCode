using AdventOfCodeLibrary.Models;

namespace AdventOfCode.Year2023.Day10.Models;
public class SevenPipe : Pipe
{
    public SevenPipe(Point2D point, Direction cardinalDirection) : base(point)
    {
        if (cardinalDirection == Direction.East)
        {
            CardinalDirection = Direction.South;
        }
        else
        {
            CardinalDirection = Direction.West;
        }
    }

    public override char Symbol => '7';

    public override Direction CardinalDirection { get; }
}
