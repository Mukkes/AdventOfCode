using AdventOfCodeLibrary.Models;

namespace AdventOfCode.Year2023.Day10.Models;
public class SevenPipe : Pipe
{
    public SevenPipe(Point2D point, CardinalDirection cardinalDirection) : base(point)
    {
        if (cardinalDirection == CardinalDirection.East)
        {
            CardinalDirection = CardinalDirection.South;
        }
        else
        {
            CardinalDirection = CardinalDirection.West;
        }
    }

    public override char Symbol => '7';

    public override CardinalDirection CardinalDirection { get; }
}
