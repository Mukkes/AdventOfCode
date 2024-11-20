using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.Parsers;
using AdventOfCodeLibrary.Solvers;
using System.Text.RegularExpressions;

namespace AdventOfCode.Year2021.Day10.Solvers;

[Solver]
public class Solver : BaseSolver<string[]>
{
    public override int Year => 2021;

    public override int Day => 10;

    public override object? AnswerPartOne => 215229;

    public override object? AnswerPartTwo => 1105996483L;

    protected override IInputParser<string[]> InputParser => new StringArrayParser();

    public override object SolvePartOne()
    {
        var result = 0;
        foreach (var input in ParsedInput)
        {
            var stripped = RemoveLegalChunks(input);
            var illegalCharacter = GetFirstIllegalCharacter(stripped);
            if (illegalCharacter.HasValue)
            {
                result += HighScoreIllegalCharacter.GetValueOrDefault(illegalCharacter.Value);
            }
        }
        return result;
    }

    public override object SolvePartTwo()
    {
        var c = 0;
        var scores = new List<long>();
        foreach (var input in ParsedInput)
        {
            var stripped = RemoveLegalChunks(input);
            var illegalCharacter = GetFirstIllegalCharacter(stripped);
            if (!illegalCharacter.HasValue)
            {
                c++;
                var closingCharacters = GetMissingClosingCharacters(stripped);
                scores.Add(GetScoreClosingCharacters(closingCharacters));
            }
        }
        scores.Sort();
        return scores.ToArray()[scores.Count / 2];
    }

    private string RemoveLegalChunks(string input)
    {
        var result = "";
        while (result != input)
        {
            result = input;
            input = Regex.Replace(input, @"(\(\)|\[\]|{}|<>)", "");
        }
        return result;
    }

    private char? GetFirstIllegalCharacter(string input)
    {
        var index = input.IndexOfAny(new char[] { ')', ']', '}', '>' });
        if (index != -1)
        {
            return input[index];
        }
        return null;
    }

    private Dictionary<char, int> HighScoreIllegalCharacter = new Dictionary<char, int>()
    {
        { ')', 3 },
        { ']', 57 },
        { '}', 1197 },
        { '>', 25137 },
    };

    private Dictionary<char, int> ScorePartTwo = new Dictionary<char, int>()
    {
        { ')', 1 },
        { ']', 2 },
        { '}', 3 },
        { '>', 4 },
    };

    private string GetMissingClosingCharacters(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return string.Empty;
        }
        var result = "";
        var index = input.IndexOfAny(new char[] { '(', '[', '{', '<' }, input.Length - 1);
        input += ClosingCharacter.GetValueOrDefault(input[index]);
        result += ClosingCharacter.GetValueOrDefault(input[index]);
        input = RemoveLegalChunks(input);
        result += GetMissingClosingCharacters(input);
        return result;
    }

    private Dictionary<char, char> ClosingCharacter = new Dictionary<char, char>()
    {
        { '(', ')' },
        { '[', ']' },
        { '{', '}' },
        { '<', '>' },
    };

    private long GetScoreClosingCharacters(string closingCharacters)
    {
        var result = 0L;
        foreach (var closingCharacter in closingCharacters)
        {
            result = (result * 5) + ScorePartTwo.GetValueOrDefault(closingCharacter);
        }
        return result;
    }
}
