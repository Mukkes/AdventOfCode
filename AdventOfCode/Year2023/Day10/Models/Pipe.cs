using AdventOfCodeLibrary.Models;

namespace AdventOfCode.Year2023.Day10.Models;
public abstract class Pipe
{
    public Pipe(Point2D point)
    {
        Point = point;
    }

    public Point2D Point { get; }
    public abstract char Symbol { get; }
    public abstract CardinalDirection CardinalDirection { get; }
}
