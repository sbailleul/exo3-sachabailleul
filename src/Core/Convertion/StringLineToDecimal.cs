namespace Exo3.Core.Convertion;

public class StringLineToDecimal: IDataConverter<string, decimal>
{
    public decimal Convert(string src)
    {
        return decimal.Parse(src);
    }
}