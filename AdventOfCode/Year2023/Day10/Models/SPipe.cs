using AdventOfCodeLibrary.Models;

namespace AdventOfCode.Year2023.Day10.Models;
public class SPipe : Pipe
{
    public SPipe(Point2D point, CardinalDirection cardinalDirection) : base(point)
    {
        CardinalDirection = cardinalDirection;
    }

    public override char Symbol => 'S';

    public override CardinalDirection CardinalDirection { get; }
}
