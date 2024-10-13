namespace AdventOfCode.Year2021.Day13.Models;

internal class Fold
{
    public char Direction { get; private set; }
    public int Position { get; private set; }

    public Fold(char direction, int position)
    {
        Direction = direction;
        Position = position;
    }
}
