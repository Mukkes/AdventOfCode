using AdventOfCode2021.Day16.Packets;
using AdventOfCode2021.Day16.Solvers;

namespace AdventOfCode2021Tests
{
    [TestClass]
    internal class Day16Tests
    {
        [TestMethod]
        public void TestPartOne1()
        {
            var input = "D2FE28";
            var expectedAnswer = 2021;

            var solver = new Solver(input);
            var packet = (LiteralValuePacket)solver.ExtractPacket(solver.Input, out _);

            Assert.AreEqual(expectedAnswer, packet.LiteralValue);
        }

        [TestMethod]
        public void TestPartOne2()
        {
            var input = "38006F45291200";
            var expectedAnswerLiteralValueA = 10;
            var expectedAnswerLiteralValueB = 20;

            var solver = new Solver(input);
            var packet = (OperatorPacket)solver.ExtractPacket(solver.Input, out _);
            var subPacketA = (LiteralValuePacket)packet.SubPackets[0];
            var subPacketB = (LiteralValuePacket)packet.SubPackets[1];

            Assert.AreEqual(expectedAnswerLiteralValueA, subPacketA.LiteralValue);
            Assert.AreEqual(expectedAnswerLiteralValueB, subPacketB.LiteralValue);
        }

        [TestMethod]
        public void TestPartOne3()
        {
            var input = "EE00D40C823060";
            var expectedAnswerLiteralValueA = 1;
            var expectedAnswerLiteralValueB = 2;
            var expectedAnswerLiteralValueC = 3;

            var solver = new Solver(input);
            var packet = (OperatorPacket)solver.ExtractPacket(solver.Input, out _);
            var subPacketA = (LiteralValuePacket)packet.SubPackets[0];
            var subPacketB = (LiteralValuePacket)packet.SubPackets[1];
            var subPacketC = (LiteralValuePacket)packet.SubPackets[2];

            Assert.AreEqual(expectedAnswerLiteralValueA, subPacketA.LiteralValue);
            Assert.AreEqual(expectedAnswerLiteralValueB, subPacketB.LiteralValue);
            Assert.AreEqual(expectedAnswerLiteralValueC, subPacketC.LiteralValue);
        }

        [TestMethod]
        public void TestPartOne4()
        {
            var input = "8A004A801A8002F478";
            var expectedAnswer = 16;

            var solver = new Solver(input);
            var answer = solver.SolvePartOne();

            Assert.AreEqual(expectedAnswer, answer);
        }

        [TestMethod]
        public void TestPartOne5()
        {
            var input = "620080001611562C8802118E34";
            var expectedAnswer = 12;

            var solver = new Solver(input);
            var answer = solver.SolvePartOne();

            Assert.AreEqual(expectedAnswer, answer);
        }

        [TestMethod]
        public void TestPartOne6()
        {
            var input = "C0015000016115A2E0802F182340";
            var expectedAnswer = 23;

            var solver = new Solver(input);
            var answer = solver.SolvePartOne();

            Assert.AreEqual(expectedAnswer, answer);
        }

        [TestMethod]
        public void TestPartOne7()
        {
            var input = "A0016C880162017C3686B18A3D4780";
            var expectedAnswer = 31;

            var solver = new Solver(input);
            var answer = solver.SolvePartOne();

            Assert.AreEqual(expectedAnswer, answer);
        }

        [TestMethod]
        public void TestPartTwo1()
        {
            var input = "C200B40A82";
            var expectedAnswer = 3L;

            var solver = new Solver(input);
            var answer = solver.SolvePartTwo();

            Assert.AreEqual(expectedAnswer, answer);
        }

        [TestMethod]
        public void TestPartTwo2()
        {
            var input = "04005AC33890";
            var expectedAnswer = 54L;

            var solver = new Solver(input);
            var answer = solver.SolvePartTwo();

            Assert.AreEqual(expectedAnswer, answer);
        }

        [TestMethod]
        public void TestPartTwo3()
        {
            var input = "880086C3E88112";
            var expectedAnswer = 7L;

            var solver = new Solver(input);
            var answer = solver.SolvePartTwo();

            Assert.AreEqual(expectedAnswer, answer);
        }

        [TestMethod]
        public void TestPartTwo4()
        {
            var input = "CE00C43D881120";
            var expectedAnswer = 9L;

            var solver = new Solver(input);
            var answer = solver.SolvePartTwo();

            Assert.AreEqual(expectedAnswer, answer);
        }

        [TestMethod]
        public void TestPartTwo5()
        {
            var input = "D8005AC2A8F0";
            var expectedAnswer = 1L;

            var solver = new Solver(input);
            var answer = solver.SolvePartTwo();

            Assert.AreEqual(expectedAnswer, answer);
        }

        [TestMethod]
        public void TestPartTwo6()
        {
            var input = "F600BC2D8F";
            var expectedAnswer = 0L;

            var solver = new Solver(input);
            var answer = solver.SolvePartTwo();

            Assert.AreEqual(expectedAnswer, answer);
        }

        [TestMethod]
        public void TestPartTwo7()
        {
            var input = "9C005AC2F8F0";
            var expectedAnswer = 0L;

            var solver = new Solver(input);
            var answer = solver.SolvePartTwo();

            Assert.AreEqual(expectedAnswer, answer);
        }

        [TestMethod]
        public void TestPartTwo8()
        {
            var input = "9C0141080250320F1802104A08";
            var expectedAnswer = 1L;

            var solver = new Solver(input);
            var answer = solver.SolvePartTwo();

            Assert.AreEqual(expectedAnswer, answer);
        }
    }
}