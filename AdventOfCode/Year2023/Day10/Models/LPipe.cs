using AdventOfCodeLibrary.Models;

namespace AdventOfCode.Year2023.Day10.Models;
public class LPipe : Pipe
{
    public LPipe(Point2D point, CardinalDirection cardinalDirection) : base(point)
    {
        if (cardinalDirection == CardinalDirection.West)
        {
            CardinalDirection = CardinalDirection.North;
        }
        else
        {
            CardinalDirection = CardinalDirection.East;
        }
    }

    public override char Symbol => 'L';

    public override CardinalDirection CardinalDirection { get; }
}
