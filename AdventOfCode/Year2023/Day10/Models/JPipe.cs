using AdventOfCodeLibrary.Models;

namespace AdventOfCode.Year2023.Day10.Models;
public class JPipe : Pipe
{
    public JPipe(Point2D point, Direction cardinalDirection) : base(point)
    {
        if (cardinalDirection == Direction.East)
        {
            CardinalDirection = Direction.North;
        }
        else
        {
            CardinalDirection = Direction.West;
        }
    }

    public override char Symbol => 'J';

    public override Direction CardinalDirection { get; }
}
