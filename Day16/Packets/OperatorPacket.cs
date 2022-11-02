namespace AdventOfCode2021.Day16.Packets
{
    internal class OperatorPacket : Packet
    {
        internal OperatorPacket(int version, int type) : base(version, type)
        {
            SubPackets = new List<Packet>();
        }

        internal List<Packet> SubPackets { get; set; }

        internal override int SumVersions()
        {
            var sumVersions = Version;
            foreach (var packet in SubPackets)
            {
                sumVersions += packet.SumVersions();
            }
            return sumVersions;
        }

        internal override long EvaluateExpression()
        {

            if (Type == 1)
            {
                long i = 1;
                foreach (var packet in SubPackets)
                {
                    i *= packet.EvaluateExpression();
                }
                return i;
            }
            if (Type == 2)
            {
                return SubPackets.Min(packet => packet.EvaluateExpression());
            }
            if (Type == 3)
            {
                return SubPackets.Max(packet => packet.EvaluateExpression());
            }
            if (Type == 5)
            {
                return SubPackets[0].EvaluateExpression() > SubPackets[1].EvaluateExpression() ? 1 : 0;
            }
            if (Type == 6)
            {
                return SubPackets[0].EvaluateExpression() < SubPackets[1].EvaluateExpression() ? 1 : 0;
            }
            if (Type == 7)
            {
                return SubPackets[0].EvaluateExpression() == SubPackets[1].EvaluateExpression() ? 1 : 0;
            }
            return SubPackets.Sum(packet => packet.EvaluateExpression());
        }
    }
}
