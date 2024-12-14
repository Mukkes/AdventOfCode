using AdventOfCodeLibrary.Models;

namespace AdventOfCode.Year2024.Day14.Models;
public class Robot
{
    public Point2D Position { get; set; }
    public Vector2D Velocity { get; }
    public Robot(Point2D position, Vector2D velocity)
    {
        Position = position;
        Velocity = velocity;
    }

    public override string ToString()
    {
        return Position.ToString();
    }
}
