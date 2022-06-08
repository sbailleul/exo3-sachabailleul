using Exo3.Core.DataPrint;

namespace Exo3.Presentation;

public class ConsolePrinter: IDataPrinter
{
    public void Print(string contentToPrint)
    {
        Console.WriteLine(contentToPrint);
    }
}