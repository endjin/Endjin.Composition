namespace Endjin.Core.Composition.Contracts
{
    public interface IFactory<T>
    {
        T Create();
    }
}