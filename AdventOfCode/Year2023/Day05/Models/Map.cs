namespace AdventOfCode.Year2023.Day05.Models;
public class Map
{
    public List<long> Destinations { get; set; } = new List<long>();
    public List<long> Sources { get; set; } = new List<long>();
    public List<long> Ranges { get; set; } = new List<long>();

    public long Convert(long number)
    {
        for (int i = 0; i < Sources.Count; i++)
        {
            if (number >= Sources[i] && number <= Sources[i] + Ranges[i])
            {
                return number - Sources[i] + Destinations[i];
            }
        }
        return number;
    }

    public long ConvertBack(long number)
    {
        for (int i = 0; i < Sources.Count; i++)
        {
            if (number >= Destinations[i] && number <= Destinations[i] + Ranges[i])
            {
                return number - Destinations[i] + Sources[i];
            }
        }
        return number;
    }
}
