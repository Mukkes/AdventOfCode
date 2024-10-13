using AdventOfCodeLibrary.Parsers;

namespace AdventOfCode.Year2021.Day16.Parsers;
internal class Parser : IInputParser<string>
{
    public string Parse(string input)
    {
        var binary = string.Empty;
        for (int i = 0; i < input.Length; i++)
        {
            binary += Convert.ToString(Convert.ToInt32(input[i].ToString(), 16), 2).PadLeft(4, '0');
        }
        return binary;
    }
}
