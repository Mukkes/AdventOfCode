namespace AdventOfCode2021.Day16
{
    internal class PacketParser
    {
        internal static List<Packet> Parse(string input)
        {
            var packets = new List<Packet>();
            var binary = HexToBinary(input);
            while ((binary.Length > 0) && binary.Contains('1'))
            {
                var result = CreatePacket(binary);
                packets.Add(result.packet);
                binary = result.remainingBinary;
            }
            return packets;
        }

        private static string HexToBinary(string input)
        {
            var binary = string.Empty;
            for (int i = 0; i < input.Length; i++)
            {
                binary += Convert.ToString(Convert.ToInt32(input[i].ToString(), 16), 2).PadLeft(4, '0');
            }
            return binary;
        }

        private static (Packet packet, string remainingBinary) CreatePacket(string binary)
        {
            var version = BinaryToLong(binary[0..3]);
            var type = BinaryToLong(binary[3..6]);
            if (type == 4)
            {
                var result = CreateBinaryLiteralValue(binary[6..]);
                var value = BinaryToLong(result.binaryLiteralValue);
                return (new LiteralValuePacket(version, type), result.remainingBinary);
            }
            var lengthType = Convert.ToInt32(binary[6..7], 2);
            if (lengthType == 0)
            {
                var totalLengthInBits = BinaryToLong(binary[7..22]);
                //var bitsSubPackets = binary[22..(22 + totalLengthInBits)];
                return (new OperatorPacket(version, type, lengthType), binary[22..]);
                //return (new OperatorPacket(version, type, lengthType), binary[(22 + totalLengthInBits)..]);
            }
            var numberOfSubPackets = BinaryToLong(binary[7..18]);
            return (new OperatorPacket(version, type, lengthType), binary[18..]);
        }

        private static long BinaryToLong(string binary)
        {
            return Convert.ToInt64(binary, 2);
        }

        private static (string binaryLiteralValue, string remainingBinary) CreateBinaryLiteralValue(string binary)
        {
            var first = BinaryToLong(binary[0..1]);
            if (first == 1)
            {
                var result = CreateBinaryLiteralValue(binary[5..]);
                var binaryLiteralValue = binary[1..5] + result.binaryLiteralValue;
                return (binaryLiteralValue, result.remainingBinary);
            }
            if (binary.Length > 5)
            {
                return (binary[1..5], binary[5..]);
            }
            return (binary[1..5], string.Empty);
        }
    }
}
