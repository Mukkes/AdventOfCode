namespace AdventOfCode2021.Day16.Packets
{
    internal class OperatorPacket15Bits : OperatorPacket
    {
        internal OperatorPacket15Bits(int version, int type, int totalLength) : base(version, type)
        {
            TotalLength = totalLength;
        }

        internal int TotalLength { get; private set; }
    }
}
