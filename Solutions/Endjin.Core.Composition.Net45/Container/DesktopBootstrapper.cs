namespace Endjin.Core.Container
{
    #region Using statements

    using Endjin.Core.Composition;
    using Endjin.Core.ResourceRegistration.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    #endregion

    public class DesktopBootstrapper : IBootstrapper
    {
        public Task<IEnumerable<IInstaller>> GetInstallersAsync()
        {
            return InstallerHelpers.GetInstallersAsync(AssemblyHelpers.GetAssemblyList(AppDomain.CurrentDomain.BaseDirectory));
        }

        public Task RegisterResourcesAsync()
        {
            return Task.Factory.StartNew(() =>
                {

                    var assemblies = AssemblyHelpers.GetAssemblyList(AppDomain.CurrentDomain.BaseDirectory);
                    var registrars = ApplicationServiceLocator.Container.ResolveAll<IResourceRegistrar>();
                    var registry = ApplicationServiceLocator.Container.Resolve<IResourceRegistry>();
                    foreach (var assembly in assemblies)
                    {
                        foreach (var registrar in registrars)
                        {
                            registrar.RegisterResources(registry, assembly);
                        }
                    }
                });
        }
    }
}