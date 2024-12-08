namespace AdventOfCodeLibrary.Models;
public readonly struct Vector3D
{
    public int X { get; init; }
    public int Y { get; init; }
    public int Z { get; init; }

    public Vector3D(int x, int y, int z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public override string ToString()
    {
        return X + "," + Y + "," + Z;
    }
}
