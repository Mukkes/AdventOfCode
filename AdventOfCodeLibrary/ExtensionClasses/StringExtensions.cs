namespace AdventOfCodeLibrary.ExtensionClasses;

public static class StringExtensions
{
    public static int ExtractInteger(this string str)
    {
        var digits = string.Concat(str.Where(char.IsDigit));
        if (!digits.Any())
        {
            return 0;
        }
        return int.Parse(digits);
    }

    public static long ExtractLong(this string str)
    {
        var digits = string.Concat(str.Where(char.IsDigit));
        if (!digits.Any())
        {
            return 0;
        }
        return long.Parse(digits);
    }
}
