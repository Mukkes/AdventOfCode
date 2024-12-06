using AdventOfCodeLibrary.Models;

namespace AdventOfCodeLibrary.Util;
public static class Point2DUtil
{
    public static Point2D GetAdjacentPoint(this Point2D point, Direction direction)
    {
        switch (direction)
        {
            case Direction.North:
                return new Point2D(point.X, point.Y - 1);
            case Direction.South:
                return new Point2D(point.X, point.Y + 1);
            case Direction.East:
                return new Point2D(point.X + 1, point.Y);
            case Direction.West:
                return new Point2D(point.X - 1, point.Y);
            case Direction.Northeast:
                return new Point2D(point.X + 1, point.Y - 1);
            case Direction.Southeast:
                return new Point2D(point.X + 1, point.Y + 1);
            case Direction.Southwest:
                return new Point2D(point.X - 1, point.Y + 1);
            case Direction.Northwest:
                return new Point2D(point.X - 1, point.Y - 1);
        }
        throw new Exception("Unknown direction!");
    }
}
