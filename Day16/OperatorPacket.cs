namespace AdventOfCode2021.Day16
{
    internal class OperatorPacket : Packet
    {
        internal OperatorPacket(long version, long type, long lengthType) : base(version, type)
        {
            LengthType = lengthType;
        }

        internal long LengthType { get; private set; }
    }
}
