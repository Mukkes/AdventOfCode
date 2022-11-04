using AdventOfCode.Year2021;

namespace AdventOfCode2021Tests
{
    [TestClass]
    public class Day09Tests
    {
        private const int _exampleAnswerPartOne = 15;
        private const int _exampleAnswerPartTwo = 1134;
        private const int _answerPartOne = 564;
        private const int _answerPartTwo = 1038240;

        private Day9 _exampleDay = new Day9(true);
        private Day9 _day = new Day9();

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
