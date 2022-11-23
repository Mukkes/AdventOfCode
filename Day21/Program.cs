using AdventOfCode2021.Day18.Solvers;

namespace AdventOfCode2021.Day21
{
    public class Program : StringArraySolver
    {
        static void Main(string[] args)
        {
            var program = new Program();
            program.PrintResultPartOne();
            program.PrintResultPartTwo();
            Console.ReadKey();
        }

        public Program() : this(null)
        {
        }

        public Program(string? input) : base(input)
        {
        }

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
            return 0;
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
            foreach (var row in Input)
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
}