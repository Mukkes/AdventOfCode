using AdventOfCodeLibrary.Models;

namespace AdventOfCode.Year2023.Day10.Models;
public class JPipe : Pipe
{
    public JPipe(Point2D point, CardinalDirection cardinalDirection) : base(point)
    {
        if (cardinalDirection == CardinalDirection.East)
        {
            CardinalDirection = CardinalDirection.North;
        }
        else
        {
            CardinalDirection = CardinalDirection.West;
        }
    }

    public override char Symbol => 'J';

    public override CardinalDirection CardinalDirection { get; }
}
