namespace AdventOfCode2021.Day16.Packets
{
    internal class OperatorPacket11Bits : OperatorPacket
    {
        internal OperatorPacket11Bits(int version, int type, int numberOfSubPackets) : base(version, type)
        {
            NumberOfSubPackets = numberOfSubPackets;
        }

        internal int NumberOfSubPackets { get; private set; }
    }
}
