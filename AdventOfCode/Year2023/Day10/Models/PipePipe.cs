using AdventOfCodeLibrary.Models;

namespace AdventOfCode.Year2023.Day10.Models;
public class PipePipe : Pipe
{
    public PipePipe(Point2D point, CardinalDirection cardinalDirection) : base(point)
    {
        if (cardinalDirection == CardinalDirection.North)
        {
            CardinalDirection = CardinalDirection.North;
        }
        else
        {
            CardinalDirection = CardinalDirection.South;
        }
    }

    public override char Symbol => '|';

    public override CardinalDirection CardinalDirection { get; }
}
