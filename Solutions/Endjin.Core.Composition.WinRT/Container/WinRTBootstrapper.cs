namespace Endjin.Core.Container
{
    #region Using statements

    using Endjin.Core.Composition;
    using Endjin.Core.ResourceRegistration.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    #endregion

    public class WinRtBootstrapper : IBootstrapper
    {
        public async Task<IEnumerable<IInstaller>> GetInstallersAsync()
        {
            var assemblies = await AssemblyHelpers.GetAssemblyList();
            return await InstallerHelpers.GetInstallersAsync(assemblies);
        }

        public async Task RegisterResourcesAsync()
        {
            var assemblies = await AssemblyHelpers.GetAssemblyList();
            var registrars = ApplicationServiceLocator.Container.ResolveAll<IResourceRegistrar>();
            var registry = ApplicationServiceLocator.Container.Resolve<IResourceRegistry>();
            foreach (var assembly in assemblies)
            {
                foreach (var registrar in registrars)
                {
                    registrar.RegisterResources(registry, assembly);
                }
            }
        }
    }
}