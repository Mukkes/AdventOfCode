namespace AdventOfCodeLibrary.Models;
public readonly struct Vector2D
{
    public long X { get; init; }
    public long Y { get; init; }

    public Vector2D(long x, long y)
    {
        X = x;
        Y = y;
    }

    public override string ToString()
    {
        return X + "," + Y;
    }
}
