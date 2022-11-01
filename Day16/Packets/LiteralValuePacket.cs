namespace AdventOfCode2021.Day16.Packets
{
    internal class LiteralValuePacket : Packet
    {
        internal LiteralValuePacket(int version, int type, int literalValue) : base(version, type)
        {
            LiteralValue = literalValue;
        }

        internal int LiteralValue { get; private set; }

        internal override int EvaluateExpression()
        {
            return LiteralValue;
        }
    }
}
