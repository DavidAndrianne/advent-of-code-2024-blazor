using System.ComponentModel;
using System.Text;
using AoC2024.Blazor.Extensions;

namespace AoC2024.Blazor.Models;

public class Cpu(long registryA, long registryB, long registryC)
{
    public long RegistryA { get; set; } = registryA;
    public long RegistryB { get; set; } = registryB;
    public long RegistryC { get; set; } = registryC;

    public long[] ExecuteProgram(int[] instructions, bool matchOutputToProgram = false)
    {
        var index = 0;
        List<long> output = new();
        while (index+1 < instructions.Length)
        {
            int opCode = instructions[index];
            int literalOperand = instructions[index + 1];
            var result = Compute(opCode, literalOperand);
            output.AddRange(result);

            if (matchOutputToProgram && result.Any() && !AreEquivalent(instructions, output))
                break; // bail: not matching anyway

            index+=2;
            if (opCode == OperationType.JumpIfNotZero.OperationCode && RegistryA != 0) index = literalOperand;
        }
        return output.ToArray();
    }

    public long BitwiseXor(long x, long y)
    {
        var baseCount = 2;
        var (binary1, binary2) = PadBinaries(x.IntToStringFast(baseCount), y.IntToStringFast(baseCount));

        StringBuilder sb = new();
        for (var i = 0; i < binary1.Length; i++)
        {
            char[] characters = [binary1[i], binary2[i]];
            var hasOneTrue = characters.Count(c => c == '1') == 1;
            sb.Append(hasOneTrue ? '1' : '0');
        }
        
        return Convert.ToInt64(sb.ToString(), baseCount);
    }
    
    public int DivideRegistryABy(long param) => (int)(RegistryA / Math.Pow(2, param));

    private bool AreEquivalent(int[] instructions, List<long> results)
        => !results.Where((t, i) => t != instructions[i]).Any();

    private IEnumerable<long> Compute(int opcode, int literalOperand)
    {
        var operation = OperationType.Parse(opcode);
        var parameter = operation.IsRequiringComboOperand ? GetComboOperand(literalOperand) : literalOperand;
        return operation.Operation(this, parameter);
    }

    private long GetComboOperand(int literalOperand)
        => literalOperand <= 3
            ? literalOperand
            : literalOperand == 4
                ? RegistryA
                : literalOperand == 5
                    ? RegistryB
                    : literalOperand == 6
                        ? RegistryC
                        : throw new InvalidEnumArgumentException(nameof(literalOperand));

    private (string, string) PadBinaries(string value1, string value2)
        => value1.Length > value2.Length 
            // Pad 1st value with leading zeroes
            ? (value1, new string('0', value1.Length - value2.Length) + value2)
            // Pad 2nd value with leading zeroes (or empty string if equal)
            : (new string('0', value2.Length - value1.Length) + value1, value2);
}

public class OperationType(int operationCode, bool isRequiringComboOperand, Func<Cpu, long, long[]> operation)
{
    public int OperationCode { get; } = operationCode;
    public bool IsRequiringComboOperand { get; } = isRequiringComboOperand;
    public Func<Cpu, long, long[]> Operation { get; } = operation;
    
    public static OperationType DivideABy = new(0, true, (cpu, param) =>
    {
        cpu.RegistryA = cpu.DivideRegistryABy(param);
        return [];
    });
    public static OperationType DivideBBy = new(6, true, (cpu, param) =>
    {
        cpu.RegistryB = cpu.DivideRegistryABy(param);
        return [];
    });
    public static OperationType DivideCBy = new(7, true, (cpu, param) =>
    {
        cpu.RegistryC = cpu.DivideRegistryABy(param);
        return [];
    });

    public static OperationType BitwiseXorBBy = new(1, false, (cpu, param) =>
    {
        cpu.RegistryB = cpu.BitwiseXor(cpu.RegistryB, param);
        return [];
    });
    
    public static OperationType BitwiseXorBC = new(4, false, (cpu, _) =>
    {
        cpu.RegistryB = cpu.BitwiseXor(cpu.RegistryB, cpu.RegistryC);
        return [];
    });
    
    public static OperationType StoreB = new(2, true, (cpu, param) =>
    {
        cpu.RegistryB = param % 8;
        return [];
    });
    
    public static OperationType Out = new(5, true, (_, param) => [param % 8]);
    
    public static OperationType JumpIfNotZero = new(3, false, (_, _) => []);
    
    public static OperationType[] All = ((OperationType[])[DivideABy, DivideBBy, DivideCBy, BitwiseXorBBy, BitwiseXorBC, StoreB, Out, JumpIfNotZero])
        .OrderBy(x => x.OperationCode)
        .ToArray();
    
    public static OperationType Parse(int opCode) => All[opCode];
}