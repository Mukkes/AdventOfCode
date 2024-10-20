﻿namespace AdventOfCode.Year2021.Day16.Models;
public abstract class Packet
{
    public Packet(int version, int type)
    {
        Version = version;
        Type = type;
    }

    internal int Version { get; private set; }

    internal int Type { get; private set; }

    internal abstract long EvaluateExpression();

    internal virtual int SumVersions()
    {
        return Version;
    }
}
