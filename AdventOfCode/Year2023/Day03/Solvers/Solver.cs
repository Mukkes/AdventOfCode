using AdventOfCode.Year2023.Day03.Models;
using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.ExtensionClasses;
using AdventOfCodeLibrary.Solvers;

namespace AdventOfCode.Year2023.Day03.Solvers;

[Solver]
public class Solver : StringArraySolver
{
    public override int Year => 2023;
    public override int Day => 3;

    public override object? AnswerPartOne => 526404;

    public override object? AnswerPartTwo => 84399773;

    public override object SolvePartOne()
    {
        var sum = 0;
        var lastCharWasDigit = false;
        var stringNumber = string.Empty;
        var hasAdjacentSymbol = false;
        for (var lineIndex = 0; lineIndex < Input.Length; lineIndex++)
        {
            for (var charIndex = 0; charIndex < Input[lineIndex].Length; charIndex++)
            {
                if (Input[lineIndex][charIndex].IsDigit())
                {
                    stringNumber += Input[lineIndex][charIndex];
                    lastCharWasDigit = true;
                    if (!hasAdjacentSymbol)
                    {
                        hasAdjacentSymbol = HasAdjacentSymbol(lineIndex, charIndex);
                    }
                    continue;
                }
                else if (lastCharWasDigit)
                {
                    if (hasAdjacentSymbol)
                    {
                        sum += int.Parse(stringNumber);
                    }
                    lastCharWasDigit = false;
                    stringNumber = string.Empty;
                    hasAdjacentSymbol = false;
                }
            }
        }
        return sum;
    }

    private bool HasAdjacentSymbol(int lineIndex, int charIndex)
    {
        return
            IsSymbol(lineIndex - 1, charIndex) ||
            IsSymbol(lineIndex + 1, charIndex) ||
            IsSymbol(lineIndex, charIndex - 1) ||
            IsSymbol(lineIndex, charIndex + 1) ||
            IsSymbol(lineIndex - 1, charIndex - 1) ||
            IsSymbol(lineIndex - 1, charIndex + 1) ||
            IsSymbol(lineIndex + 1, charIndex - 1) ||
            IsSymbol(lineIndex + 1, charIndex + 1);
    }

    private bool IsSymbol(int lineIndex, int charIndex)
    {
        char c;
        try
        {
            c = Input[lineIndex][charIndex];
        }
        catch
        {
            return false;
        }
        if (c.IsDigit())
        {
            return false;
        }
        if (c == '.')
        {
            return false;
        }
        return true;
    }

    public override object SolvePartTwo()
    {
        var lastCharWasDigit = false;
        var stringNumber = string.Empty;
        var adjacentStar = default(Star);
        var stars = new List<Star>();
        for (var lineIndex = 0; lineIndex < Input.Length; lineIndex++)
        {
            for (var charIndex = 0; charIndex < Input[lineIndex].Length; charIndex++)
            {
                if (Input[lineIndex][charIndex].IsDigit())
                {
                    stringNumber += Input[lineIndex][charIndex];
                    lastCharWasDigit = true;
                    if (adjacentStar == null)
                    {
                        adjacentStar = GetAdjacentStar(lineIndex, charIndex);
                    }
                    continue;
                }
                else if (lastCharWasDigit)
                {
                    if (adjacentStar != null)
                    {
                        var star = stars.SingleOrDefault(star => star.LineIndex == adjacentStar.LineIndex && star.CharIndex == adjacentStar.CharIndex);
                        if (star == null)
                        {
                            stars.Add(adjacentStar);
                            star = adjacentStar;
                        }
                        star.Numbers.Add(int.Parse(stringNumber));
                    }
                    lastCharWasDigit = false;
                    stringNumber = string.Empty;
                    adjacentStar = null;
                }
            }
        }
        var sum = 0;
        foreach (var star in stars)
        {
            if (star.Numbers.Count == 2)
            {
                sum += star.Numbers[0] * star.Numbers[1];
            }
        }
        return sum;
    }

    private Star? GetAdjacentStar(int lineIndex, int charIndex)
    {
        if (GetStar(lineIndex - 1, charIndex) != null)
        {
            return GetStar(lineIndex - 1, charIndex);
        }
        if (GetStar(lineIndex + 1, charIndex) != null)
        {
            return GetStar(lineIndex + 1, charIndex);
        }
        if (GetStar(lineIndex, charIndex - 1) != null)
        {
            return GetStar(lineIndex, charIndex - 1);
        }
        if (GetStar(lineIndex, charIndex + 1) != null)
        {
            return GetStar(lineIndex, charIndex + 1);
        }
        if (GetStar(lineIndex - 1, charIndex - 1) != null)
        {
            return GetStar(lineIndex - 1, charIndex - 1);
        }
        if (GetStar(lineIndex - 1, charIndex + 1) != null)
        {
            return GetStar(lineIndex - 1, charIndex + 1);
        }
        if (GetStar(lineIndex + 1, charIndex - 1) != null)
        {
            return GetStar(lineIndex + 1, charIndex - 1);
        }
        if (GetStar(lineIndex + 1, charIndex + 1) != null)
        {
            return GetStar(lineIndex + 1, charIndex + 1);
        }
        return null;
    }

    private Star? GetStar(int lineIndex, int charIndex)
    {
        char c;
        try
        {
            c = Input[lineIndex][charIndex];
        }
        catch
        {
            return null;
        }
        if (c == '*')
        {
            return new Star(lineIndex, charIndex);
        }
        return null;
    }
}
