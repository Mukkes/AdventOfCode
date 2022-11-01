using AdventOfCode2021.Day16.Packets;
using AdventOfCode2021.Day16.Parsers;

namespace AdventOfCode2021.Day16.Solvers
{
    internal class Solver : StringSolver<HexadecimalToBinaryParser>
    {
        internal Solver()
        {
            UseExampleInput = false;
        }

        protected override object SolvePartOne()
        {
            var packet = ExtractPackets(Input).First();
            return packet.SumVersions();
        }

        protected override object SolvePartTwo()
        {
            return 0;
        }

        private int BinaryToInt(char bit)
        {
            return BinaryToInt(bit.ToString());
        }

        private int BinaryToInt(string bits)
        {
            return (int)Convert.ToInt64(bits, 2);
        }

        private List<Packet> ExtractPackets(string bits)
        {
            var packets = new List<Packet>();
            while ((bits.Length > 0) && bits.Contains('1'))
            {
                var packet = ExtractPacket(bits, out bits);
                if (packet is OperatorPacket15Bits operatorPacket15Bits)
                {
                    operatorPacket15Bits.SubPackets = ExtractSubPackets15Bits(operatorPacket15Bits.TotalLength, bits, out bits);
                }
                else if (packet is OperatorPacket11Bits operatorPacket11Bits)
                {
                    operatorPacket11Bits.SubPackets = ExtractSubPackets11Bits(operatorPacket11Bits.NumberOfSubPackets, bits, out bits);
                }
                packets.Add(packet);
            }
            return packets;
        }

        private Packet ExtractPacket(string bits, out string remainingBits)
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
                remainingBits = bits[22..];
                return new OperatorPacket15Bits(version, type, totalLength);
            }
            var numberOfSubPackets = BinaryToInt(bits[7..18]);
            remainingBits = bits[18..];
            return new OperatorPacket11Bits(version, type, numberOfSubPackets);
        }

        private int ExtractLiteralValue(string bits, out string remainingBits)
        {
            string binaryLiteralValue = ExtractBinaryLiteralValue(bits, out remainingBits);
            return BinaryToInt(binaryLiteralValue);
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
            remainingBits = bits[totalLength..];
            return ExtractPackets(bits[0..totalLength]);
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
