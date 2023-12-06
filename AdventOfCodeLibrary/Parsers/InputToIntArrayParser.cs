namespace AdventOfCodeLibrary.Parsers;

public class InputToIntArrayParser : InputToStringArrayParser, IInputParser<int[]>
{
    public new int[] Parse(string inputFileName)
    {
        var input = base.Parse(inputFileName);
        return Array.ConvertAll(input, int.Parse);
    }
}
