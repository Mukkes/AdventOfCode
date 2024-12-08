namespace AdventOfCodeLibrary.Models;
public class Grid<T> : Dictionary<Point2D, T>
{
    public int XLowerBound { get; private set; } = int.MaxValue;
    public int XUpperBound { get; private set; } = int.MinValue;
    public int YLowerBound { get; private set; } = int.MaxValue;
    public int YUpperBound { get; private set; } = int.MinValue;

    public new void Add(Point2D key, T value)
    {
        if (key.X < XLowerBound)
        {
            XLowerBound = key.X;
        }
        if (key.X > XUpperBound)
        {
            XUpperBound = key.X;
        }
        if (key.Y < YLowerBound)
        {
            YLowerBound = key.Y;
        }
        if (key.Y > YUpperBound)
        {
            YUpperBound = key.Y;
        }
        base.Add(key, value);
    }

    public bool IsInsideGrid(Point2D point)
    {
        return
            point.X >= XLowerBound &&
            point.X <= XUpperBound &&
            point.Y >= YLowerBound &&
            point.Y <= YUpperBound;
    }
}
