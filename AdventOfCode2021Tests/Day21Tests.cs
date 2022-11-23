using AdventOfCode2021.Day21;

namespace AdventOfCode2021Tests
{
    [TestClass]
    public class Day21Tests
    {
        [TestMethod]
        public void PlayerTest1()
        {
            var player = new Player(1, 7);
            var expectedAnswer = 2;
            player.AddPosition(15);
            Assert.AreEqual(expectedAnswer, player.Position);
        }

        [TestMethod]
        public void Test1()
        {
            var input =
                """
                Player 1 starting position: 4
                Player 2 starting position: 8
                """;
            var expectedAnswer = 739785;
            var program = new AdventOfCode2021.Day21.Program(input);
            Assert.AreEqual(expectedAnswer, program.SolvePartOne());
        }
    }
}
