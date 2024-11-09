namespace AdventOfCode.Year2021.Day21.Models;
public class Player
{
    private readonly int _id;

    public Player(int id, int position)
    {
        _id = id;
        Position = position;
        Score = 0;
    }

    public int Position { get; private set; }

    public int Score { get; set; }

    public void AddPosition(int amount)
    {
        Position += amount;
        while (Position > 10)
        {
            Position -= 10;
        }
    }

    public void AddScore()
    {
        Score += Position;
    }

    public override string ToString()
    {
        return "Player: " + _id + " position: " + Position + " score: " + Score;
    }
}
