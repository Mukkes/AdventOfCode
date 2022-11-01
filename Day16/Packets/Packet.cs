namespace AdventOfCode2021.Day16.Packets
{
    internal abstract class Packet
    {
        public Packet(int version, int type)
        {
            Version = version;
            Type = type;
        }

        internal int Version { get; private set; }

        internal int Type { get; private set; }

        internal abstract int EvaluateExpression();

        internal virtual int SumVersions()
        {
            return Version;
        }
    }
}
