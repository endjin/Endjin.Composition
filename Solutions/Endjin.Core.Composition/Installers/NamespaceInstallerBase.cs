namespace Endjin.Core.Installers
{
    #region Using statements

    using System.Linq;
    using System.Reflection;

    using Endjin.Core.Container;

    #endregion

    public abstract class NamespaceInstallerBase<TMarker> : IInstaller
    {
        private readonly string partialNamespace;

        protected NamespaceInstallerBase(string partialNamespace)
        {
            this.partialNamespace = partialNamespace;
        }

        public void Install(IContainer container)
        {
            container.Register(
                AllTypes.FromAssemblyContaining<TMarker>()
                        .WhereNamespaceContains(this.partialNamespace)
                        .WithService(Interfaces.DefaultInterface)
                        .AsSingletonIf(
                            r => !r.ComponentType.GetTypeInfo().GetCustomAttributes(typeof(TransientAttribute), true).Any())
                        .AsTransientIf(
                            r => r.ComponentType.GetTypeInfo().GetCustomAttributes(typeof(TransientAttribute), true).Any()));
        }
    }
}