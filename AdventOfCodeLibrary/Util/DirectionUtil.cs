﻿using AdventOfCodeLibrary.Models;

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

    public static Direction GetOppositeDirection(this Direction direction)
    {
        switch (direction)
        {
            case Direction.North:
                return Direction.South;
            case Direction.South:
                return Direction.North;
            case Direction.East:
                return Direction.West;
            case Direction.West:
                return Direction.East;
            case Direction.Northeast:
                return Direction.Southwest;
            case Direction.Southeast:
                return Direction.Northwest;
            case Direction.Southwest:
                return Direction.Northeast;
            case Direction.Northwest:
                return Direction.Southeast;
        }
        throw new Exception();
    }
}
