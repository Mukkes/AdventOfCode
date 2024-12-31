namespace AdventOfCodeLibrary.Models;
public readonly struct Point2D
{
    public long X { get; init; }
    public long Y { get; init; }

    public Point2D() : this(0, 0) { }

    public Point2D(long x, long y)
    {
        X = x;
        Y = y;
    }

    public static bool operator ==(Point2D pointA, Point2D pointB)
    {
        return
            pointA.X == pointB.X &&
            pointA.Y == pointB.Y;
    }

    public static bool operator !=(Point2D pointA, Point2D pointB)
    {
        return
            pointA.X != pointB.X ||
            pointA.Y != pointB.Y;
    }

    public static Point2D operator +(Point2D point, Vector2D vector)
    {
        return new Point2D(point.X + vector.X, point.Y + vector.Y);
    }

    public static Point2D operator +(Vector2D vector, Point2D point)
    {
        return point + vector;
    }

    public static Vector2D operator -(Point2D pointA, Point2D pointB)
    {
        return new Vector2D(pointA.X - pointB.X, pointA.Y - pointB.Y);
    }

    public override int GetHashCode()
    {
        return X.GetHashCode() ^ Y.GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        return 
            (obj is Point2D point) &&
            X == point.X &&
            Y == point.Y;
    }

    public override string ToString()
    {
        return X + "," + Y;
    }
}
