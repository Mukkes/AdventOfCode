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

    public static int[] ExtractIntArray(this string str, char separator = ',')
    {
        var digits = str.Split(separator);
        var result = new int[digits.Length];
        for (var i = 0; i < digits.Length; i++)
        {
            result[i] = int.Parse(digits[i]);
        }
        return result;
    }

    public static bool IsNullOrEmpty(this string str)
    {
        return string.IsNullOrEmpty(str);
    }
}
