namespace AdventOfCodeLibrary.Models;
public class Point2D
{
    public long X { get; set; }
    public long Y { get; set; }

    public Point2D(Point2D point2D) : this(point2D.X, point2D.Y)
    {
    }

    public Point2D(long x, long y)
    {
        X = x;
        Y = y;
    }

    public long GetDistance(Point2D point)
    {
        var distanceX = Math.Abs(X - point.X);
        var distanceY = Math.Abs(Y - point.Y);
        return distanceX + distanceY;
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
