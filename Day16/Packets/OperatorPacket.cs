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

        internal override int EvaluateExpression()
        {
            throw new NotImplementedException();
        }
    }
}
