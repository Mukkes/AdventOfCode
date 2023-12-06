namespace AdventOfCode.Year2020.Day02.Models;
public class PasswordPolicy
{
    public PasswordPolicy(int lowest, int highest, char letter)
    {
        _lowest = lowest;
        _highest = highest;
        _letter = letter;
    }

    private int _lowest = int.MinValue;
    public int Lowest
    {
        get => _lowest;
        private set
        {
            if (value > Highest)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }
            _lowest = value;
        }
    }

    private int _highest = int.MaxValue;
    public int Highest
    {
        get => _highest;
        private set
        {
            if (value < Lowest)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }
            _highest = value;
        }
    }

    private char _letter;
    public char Letter
    {
        get => _letter;
        private set => _letter = value;
    }

    public bool IsValidPassword(string password)
    {
        var occurrences = password.Split(Letter).Length - 1;
        return occurrences >= Lowest && occurrences <= Highest;
    }

    public bool IsValidPasswordPartTwo(string password)
    {
        var firstPosition = password[Lowest - 1];
        var secondPosition = password[Highest - 1];
        return firstPosition == Letter ^ secondPosition == Letter;
    }
}
