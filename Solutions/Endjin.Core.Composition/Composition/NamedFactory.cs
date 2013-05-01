namespace Endjin.Core.Composition
{
    using Endjin.Core.Composition.Contracts;

    public abstract class NamedFactory<T> : INamedFactory<T>
    {
        public virtual T Create(string name)
        {
            return ApplicationServiceLocator.Container.Resolve<T>(name);
        }
    }
}