namespace Endjin.Core.Container
{
    #region Using statements

    using Endjin.Core.Composition;
    using Endjin.Core.Composition.Contracts;
    using Endjin.Core.ResourceRegistration.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    #endregion Using statements

    public class WinRtBootstrapper : IBootstrapper
    {
        private IEnumerable<Assembly> assemblies;

        public async Task<IEnumerable<IInstaller>> GetInstallersAsync()
        {
            assemblies = await AssemblyHelpers.GetAssemblyList();
            return await InstallerHelpers.GetInstallersAsync(assemblies);
        }

        public void RegisterContent()
        {
            foreach (var assembly in assemblies)
            {
                RegisterAttributedContent(assembly);
            }
        }

        public Task RegisterResourcesAsync()
        {
            var registrars = ApplicationServiceLocator.Container.ResolveAll<IResourceRegistrar>();
            var registry = ApplicationServiceLocator.Container.Resolve<IResourceRegistry>();
            foreach (var assembly in assemblies)
            {
                foreach (var registrar in registrars)
                {
                    registrar.RegisterResources(registry, assembly);
                }
            }

            return Task.FromResult(0);
        }

        private void RegisterAttributedContent(Assembly assembly)
        {
            var types = assembly.GetExportedTypes().ToList();
            foreach (var t in types)
            {
                var attributes = t.GetTypeInfo().GetCustomAttributes<RegisterAsContentAttribute>().ToList();
                foreach (var a in attributes)
                {
                    var contentFactory = ApplicationServiceLocator.Container.Resolve(a.ContentFactoryInterface) as IContentFactory;
                    contentFactory.RegisterContentFor(t, a.ContentType);
                }
            }
        }
    }
}