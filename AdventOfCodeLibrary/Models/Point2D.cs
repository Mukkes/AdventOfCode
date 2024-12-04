namespace AdventOfCodeLibrary.Models;
public readonly struct Point2D
{
    public int X { get; init; }
    public int Y { get; init; }

    public Point2D() : this(0, 0) { }

    public Point2D(int x, int y)
    {
        X = x;
        Y = y;
    }

    public Point2D GetNextPoint(Direction direction)
    {
        switch (direction)
        {
            case Direction.North:
                return new Point2D(X, Y - 1);
            case Direction.South:
                return new Point2D(X, Y + 1);
            case Direction.East:
                return new Point2D(X + 1, Y);
            case Direction.West:
                return new Point2D(X - 1, Y);
            case Direction.Northeast:
                return new Point2D(X + 1, Y - 1);
            case Direction.Southeast:
                return new Point2D(X + 1, Y + 1);
            case Direction.Southwest:
                return new Point2D(X - 1, Y + 1);
            case Direction.Northwest:
                return new Point2D(X - 1, Y - 1);
        }
        throw new Exception("Unknown direction!");
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
