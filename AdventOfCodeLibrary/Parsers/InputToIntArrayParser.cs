namespace AdventOfCodeLibrary.Parsers;

public class InputToIntArrayParser : InputToStringArrayParser, IInputParser<int[]>
{
    public new int[] Parse(string input)
    {
        return Array.ConvertAll(base.Parse(input), int.Parse);
    }
}
