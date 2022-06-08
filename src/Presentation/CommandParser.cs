using Exo3.Core;

namespace Exo3.Presentation;

public class CommandParser
{
    public Command Parse(string[] args)
    {
        string? filePath = null;
        OperationWrapper? operand = null;
        for (var argIdx = 0; argIdx < args.Length; argIdx++)
        {
            if (args[argIdx] == "-f")
            {
                filePath = args[argIdx + 1];
            }

            if (args[argIdx] == "-o")
            {
                operand = ParseOperand(args[argIdx + 1]);
            }
        }
        if (operand is null || filePath is null)
        {
            throw new ArgumentException("You should specify exactly on file path and one operand");
        }

        return new Command(operand, filePath);
    }

    private OperationWrapper ParseOperand(string arg) => arg switch
    {
        "+" => new OperationWrapper(arg, "addition", new SumOperator()),
        "-" => new OperationWrapper(arg, "subtraction", new SubOperator()),
        "*" =>  new OperationWrapper(arg, "multiplication", new MulOperator()),
        _ => throw new ArgumentException("Operand argument is not handled")
    };
}