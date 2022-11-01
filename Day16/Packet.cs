namespace AdventOfCode2021.Day16
{
    internal abstract class Packet
    {
        public Packet(long version, long type)
        {
            Version = version;
            Type = type;
        }

        internal long Version { get; private set; }

        internal long Type { get; private set; }
    }
}
