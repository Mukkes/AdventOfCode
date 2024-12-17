namespace AdventOfCode.Year2024.Day17.Models;
public class ChronospatialComputer
{
    public int RegisterA { get; private set; }
    public int RegisterB { get; private set; }
    public int RegisterC { get; private set; }

    private int[] Program { get; set; }
    private int InstructionPointer { get; set; }
    public List<int> Output { get; private set; }

    public ChronospatialComputer(int registerA, int registerB, int registerC, int[] program)
    {
        RegisterA = registerA;
        RegisterB = registerB;
        RegisterC = registerC;
        Program = program;
        InstructionPointer = 0;
        Output = new List<int>();
    }

    public void Run()
    {
    }
}
