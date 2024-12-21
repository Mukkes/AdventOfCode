namespace AdventOfCode.Year2024.Day17.Models;
public class ChronospatialComputer
{
    public long RegisterA { get; set; }
    public int RegisterB { get; set; }
    public int RegisterC { get; set; }

    public int[] ProgramArray { get; set; }
    private int InstructionPointer { get; set; }
    public List<long> Output { get; private set; }

    public ChronospatialComputer(ChronospatialComputer chronospatialComputer) :
        this (chronospatialComputer.RegisterA, chronospatialComputer.RegisterB, chronospatialComputer.RegisterC, chronospatialComputer.ProgramArray)
    {
    }

    public ChronospatialComputer(long registerA, int registerB, int registerC, int[] program)
    {
        RegisterA = registerA;
        RegisterB = registerB;
        RegisterC = registerC;
        ProgramArray = program;
        InstructionPointer = 0;
        Output = new List<long>();
    }

    public void Run()
    {
        while (InstructionPointer < ProgramArray.Length)
        {
            switch (ProgramArray[InstructionPointer])
            {
                case 0:
                    RegisterA = RegisterA / (int)Math.Pow(2, GetComboOperand(ProgramArray[InstructionPointer + 1]));
                    InstructionPointer += 2;
                    break;
                case 1:
                    RegisterB = RegisterB ^ ProgramArray[InstructionPointer + 1];
                    InstructionPointer += 2;
                    break;
                case 2:
                    RegisterB = (int)(GetComboOperand(ProgramArray[InstructionPointer + 1]) % 8) & 7;
                    InstructionPointer += 2;
                    break;
                case 3:
                    if (RegisterA != 0)
                    {
                        InstructionPointer = ProgramArray[InstructionPointer + 1];
                    }
                    else
                    {
                        InstructionPointer += 2;
                    }
                    break;
                case 4:
                    RegisterB = RegisterB ^ RegisterC;
                    InstructionPointer += 2;
                    break;
                case 5:
                    Output.Add(GetComboOperand(ProgramArray[InstructionPointer + 1]) % 8);
                    InstructionPointer += 2;
                    break;
                case 6:
                    RegisterB = (int)RegisterA / (int)Math.Pow(2, GetComboOperand(ProgramArray[InstructionPointer + 1]));
                    InstructionPointer += 2;
                    break;
                case 7:
                    RegisterC = (int)RegisterA / (int)Math.Pow(2, GetComboOperand(ProgramArray[InstructionPointer + 1]));
                    InstructionPointer += 2;
                    break;
            }
        }
    }

    public void RunPartTwo()
    {
        while (InstructionPointer < ProgramArray.Length)
        {
            switch (ProgramArray[InstructionPointer])
            {
                case 0:
                    RegisterA = RegisterA / (int)Math.Pow(2, GetComboOperand(ProgramArray[InstructionPointer + 1]));
                    InstructionPointer += 2;
                    break;
                case 1:
                    InstructionPointer += 2;
                    break;
                case 2:
                    InstructionPointer += 2;
                    break;
                case 3:
                    if (RegisterA != 0)
                    {
                        InstructionPointer = ProgramArray[InstructionPointer + 1];
                    }
                    else
                    {
                        InstructionPointer += 2;
                    }
                    break;
                case 4:
                    InstructionPointer += 2;
                    break;
                case 5:
                    Output.Add(GetComboOperand(ProgramArray[InstructionPointer + 1]) % 8);
                    if (Output.Last() != ProgramArray[Output.Count - 1])
                    {
                        return;
                    }
                    InstructionPointer += 2;
                    break;
                case 6:
                    InstructionPointer += 2;
                    break;
                case 7:
                    InstructionPointer += 2;
                    break;
            }
        }
    }

    private long GetComboOperand(int operand)
    {
        switch (operand)
        {
            case 0:
            case 1:
            case 2:
            case 3:
                return operand;
            case 4:
                return RegisterA;
            case 5:
                return RegisterB;
            case 6:
                return RegisterC;
        }
        throw new Exception();
    }

    public string GetOutputAsString()
    {
        return string.Join(",", Output);
    }
}
