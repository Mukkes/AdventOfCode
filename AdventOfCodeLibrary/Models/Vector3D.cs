namespace AdventOfCodeLibrary.Models;
public readonly struct Vector3D
{
    public long X { get; init; }
    public long Y { get; init; }
    public long Z { get; init; }

    public Vector3D(long x, long y, long z)
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
