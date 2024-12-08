namespace AdventOfCodeLibrary.Models;
public readonly struct Vector2D
{
    public int X { get; init; }
    public int Y { get; init; }

    public Vector2D(int x, int y)
    {
        X = x;
        Y = y;
    }

    public override string ToString()
    {
        return X + "," + Y;
    }
}
