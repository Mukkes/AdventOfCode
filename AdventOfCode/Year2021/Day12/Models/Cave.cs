namespace AdventOfCode.Year2021.Day12.Models;

internal class Cave
{
    public readonly string name;
    public List<Cave> Paths { get; set; } = new List<Cave>();
    public bool IsBig => name.All(char.IsUpper);

    public Cave(string name)
    {
        this.name = name;
    }
}
