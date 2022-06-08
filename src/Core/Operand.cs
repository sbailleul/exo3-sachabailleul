namespace Exo3.Core;

public interface IOperation
{
    public decimal Compute(decimal leftValue, decimal rightValue);
}

public class OperationWrapper : IOperation
{
    public string Token { get; }
    public string Name { get; }
    private readonly IOperation _operation;

    public OperationWrapper(string token,string name, IOperation operation)
    {
        Token = token;
        Name = name;
        _operation = operation;
    }

    public decimal Compute(decimal leftValue, decimal rightValue) => _operation.Compute(leftValue, rightValue);
}

public class SumOperator : IOperation
{
    public decimal Compute(decimal leftValue, decimal rightValue)
    {
        return leftValue + rightValue;
    }
}

public class MulOperator : IOperation
{
    public decimal Compute(decimal leftValue, decimal rightValue)
    {
        return leftValue * rightValue;
    }
}

public class SubOperator : IOperation
{
    public decimal Compute(decimal leftValue, decimal rightValue)
    {
        return leftValue - rightValue;
    }
}