namespace AdventOfCodeLibrary.Models;
public class Point2D
{
    public int X { get; }
    public int Y { get; }

    public Point2D(Point2D point2D) : this(point2D.X, point2D.Y)
    {
    }

    public Point2D(int x, int y)
    {
        X = x;
        Y = y;
    }

    public override int GetHashCode()
    {
        return X.GetHashCode() ^ Y.GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        if (obj is Point2D point)
        {
            if (X == point.X && Y == point.Y)
            {
                return true;
            }
        }
        return false;
    }

    public override string ToString()
    {
        return X.ToString() + ',' + Y.ToString();
    }
}
