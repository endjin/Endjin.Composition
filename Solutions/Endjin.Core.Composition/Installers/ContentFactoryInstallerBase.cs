namespace Endjin.Core.Installers
{
    #region Using Directives

    using Endjin.Core.Container;

    #endregion 

    public abstract class ContentFactoryInstallerBase<T, TInterface> : IInstaller 
        where T : class, TInterface, new()        
    {
        public void Install(IContainer container)
        {
            TInterface contentFactory = new T();

            if (container.TryResolve<TInterface>() == null)
            {
                container.Register(Component.For<TInterface>().ImplementedBy(contentFactory).AsSingleton());
            }
            else
            {
                contentFactory = container.Resolve<TInterface>();
            }

            this.RegisterDefaultContent(contentFactory);
        }

        protected abstract void RegisterDefaultContent(TInterface contentFactory);
    }
}