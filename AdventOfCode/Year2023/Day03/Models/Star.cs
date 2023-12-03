namespace AdventOfCode.Year2023.Day03.Models;

public class Star
{
    public int LineIndex { get; }
    public int CharIndex { get; }
    public List<int> Numbers { get; } = new List<int>();

    public Star(int lineIndex, int charIndex)
    {
        LineIndex = lineIndex;
        CharIndex = charIndex;
    }
}
