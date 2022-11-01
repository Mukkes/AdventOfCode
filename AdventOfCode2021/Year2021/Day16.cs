using AdventOfCode.InputParser;
using System;
using System.Collections.Generic;

namespace AdventOfCode.Year2021
{
    public class Day16 : PuzzleSolution<string, long>
    {
        public Day16() : this(true) { }
        public Day16(bool useExampleInput) : base(2021, 16, useExampleInput)
        {
            InputParser = new SingleLineToStringParser(InputFile);
        }

        public override long ResultPartOne()
        {
            var binary = HexToBinary(Input);
            var packet = CreatePacket(binary);
            return 0;
        }

        public override long ResultPartTwo()
        {
            return 0;
        }

        private string HexToBinary(string input)
        {
            var binary = string.Empty;
            for (int i = 0; i < input.Length; i++)
            {
                binary += Convert.ToString(Convert.ToInt32(input[i].ToString(), 16), 2).PadLeft(4, '0');
            }
            return binary;
        }

        private Packet CreatePacket(string binary)
        {
            var version = Convert.ToInt32(binary[0..3], 2);
            var id = Convert.ToInt32(binary[3..6], 2);
            var packet = new Packet(version, id);
            if (packet.IsLiteral)
            {
                packet.LiteralValue = GetLiteralValue(binary[6..]);
            }
            else
            {
                packet.SubPackets = GetSubPackets(binary[6..]);
            }
            return packet;
        }

        private int SetLiteralValueAndReturnRest(packetstring binary)
        {
            var value = string.Empty;
            while (binary[0] != '0')
            {
                value += binary[1..5];
                binary = binary[5..];
            }
            value += binary[1..5];
            return Convert.ToInt32(value, 2);
        }

        private List<Packet> GetSubPackets(string binary)
        {
            var subPackets = new List<Packet>();
            if (binary[0] != '0')
            {

            }
        }
    }

    class Packet
    {
        public readonly int Version;
        public readonly int Id;
        public bool IsLiteral => Id == 4;
        public int LiteralValue { get; set; }
        public List<Packet> SubPackets { get; set; }

        public Packet(int version, int id)
        {
            Version = version;
            Id = id;
        }
    }
}
