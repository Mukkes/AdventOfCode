using AdventOfCodeLibrary.Models;

namespace AdventOfCode.Year2021.Day19.Models;
public class Beacon
{
    public Beacon(int x, int y, int z) : this(new Point3D(x, y, z)) { }

    public Beacon(Point3D point)
    {
        Position = point;
    }

    public Point3D Position { get; set; }

    public override string ToString()
    {
        return "Beacon: " + base.ToString();
    }
}
