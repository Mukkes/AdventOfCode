using AdventOfCode.Year2021;

namespace AdventOfCode2021Tests
{
    [TestClass]
    public class Day10Tests
    {
        private const long _exampleAnswerPartOne = 26397;
        private const long _exampleAnswerPartTwo = 288957;
        private const long _answerPartOne = 215229;
        private const long _answerPartTwo = 1105996483;

        private Day10 _exampleDay = new Day10(true);
        private Day10 _day = new Day10();

        [TestMethod]
        public void TestExamplePartOne()
        {
            Assert.AreEqual(_exampleDay.ResultPartOne(), _exampleAnswerPartOne);
        }

        [TestMethod]
        public void TestExamplePartTwo()
        {
            Assert.AreEqual(_exampleDay.ResultPartTwo(), _exampleAnswerPartTwo);
        }

        [TestMethod]
        public void TestPartOne()
        {
            Assert.AreEqual(_day.ResultPartOne(), _answerPartOne);
        }

        [TestMethod]
        public void TestPartTwo()
        {
            Assert.AreEqual(_day.ResultPartTwo(), _answerPartTwo);
        }
    }
}
