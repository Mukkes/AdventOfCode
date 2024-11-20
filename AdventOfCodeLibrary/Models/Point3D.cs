namespace AdventOfCodeLibrary.Models;
public readonly struct Point3D
{
    public int X { get; init; }
    public int Y { get; init; }
    public int Z { get; init; }

    public Point3D(int x, int y, int z)
    {
        X = x;
        Y = y;
        Z = z;
    }
}
