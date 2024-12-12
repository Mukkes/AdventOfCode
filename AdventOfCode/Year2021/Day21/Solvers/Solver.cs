using AdventOfCode.Year2021.Day21.Models;
using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.Parsers;
using AdventOfCodeLibrary.Solvers;

namespace AdventOfCode.Year2021.Day21.Solvers;

[Solver]
public class Solver : BaseSolver<string[]>
{
    public override object? AnswerPartOne => 678468;

    public override object? AnswerPartTwo => 131180774190079L;

    protected override IInputParser<string[]> InputParser => new StringArrayParser();

    public override object SolvePartOne()
    {
        var players = GetPlayers();
        var dice = new DeterministicDice();
        Play(players, dice);
        var losingPlayer = GetLosingPlayer(players);
        return losingPlayer.Score * dice.Count;
    }

    public override object SolvePartTwo()
    {
        var players = GetPlayers();
        PlayPartTwo(players[0].Position, players[1].Position, 0, 0, 1, 1);
        return universesPlayer1 >= universesPlayer2 ? universesPlayer1 : universesPlayer2;
    }

    private long universesPlayer1 = 0L;
    private long universesPlayer2 = 0L;
    private Dictionary<int, int> Universes = new Dictionary<int, int>()
    {
        { 3, 1 },
        { 4, 3 },
        { 5, 6 },
        { 6, 7 },
        { 7, 6 },
        { 8, 3 },
        { 9, 1 },
    };

    private void PlayPartTwo(int position1, int position2, int score1, int score2, int turn, long universes)
    {
        if (turn == 1)
        {
            if (score2 >= 21)
            {
                universesPlayer2 += universes;
                return;
            }
            for (var i = 3; i <= 9; i++)
            {
                Play1(position1, position2, score1, score2, 2, universes, i);
            }
        }
        else
        {
            if (score1 >= 21)
            {
                universesPlayer1 += universes;
                return;
            }
            for (var i = 3; i <= 9; i++)
            {
                Play2(position1, position2, score1, score2, 1, universes, i);
            }
        }
    }

    private void Play1(int position1, int position2, int score1, int score2, int turn, long universes, int dice)
    {
        var newPosition = position1 + dice;
        if (newPosition > 10)
        {
            newPosition -= 10;
        }
        PlayPartTwo(newPosition, position2, score1 + newPosition, score2, turn, universes * Universes.GetValueOrDefault(dice));
    }

    private void Play2(int position1, int position2, int score1, int score2, int turn, long universes, int dice)
    {
        var newPosition = position2 + dice;
        if (newPosition > 10)
        {
            newPosition -= 10;
        }
        PlayPartTwo(position1, newPosition, score1, score2 + newPosition, turn, universes * Universes.GetValueOrDefault(dice));
    }

    private void Play(List<Player> players, DeterministicDice dice)
    {
        while (true)
        {
            foreach (var player in players)
            {
                var amount = dice.Roll() + dice.Roll() + dice.Roll();
                player.AddPosition(amount);
                player.AddScore();
                if (player.Score >= 1000)
                {
                    return;
                }
            }
        }
    }

    private List<Player> GetPlayers()
    {
        var players = new List<Player>();
        foreach (var row in ParsedInput)
        {
            var playerInfo = row.Split(' ');
            players.Add(new Player(int.Parse(playerInfo[1]), int.Parse(playerInfo[4])));
        }
        return players;
    }

    private Player GetLosingPlayer(List<Player> players)
    {
        foreach (var player in players)
        {
            if (player.Score < 1000)
            {
                return player;
            }
        }
        return new Player(0, 0);
    }
}
