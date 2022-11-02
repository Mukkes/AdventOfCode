using AdventOfCode2021.Day16.Packets;
using AdventOfCode2021.Day16.Parsers;

namespace AdventOfCode2021.Day16.Solvers
{
    internal class Solver : StringSolver<HexadecimalToBinaryParser>
    {
        internal Solver() : base() { }
        internal Solver(string input) : base(input)
        {
            UseExampleInput = false;
        }

        internal override object SolvePartOne()
        {
            var packet = ExtractPacket(Input, out _);
            return packet.SumVersions();
        }

        internal override object SolvePartTwo()
        {
            var packet = ExtractPacket(Input, out _);
            return packet.EvaluateExpression();
        }

        private int BinaryToInt(char bit)
        {
            return BinaryToInt(bit.ToString());
        }

        private int BinaryToInt(string bits)
        {
            var i = Convert.ToInt64(bits, 2);
            if (i > int.MaxValue)
            {
                throw new Exception();
            }
            return (int)i;
        }

        private long BinaryToLong(string bits)
        {
            return Convert.ToInt64(bits, 2);
        }

        internal Packet ExtractPacket(string bits, out string remainingBits)
        {
            var version = BinaryToInt(bits[0..3]);
            var type = BinaryToInt(bits[3..6]);
            if (type == 4)
            {
                var literalValue = ExtractLiteralValue(bits[6..], out remainingBits);
                return new LiteralValuePacket(version, type, literalValue);
            }
            var lengthType = BinaryToInt(bits[6]);
            if (lengthType == 0)
            {
                var totalLength = BinaryToInt(bits[7..22]);
                var packet15Bits = new OperatorPacket(version, type);
                packet15Bits.SubPackets = ExtractSubPackets15Bits(totalLength, bits[22..], out remainingBits);
                return packet15Bits;
            }
            var numberOfSubPackets = BinaryToInt(bits[7..18]);
            var packet11Bits = new OperatorPacket(version, type);
            packet11Bits.SubPackets = ExtractSubPackets11Bits(numberOfSubPackets, bits[18..], out remainingBits);
            return packet11Bits;
        }

        private long ExtractLiteralValue(string bits, out string remainingBits)
        {
            string binaryLiteralValue = ExtractBinaryLiteralValue(bits, out remainingBits);
            return BinaryToLong(binaryLiteralValue);
        }

        private string ExtractBinaryLiteralValue(string bits, out string remainingBits)
        {
            var first = BinaryToInt(bits[0]);
            if (first == 1)
            {
                return bits[1..5] + ExtractBinaryLiteralValue(bits[5..], out remainingBits);
            }
            if (bits.Length > 5)
            {
                remainingBits = bits[5..];
                return bits[1..5];
            }
            remainingBits = string.Empty;
            return bits[1..5];
        }

        private List<Packet> ExtractSubPackets15Bits(int totalLength, string bits, out string remainingBits)
        {
            var packets = new List<Packet>();
            remainingBits = bits[totalLength..];
            bits = bits[0..totalLength];
            while ((bits.Length > 0) && bits.Contains('1'))
            {
                packets.Add(ExtractPacket(bits, out bits));
            }
            return packets;
        }

        private List<Packet> ExtractSubPackets11Bits(int numberOfSubPackets, string bits, out string remainingBits)
        {
            var packets = new List<Packet>();
            for (var i = 0; i < numberOfSubPackets; i++)
            {
                packets.Add(ExtractPacket(bits, out bits));
            }
            remainingBits = bits;
            return packets;
        }
    }
}
