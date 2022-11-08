using AdventOfCode2021.Day18.Solvers;

namespace AdventOfCode2021Tests
{
    [TestClass]
    public class Day18Tests
    {
        [TestMethod]
        public void TestExplode1()
        {
            var input = "[[[[[9,8],1],2],3],4]";
            var expectedAnswer = "[[[[0,9],2],3],4]";

            var solver = new Solver(input);
            var pair = solver.Input[0];
            pair.Explode();

            Assert.AreEqual(expectedAnswer, pair.ToString());
        }

        [TestMethod]
        public void TestExplode2()
        {
            var input = "[[3,[2,[1,[7,3]]]],[6,[5,[4,[3,2]]]]]";
            var expectedAnswer = "[[3,[2,[8,0]]],[9,[5,[4,[3,2]]]]]";

            var solver = new Solver(input);
            var pair = solver.Input[0];
            pair.Explode();

            Assert.AreEqual(expectedAnswer, pair.ToString());
        }

        [TestMethod]
        public void TestExplode3()
        {
            var input = "[[3,[2,[8,0]]],[9,[5,[4,[3,2]]]]]";
            var expectedAnswer = "[[3,[2,[8,0]]],[9,[5,[7,0]]]]";

            var solver = new Solver(input);
            var pair = solver.Input[0];
            pair.Explode();

            Assert.AreEqual(expectedAnswer, pair.ToString());
        }

        [TestMethod]
        public void TestExplode4()
        {
            var input = "[[[[4,0],[5,0]],[[[4,5],[2,6]],[9,5]]],[7,[[[3,7],[4,3]],[[6,3],[8,8]]]]]";
            var expectedAnswer = "[[[[4,0],[5,4]],[[0,[7,6]],[9,5]]],[7,[[[3,7],[4,3]],[[6,3],[8,8]]]]]";

            var solver = new Solver(input);
            var pair = solver.Input[0];
            pair.Explode();

            Assert.AreEqual(expectedAnswer, pair.ToString());
        }

        [TestMethod]
        public void TestSplit1()
        {
            var input = "[[[[[4,3],4],4],[7,[[8,4],9]]],[1,1]]";
            var expectedAnswer = "[[[[0,7],4],[[7,8],[0,13]]],[1,1]]";

            var solver = new Solver(input);
            var pair = solver.Input[0];
            pair.Explode();
            pair.Explode();
            pair.Split();

            Assert.AreEqual(expectedAnswer, pair.ToString());
        }

        [TestMethod]
        public void TestSplit2()
        {
            var input = "[[[[[4,3],4],4],[7,[[8,4],9]]],[1,1]]";
            var expectedAnswer = "[[[[0,7],4],[[7,8],[0,[6,7]]]],[1,1]]";

            var solver = new Solver(input);
            var pair = solver.Input[0];
            pair.Explode();
            pair.Explode();
            pair.Split();
            pair.Split();

            Assert.AreEqual(expectedAnswer, pair.ToString());
        }

        [TestMethod]
        public void Test1()
        {
            var input = "[[[[[4,3],4],4],[7,[[8,4],9]]],[1,1]]";
            var expectedAnswer = "[[[[0,7],4],[[7,8],[6,0]]],[8,1]]";

            var solver = new Solver(input);
            var pair = solver.Input[0];
            pair.Explode();
            pair.Explode();
            pair.Split();
            pair.Split();
            pair.Explode();

            Assert.AreEqual(expectedAnswer, pair.ToString());
        }

        [TestMethod]
        public void Test2()
        {
            var input = @"[[[[4,3],4],4],[7,[[8,4],9]]]
[1,1]";
            var expectedAnswer = "[[[[0,7],4],[[7,8],[6,0]]],[8,1]]";

            var solver = new Solver(input);
            var answer = solver.AddPairs(solver.Input);

            Assert.AreEqual(expectedAnswer, answer.ToString());
        }

        [TestMethod]
        public void Test3()
        {
            var input = @"[1,1]
[2,2]
[3,3]
[4,4]";
            var expectedAnswer = "[[[[1,1],[2,2]],[3,3]],[4,4]]";

            var solver = new Solver(input);
            var answer = solver.AddPairs(solver.Input);

            Assert.AreEqual(expectedAnswer, answer.ToString());
        }

        [TestMethod]
        public void Test4()
        {
            var input = @"[1,1]
[2,2]
[3,3]
[4,4]
[5,5]";
            var expectedAnswer = "[[[[3,0],[5,3]],[4,4]],[5,5]]";

            var solver = new Solver(input);
            var answer = solver.AddPairs(solver.Input);

            Assert.AreEqual(expectedAnswer, answer.ToString());
        }

        [TestMethod]
        public void Test5()
        {
            var input = @"[1,1]
[2,2]
[3,3]
[4,4]
[5,5]
[6,6]";
            var expectedAnswer = "[[[[5,0],[7,4]],[5,5]],[6,6]]";

            var solver = new Solver(input);
            var answer = solver.AddPairs(solver.Input);

            Assert.AreEqual(expectedAnswer, answer.ToString());
        }

        [TestMethod]
        public void Test6()
        {
            var input = @"[[[0,[4,5]],[0,0]],[[[4,5],[2,6]],[9,5]]]
[7,[[[3,7],[4,3]],[[6,3],[8,8]]]]
[[2,[[0,8],[3,4]]],[[[6,7],1],[7,[1,6]]]]
[[[[2,4],7],[6,[0,5]]],[[[6,8],[2,8]],[[2,1],[4,5]]]]
[7,[5,[[3,8],[1,4]]]]
[[2,[2,2]],[8,[8,1]]]
[2,9]
[1,[[[9,3],9],[[9,0],[0,7]]]]
[[[5,[7,4]],7],1]
[[[[4,2],2],6],[8,7]]";
            var expectedAnswer = "[[[[8,7],[7,7]],[[8,6],[7,7]]],[[[0,7],[6,6]],[8,7]]]";

            var solver = new Solver(input);
            var answer = solver.AddPairs(solver.Input);

            Assert.AreEqual(expectedAnswer, answer.ToString());
        }

        [TestMethod]
        public void TestPartOne1()
        {
            var input = "[[1,2],[[3,4],5]]";
            var expectedAnswer = 143L;

            var solver = new Solver(input);
            Assert.AreEqual(expectedAnswer, solver.SolvePartOne());
        }

        [TestMethod]
        public void TestPartOne2()
        {
            var input = @"[[[0,[5,8]],[[1,7],[9,6]]],[[4,[1,2]],[[1,4],2]]]
[[[5,[2,8]],4],[5,[[9,9],0]]]
[6,[[[6,2],[5,6]],[[7,6],[4,7]]]]
[[[6,[0,7]],[0,9]],[4,[9,[9,0]]]]
[[[7,[6,4]],[3,[1,3]]],[[[5,5],1],9]]
[[6,[[7,3],[3,2]]],[[[3,8],[5,7]],4]]
[[[[5,4],[7,7]],8],[[8,3],8]]
[[9,3],[[9,9],[6,[4,9]]]]
[[2,[[7,7],7]],[[5,8],[[9,3],[0,2]]]]
[[[[5,2],5],[8,[3,7]]],[[5,[7,5]],[4,4]]]";
            var expectedAnswer = 4140L;

            var solver = new Solver(input);
            Assert.AreEqual(expectedAnswer, solver.SolvePartOne());
        }
    }
}