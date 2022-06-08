using Exo3.Core.Convertion;

namespace Exo3.Core.DataRead;

public interface IDataReader
{
    Task<IEnumerable<TDestination>> ReadContentAsync<TDestination>(
        IDataConverter<string, TDestination> converter);
}