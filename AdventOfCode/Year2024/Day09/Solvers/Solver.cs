using AdventOfCodeLibrary.Attributes;
using AdventOfCodeLibrary.Parsers;
using AdventOfCodeLibrary.Solvers;
using System.Drawing;

namespace AdventOfCode.Year2024.Day09.Solvers;

[Solver]
public class Solver : BaseSolver<string>
{
    public override int Year => 2024;

    public override int Day => 9;

    public override object? AnswerPartOne => 6323641412437;

    public override object? AnswerPartTwo => 6351801932670;

    protected override IInputParser<string> InputParser => new VoidParser();

    private const long _freeSpace = -1L;

    public override object SolvePartOne()
    {
        var disk = CreateDisk();
        MoveFileBlocks(disk);
        return CalculateChecksum(disk);
    }

    public override object SolvePartTwo()
    {
        var disk = CreateDisk();
        MoveWholeFile(disk);
        return CalculateChecksum(disk);
    }

    private List<long> CreateDisk()
    {
        var disk = new List<long>();
        var id = 0L;
        var isFile = true;
        foreach (var c in ParsedInput)
        {
            for (var i = 0L; i < (c - '0'); i++)
            {
                if (isFile)
                {
                    disk.Add(id);
                }
                else
                {
                    disk.Add(_freeSpace);
                }
            }
            if (isFile)
            {
                id++;
            }
            isFile = !isFile;
        }
        return disk;
    }

    private void MoveFileBlocks(List<long> disk)
    {
        var newDisk = new List<long>();
        for (var i = 0; i < disk.Count; i++)
        {
            var indexLastFileBlock = disk.FindLastIndex(x => x != _freeSpace);
            var indexFirstFreeSpace = disk.FindIndex(x => x == _freeSpace);
            if (indexFirstFreeSpace > indexLastFileBlock)
            {
                break;
            }
            disk[indexFirstFreeSpace] = disk[indexLastFileBlock];
            disk[indexLastFileBlock] = _freeSpace;
        }
    }

    private long CalculateChecksum(List<long> disk)
    {
        var checksum = 0L;
        for (var i = 0L; i < disk.Count; i++)
        {
            if (disk[(int)i] == _freeSpace)
            {
                continue;
            }
            checksum += disk[(int)i] * i;
        }
        return checksum;
    }

    private void MoveWholeFile(List<long> disk)
    {
        var newDisk = new List<long>();
        var highestId = disk.FindLast(x => x != _freeSpace);
        for (var id = highestId; id >= 0; id--)
        {
            var indexFile = disk.FindIndex(x => x == id);
            var fileSize = disk.Where(x => x == id).Count();
            if (FindFreeBlock(disk, fileSize, out int indexFreeSpace))
            {
                if (indexFreeSpace > indexFile)
                {
                    continue;
                }
                for (var j = 0; j < fileSize; j++)
                {
                    disk[indexFreeSpace + j] = id;
                    disk[indexFile + j] = _freeSpace;
                }
            }
        }
    }

    private bool FindFreeBlock(List<long> disk, int size, out int index)
    {
        index = -1;
        for (var i = 0; i < disk.Count; i++)
        {
            if (disk[i] == _freeSpace)
            {
                if (index == -1)
                {
                    index = i;
                }
                if ((i - index) == (size - 1))
                {
                    return true;
                }
            }
            else
            {
                index = -1;
            }
        }
        return false;
    }
}
