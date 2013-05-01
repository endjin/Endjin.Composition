namespace Endjin.Core.Composition
{
    using Endjin.Core.Composition.Contracts;

    public abstract class Factory<T> : IFactory<T>
    {
        public virtual T Create()
        {
            return ApplicationServiceLocator.Container.Resolve<T>();
        }
    }
}