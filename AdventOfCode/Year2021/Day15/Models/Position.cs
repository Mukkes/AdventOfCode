namespace AdventOfCode.Year2021.Day15.Models;
public class Position
{
    public long LowestRisk = 2990;
    public readonly int RiskLevel;
    public List<Position> Neighbors = new List<Position>();
    public readonly int X;
    public readonly int Y;

    public Position(int riskLevel, int x, int y)
    {
        if (riskLevel > 18)
        {
            throw new Exception();
        }
        if (riskLevel > 9)
        {
            RiskLevel = riskLevel - 9;
        }
        else
        {
            RiskLevel = riskLevel;
        }
        X = x;
        Y = y;
    }

    public void FirstCalculateLowestTotalRisk()
    {
        foreach (var neighbor in Neighbors)
        {
            neighbor.CalculateLowestTotalRisk(0);
        }
    }

    public void CalculateLowestTotalRisk(long risk)
    {
        if (risk + RiskLevel >= LowestRisk)
        {
            return;
        }
        LowestRisk = risk + RiskLevel;
        foreach (var neighbor in Neighbors)
        {
            neighbor.CalculateLowestTotalRisk(LowestRisk);
        }
    }
}
