using AdventOfCode.Year2021;

namespace AdventOfCode2021Tests
{
    [TestClass]
    public class Day08Tests
    {
        private const int _exampleAnswerPartOne = 26;
        private const int _exampleAnswerPartTwo = 61229;
        private const int _answerPartOne = 493;
        private const int _answerPartTwo = 1010460;

        [TestMethod]
        public void TestExamplePartOne()
        {
            var day8 = new Day8(true);
            Assert.AreEqual(day8.ResultPartOne(), _exampleAnswerPartOne);
        }

        [TestMethod]
        public void TestExamplePartTwo()
        {
            var day8 = new Day8(true);
            Assert.AreEqual(day8.ResultPartTwo(), _exampleAnswerPartTwo);
        }

        [TestMethod]
        public void TestPartOne()
        {
            var day8 = new Day8();
            Assert.AreEqual(day8.ResultPartOne(), _answerPartOne);
        }

        [TestMethod]
        public void TestPartTwo()
        {
            var day8 = new Day8();
            Assert.AreEqual(day8.ResultPartTwo(), _answerPartTwo);
        }
    }
}
