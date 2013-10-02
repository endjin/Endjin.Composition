namespace Endjin.Core.Container
{
    #region Using statements

    using Endjin.Core.Composition;
    using Endjin.Core.ResourceRegistration.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    #endregion

    public class Wp8Bootstrapper : IBootstrapper
    {
        public Task<IEnumerable<IInstaller>> GetInstallersAsync()
        {
            return InstallerHelpers.GetInstallersAsync(AssemblyHelpers.GetAssemblyList());
        }

        public Task RegisterResourcesAsync()
        {
            return Task.Factory.StartNew(() =>
            {

                var assemblies = AssemblyHelpers.GetAssemblyList();
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