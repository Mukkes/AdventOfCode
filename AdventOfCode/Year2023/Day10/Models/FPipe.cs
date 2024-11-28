using AdventOfCodeLibrary.Models;

namespace AdventOfCode.Year2023.Day10.Models;
public class FPipe : Pipe
{
    public FPipe(Point2D point, CardinalDirection cardinalDirection) : base(point)
    {
        if (cardinalDirection == CardinalDirection.North)
        {
            CardinalDirection = CardinalDirection.East;
        }
        else
        {
            CardinalDirection = CardinalDirection.South;
        }
    }

    public override char Symbol => 'F';

    public override CardinalDirection CardinalDirection { get; }
}
