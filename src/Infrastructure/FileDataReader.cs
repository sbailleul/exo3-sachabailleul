using Exo3.Core.Convertion;
using Exo3.Core.DataRead;

namespace Exo3.Infrastructure;

public class FileDataReader : IDataReader
{
    private readonly string _srcFilePath;

    public FileDataReader(string srcFilePath)
    {
        _srcFilePath = srcFilePath;
    }

    public async Task<IEnumerable<TDestination>> ReadContentAsync<TDestination>(
        IDataConverter<string, TDestination> converter)
    {
        using var srcFileReader = File.OpenText(_srcFilePath);
        var fileText = await srcFileReader.ReadToEndAsync();
        return fileText
            .Split(new[] {Environment.NewLine}, StringSplitOptions.None)
            .Select(converter.Convert);
    }
}