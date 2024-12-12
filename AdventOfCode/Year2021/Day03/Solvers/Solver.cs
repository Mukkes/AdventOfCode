using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.Parsers;
using AdventOfCodeLibrary.Solvers;

namespace AdventOfCode.Year2021.Day03.Solvers;

[Solver]
public class Solver : BaseSolver<string[]>
{
    public override object? AnswerPartOne => 3959450;

    public override object? AnswerPartTwo => 7440311;

    protected override IInputParser<string[]> InputParser => new StringArrayParser();

    public override object SolvePartOne()
    {
        var input = new string[ParsedInput.Length];
        Array.Copy(ParsedInput, input, ParsedInput.Length);
        var stringLength = input[0].Length;
        var x = Math.Pow(2, stringLength) - 1;
        var gammaRating = GetGammaRating(input);
        var epsilonRating = x - gammaRating;
        return gammaRating * (int)epsilonRating;
    }

    private int GetGammaRating(string[] bits)
    {
        var count = 0;
        var stringLenght = bits[0].Length;
        for (int i = 0; i < bits.Length; i++)
        {
            if (Convert.ToBoolean(int.Parse(bits[i][0].ToString())))
            {
                count++;
            }
            bits[i] = bits[i].Substring(1);
        }
        var result = 0;
        if (count > (bits.Length / 2))
        {
            result = Convert.ToInt32(Math.Pow(2, stringLenght - 1));
        }
        if (stringLenght > 1)
        {
            return result + GetGammaRating(bits);
        }
        return result;
    }

    public override object SolvePartTwo()
    {
        return GetOxygenGeneratorRating() * GetCO2ScrubberRating();
    }

    private int GetOxygenGeneratorRating()
    {
        var input = ParsedInput.ToList();
        var byteLength = ParsedInput[0].Length;
        var oxygenGeneratorRating = 0;
        for (int i = 0; i < byteLength; i++)
        {
            var mostCommonValue = GetMostCommonValue(i, input);
            input = GetLinesWithXOnPosition(mostCommonValue, i, input);
            if (input.Count() == 1)
            {
                oxygenGeneratorRating = Convert.ToInt32(input[0], 2);
            }
        }
        return oxygenGeneratorRating;
    }

    private int GetCO2ScrubberRating()
    {
        var input = ParsedInput.ToList();
        var byteLength = ParsedInput[0].Length;
        var co2ScrubberRating = 0;
        for (int i = 0; i < byteLength; i++)
        {
            var mostCommonValue = GetLeastCommonValue(i, input);
            input = GetLinesWithXOnPosition(mostCommonValue, i, input);
            if (input.Count() == 1)
            {
                co2ScrubberRating = Convert.ToInt32(input[0], 2);
            }
        }
        return co2ScrubberRating;
    }

    private char GetMostCommonValue(int position, List<string> input)
    {
        var count = 0;
        foreach (var line in input)
        {
            count += int.Parse(line[position].ToString());
        }
        return count >= (input.Count / 2.0) ? '1' : '0';
    }

    private char GetLeastCommonValue(int position, List<string> input)
    {
        var count = 0;
        foreach (var line in input)
        {
            count += int.Parse(line[position].ToString());
        }
        return count < (input.Count / 2.0) ? '1' : '0';
    }

    private List<string> GetLinesWithXOnPosition(char x, int position, List<string> input)
    {
        var newInput = new List<string>();
        foreach (var line in input)
        {
            if (line[position] == x)
            {
                newInput.Add(line);
            }
        }
        return newInput;
    }
}
