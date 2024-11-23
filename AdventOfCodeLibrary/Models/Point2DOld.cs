namespace AdventOfCodeLibrary.Models;
[Obsolete]
public class Point2DOld
{
    public long X { get; set; }
    public long Y { get; set; }

    public Point2DOld(Point2DOld point2D) : this(point2D.X, point2D.Y)
    {
    }

    public Point2DOld(long x, long y)
    {
        X = x;
        Y = y;
    }

    public long GetDistance(Point2DOld point)
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
        if (obj is Point2DOld point)
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
