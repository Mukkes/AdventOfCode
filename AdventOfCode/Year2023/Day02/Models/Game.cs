namespace AdventOfCode.Year2023.Day02.Models;

public class Game
{
    public int Id { get; }
    public int MaxBlue { get; private set; } = int.MinValue;
    public int MaxGreen { get; private set; } = int.MinValue;
    public int MaxRed { get; private set; } = int.MinValue;

    public readonly List<Set> Sets = new List<Set>();

    public Game(int id)
    {
        Id = id;
    }

    public void AddSet(int blue, int green, int red)
    {
        Sets.Add(new Set(blue, green, red));
        if (blue > MaxBlue)
        {
            MaxBlue = blue;
        }
        if (green > MaxGreen)
        {
            MaxGreen = green;
        }
        if (red > MaxRed)
        {
            MaxRed = red;
        }
    }
}
