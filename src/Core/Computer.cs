using System.Globalization;
using System.Runtime.Intrinsics;
using Exo3.Core.Convertion;
using Exo3.Core.DataPrint;
using Exo3.Core.DataRead;
using Exo3.Infrastructure;

namespace Exo3.Core;

public class Computer
{
    private readonly IDataReader _dataReader;
    private readonly IDataPrinter _dataPrinter;
    private readonly OperationWrapper _operation;
    private readonly StringLineToDecimal _converter;

    public Computer(IDataReader dataReader, IDataPrinter dataPrinter, OperationWrapper operation)
    {
        _dataReader = dataReader;
        _dataPrinter = dataPrinter;
        _operation = operation;
        _converter = new StringLineToDecimal();
    }

    public async Task ComputeAsync()
    {
        var valuesToCompute = (await _dataReader.ReadContentAsync(_converter)).ToArray();
        decimal result = 0;
        for (var i = 0; i < valuesToCompute.Length; i++)
        {
            if (i == 0)
            {
                result = valuesToCompute[i];
                _dataPrinter.Print(result.ToString(CultureInfo.InvariantCulture));
            }
            else
            {
                result = _operation.Compute(result, valuesToCompute[i]);
                _dataPrinter.Print($"{_operation.Token}{valuesToCompute[i]} (={result})");
            }
        }
        _dataPrinter.Print($"total = {result} ({_operation.Name})");
    }
}