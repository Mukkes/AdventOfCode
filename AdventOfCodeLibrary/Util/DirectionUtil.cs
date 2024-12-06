using AdventOfCodeLibrary.Models;

namespace AdventOfCodeLibrary.Util;
public static class DirectionUtil
{
    public static List<Direction> GetAllDirections()
    {
        return new List<Direction>()
        {
            Direction.North,
            Direction.South,
            Direction.East,
            Direction.West,
            Direction.Northeast,
            Direction.Southeast,
            Direction.Southwest,
            Direction.Northwest
        };
    }

    public static List<Direction> GetBasicDirections()
    {
        return new List<Direction>()
        {
            Direction.North,
            Direction.South,
            Direction.East,
            Direction.West,
        };
    }

    public static List<Direction> GetBasicDirectionsClockWise()
    {
        return new List<Direction>()
        {
            Direction.North,
            Direction.East,
            Direction.South,
            Direction.West,
        };
    }
}
