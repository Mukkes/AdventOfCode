namespace AdventOfCodeLibrary.Models;
public class Grid<T> : Dictionary<Point2D, T>
{
    public T? GetCoord(Point2D point)
    {
        return this.GetValueOrDefault(point);
    }

    public void SetCoord(Point2D point, T value)
    {
        if (ContainsKey(point))
        {
            this[point] = value;
        }
        else
        {
            Add(point, value);
        }
    }

    public Point2D FindValue(T value)
    {
        return this.FirstOrDefault(x => x.Value!.Equals(value)).Key;
    }

    public KeyValuePair<Point2D, T> GetAdjacent(Point2D point, Direction direction)
    {
        var adjacentPoint = point.GetAdjacentPoint(direction);
        if (TryGetValue(adjacentPoint, out T? value))
        {
            return new KeyValuePair<Point2D, T>(adjacentPoint, value);
        }
        return new KeyValuePair<Point2D, T>(adjacentPoint, default);
    }
}
