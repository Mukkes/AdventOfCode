namespace AdventOfCode.Year2024.Day17.Models;
public class ChronospatialComputer
{
    public int RegisterA { get; private set; }
    public int RegisterB { get; private set; }
    public int RegisterC { get; private set; }

    private int[] _program;
    private int InstructionPointer { get; set; }
    public List<int> Output { get; private set; }

    public ChronospatialComputer(int registerA, int registerB, int registerC, int[] program)
    {
        RegisterA = registerA;
        RegisterB = registerB;
        RegisterC = registerC;
        _program = program;
        InstructionPointer = 0;
        Output = new List<int>();
    }

    public void Run()
    {
        while (InstructionPointer < _program.Length)
        {
            switch (_program[InstructionPointer])
            {
                case 0:
                    RegisterA = RegisterA / (int)Math.Pow(2, GetComboOperand(_program[InstructionPointer + 1]));
                    InstructionPointer += 2;
                    break;
                case 1:
                    RegisterB = RegisterB ^ _program[InstructionPointer + 1];
                    InstructionPointer += 2;
                    break;
                case 2:
                    RegisterB = (GetComboOperand(_program[InstructionPointer + 1]) % 8) & 7;
                    InstructionPointer += 2;
                    break;
                case 3:
                    if (RegisterA != 0)
                    {
                        InstructionPointer = _program[InstructionPointer + 1];
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
                    Output.Add(GetComboOperand(_program[InstructionPointer + 1]) % 8);
                    InstructionPointer += 2;
                    break;
                case 6:
                    RegisterB = RegisterA / (int)Math.Pow(2, GetComboOperand(_program[InstructionPointer + 1]));
                    InstructionPointer += 2;
                    break;
                case 7:
                    RegisterC = RegisterA / (int)Math.Pow(2, GetComboOperand(_program[InstructionPointer + 1]));
                    InstructionPointer += 2;
                    break;
            }
        }
    }

    private int GetComboOperand(int operand)
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
