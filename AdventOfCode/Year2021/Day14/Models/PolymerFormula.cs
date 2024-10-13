namespace AdventOfCode.Year2021.Day14.Models;
public class PolymerFormula
{
    internal List<char> Template { get; set; } = new List<char>();
    internal Dictionary<string, string> Rules { get; } = new Dictionary<string, string>();
}
