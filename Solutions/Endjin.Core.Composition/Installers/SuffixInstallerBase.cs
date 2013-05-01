namespace Endjin.Core.Installers
{
    #region Using statements

    using System.Linq;
    using System.Reflection;

    using Endjin.Core.Container;

    #endregion

    public abstract class SuffixInstallerBase<TMarker> : IInstaller
    {
        private readonly string suffix;

        protected SuffixInstallerBase(string suffix)
        {
            this.suffix = suffix;
        }

        public void Install(IContainer container)
        {
            container.Register(
                AllTypes.FromAssemblyContaining<TMarker>().WhereNameEndsWith(this.suffix)
                .WithService(Interfaces.DefaultInterface)
                .AsSingletonIf(
                        r => r.ComponentType.GetTypeInfo().GetCustomAttributes(typeof(SingletonAttribute), true).Any())
                .AsTransientIf(
                        r => !r.ComponentType.GetTypeInfo().GetCustomAttributes(typeof(SingletonAttribute), true).Any()));

        }
    }
}