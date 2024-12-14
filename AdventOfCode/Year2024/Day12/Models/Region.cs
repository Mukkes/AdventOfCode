using AdventOfCodeLibrary.Models;
using System.Reflection.Metadata;

namespace AdventOfCode.Year2024.Day12.Models;
public class Region
{
    public char Plant { get; }
    public HashSet<Point2D> Areas { get; } = new HashSet<Point2D>();
    public List<Point2D> Perimeters { get; set; } = new List<Point2D>();

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
        OrderPerimeters();
        var sides = 0;
        var previous = new Point2D(int.MaxValue, int.MaxValue);
        foreach (var perimeter in Perimeters)
        {
            if (!IsSameSide(perimeter, previous))
            {
                sides++;
            }
            previous = perimeter;
        }
        if (IsSameSide(Perimeters.First(), Perimeters.Last()))
        {
            sides--;
        }
        return sides;
    }

    private bool IsSameSide(Point2D pointA, Point2D pointB)
    {
        return pointA.X == pointB.X || pointA.Y == pointB.Y;
    }

    private void OrderPerimeters()
    {
        var newPerimeters = new List<Point2D>();
        var previous = Perimeters.First();
        while (Perimeters.Count > 0)
        {
            newPerimeters.Add(previous);
            previous = Perimeters.First(perimeter => (perimeter.X == previous.X || Math.Abs(perimeter.X - previous.X) == 1) && (perimeter.Y == previous.Y || Math.Abs(perimeter.Y - previous.Y) == 1));
            Perimeters.Remove(newPerimeters.Last());
        }
        Perimeters = newPerimeters;
    }
}
