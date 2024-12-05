namespace AdventOfCode.Year2024.Day05.Models;
public class Manual
{
    public HashSet<(int, int)> Rules { get; set; } = new HashSet<(int, int)>();
    public List<List<int>> Updates { get; set; } = new List<List<int>>();
}
