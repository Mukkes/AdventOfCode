namespace AdventOfCode.Year2021.Day16.Models;
internal class LiteralValuePacket : Packet
{
    internal LiteralValuePacket(int version, int type, long literalValue) : base(version, type)
    {
        LiteralValue = literalValue;
    }

    internal long LiteralValue { get; private set; }

    internal override long EvaluateExpression()
    {
        return LiteralValue;
    }
}
