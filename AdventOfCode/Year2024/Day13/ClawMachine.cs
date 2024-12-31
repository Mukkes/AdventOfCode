using AdventOfCodeLibrary.Models;

namespace AdventOfCode.Year2024.Day13;
public class ClawMachine
{
    public Vector2D ButtonA { get; set; }
    public Vector2D ButtonB { get; set; }
    public Point2D Prize { get; set; }

    public override string ToString()
    {
        return Prize.ToString();
    }
}
