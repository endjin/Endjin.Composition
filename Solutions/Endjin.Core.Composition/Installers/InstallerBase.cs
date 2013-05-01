namespace Endjin.Core.Installers
{
    #region Using directives

    using System.Linq;
    using System.Reflection;

    using Endjin.Core.Container;

    #endregion

    /// <summary>
    /// A base class for installers
    /// </summary>
    public abstract class InstallerBase<T, TMarker> : IInstaller
    {
        /// <summary>
        /// Installs components into the container
        /// </summary>
        /// <param name="container">The container into which to install the components</param>
        public void Install(IContainer container)
        {
            container.Register(
                AllTypes.FromAssemblyContaining<TMarker>().BasedOn<T>().WithService(Interfaces.AllInterfaces)
                    .AsSingletonIf(
                        r => r.ComponentType.GetTypeInfo().GetCustomAttributes(typeof(SingletonAttribute), true).Any())
                    .AsTransientIf(
                        r => !r.ComponentType.GetTypeInfo().GetCustomAttributes(typeof(SingletonAttribute), true).Any()));
        }
    }
}