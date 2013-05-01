namespace Endjin.Core.Composition.Contracts
{
    public interface INamedFactory<T>
    {
        T Create(string name);
    }
}