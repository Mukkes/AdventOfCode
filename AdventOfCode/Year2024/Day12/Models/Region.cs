using AdventOfCodeLibrary.Models;

namespace AdventOfCode.Year2024.Day12.Models;
public class Region
{
    public HashSet<Point2D> Areas { get; } = new HashSet<Point2D>();
    public int Perimeter { get; set; }
}
