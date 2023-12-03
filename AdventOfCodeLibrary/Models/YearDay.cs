namespace AdventOfCodeLibrary.Models;

public class YearDay
{
    public int Year { get; }
    public int Day { get; }

    public YearDay(int year, int day)
    {
        Year = year;
        Day = day;
    }

    public override bool Equals(object? obj)
    {
        if (obj is YearDay yearDay)
        {
            if (yearDay.Year == Year &&
                yearDay.Day == Day)
            {
                return true;
            }
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Year, Day);
    }
}
