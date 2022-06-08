namespace Exo3.Core.Convertion;

public interface IDataConverter<TSource, TDestination>
{
    public TDestination Convert(TSource src);
}