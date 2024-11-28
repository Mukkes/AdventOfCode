using AdventOfCodeLibrary.Models;

namespace AdventOfCode.Year2023.Day10.Models;
public class DashPipe : Pipe
{
    public DashPipe(Point2D point, CardinalDirection cardinalDirection) : base(point)
    {
        if (cardinalDirection == CardinalDirection.East)
        {
            CardinalDirection = CardinalDirection.East;
        }
        else
        {
            CardinalDirection = CardinalDirection.West;
        }
    }

    public override char Symbol => '-';

    public override CardinalDirection CardinalDirection { get; }
}
