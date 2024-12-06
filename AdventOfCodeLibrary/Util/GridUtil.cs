using AdventOfCodeLibrary.Models;

namespace AdventOfCodeLibrary.Util;
public static class GridUtil
{
    public static T GetAdjacentValue<T>(this Grid<T> grid, Point2D point, Direction direction)
    {
        var adjacentPoint = point.GetAdjacentPoint(direction);
        return grid[adjacentPoint];
    }

    public static T? GetAdjacentValueOrDefault<T>(this Grid<T> grid, Point2D point, Direction direction)
    {
        var adjacentPoint = point.GetAdjacentPoint(direction);
        return grid.GetValueOrDefault(adjacentPoint);
    }

    public static KeyValuePair<Point2D, T> GetAdjacent<T>(this Grid<T> grid, Point2D point, Direction direction)
    {
        var adjacentPoint = point.GetAdjacentPoint(direction);
        return new KeyValuePair<Point2D, T>(adjacentPoint, grid[adjacentPoint]);
    }

    public static KeyValuePair<Point2D, T?> GetAdjacentOrDefault<T>(this Grid<T> grid, Point2D point, Direction direction)
    {
        var adjacentPoint = point.GetAdjacentPoint(direction);
        return new KeyValuePair<Point2D, T?>(adjacentPoint, grid.GetValueOrDefault(adjacentPoint));
    }
}
