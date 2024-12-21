using AdventOfCodeLibrary.Models;
using AdventOfCodeLibrary.Util;

namespace AdventOfCode.Year2024.Day12.Models;
public class Region
{
    public char Plant { get; }
    public HashSet<Point2D> Areas { get; } = new HashSet<Point2D>();
    public HashSet<(Point2D point, Direction direction)> Perimeters { get; set; } = new HashSet<(Point2D, Direction)>();

    public Region(char plant)
    {
        Plant = plant;
    }

    public override string ToString()
    {
        return Plant.ToString();
    }

    public int PerimeterSides()
    {
        var sides = 0;
        var perimeters = new HashSet<(Point2D, Direction)>(Perimeters);
        while (perimeters.Count > 0)
        {
            var perimeter = perimeters.First();
            FindAndRemoveSides(perimeters, perimeter);
            sides++;
        }
        return sides;
    }

    private void FindAndRemoveSides(HashSet<(Point2D point, Direction direction)> perimeters, (Point2D point, Direction direction) perimeter)
    {
        perimeters.Remove(perimeter);
        foreach (var neighbor in perimeter.point.GetNeighbors())
        {
            if (perimeters.TryGetValue((neighbor, perimeter.direction), out (Point2D point, Direction direction) neighborPerimeter))
            {
                FindAndRemoveSides(perimeters, neighborPerimeter);
            }
        }
    }
}
