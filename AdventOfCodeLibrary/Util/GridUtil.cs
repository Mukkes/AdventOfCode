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

    public static List<KeyValuePair<Point2D, T?>> GetNeighbors<T>(this Grid<T> grid, Point2D point)
    {
        var neighborPoints = point.GetNeighbors();
        var neighbors = new List<KeyValuePair<Point2D, T?>>();
        foreach (var neighborPoint in neighborPoints)
        {
            neighbors.Add(new KeyValuePair<Point2D, T?>(neighborPoint, grid.GetValueOrDefault(neighborPoint)));
        }
        return neighbors;
    }

    public static List<KeyValuePair<Point2D, T?>> GetValidNeighbors<T>(this Grid<T> grid, Point2D point)
    {
        var neighborPoints = point.GetNeighbors();
        var neighbors = new List<KeyValuePair<Point2D, T?>>();
        foreach (var neighborPoint in neighborPoints)
        {
            if (grid.ContainsKey(neighborPoint))
            {
                neighbors.Add(new KeyValuePair<Point2D, T?>(neighborPoint, grid[neighborPoint]));
            }
        }
        return neighbors;
    }

    public static List<KeyValuePair<Point2D, T?>> GetValidAdjacents<T>(this Grid<T> grid, Point2D point)
    {
        var neighborPoints = point.GetAdjacents();
        var neighbors = new List<KeyValuePair<Point2D, T?>>();
        foreach (var neighborPoint in neighborPoints)
        {
            if (grid.ContainsKey(neighborPoint))
            {
                neighbors.Add(new KeyValuePair<Point2D, T?>(neighborPoint, grid[neighborPoint]));
            }
        }
        return neighbors;
    }
}
