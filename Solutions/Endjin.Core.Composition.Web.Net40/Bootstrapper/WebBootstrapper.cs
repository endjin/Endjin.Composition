namespace Endjin.Core.Container
{
    using System;

    #region Using Directives

    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Web;

    using Endjin.Core.Composition;
    using Endjin.Core.ResourceRegistration.Contracts;
    using System.Reflection;
    using System.Linq;
    using Endjin.Core.Composition.Contracts;

    #endregion Using Directives

    public class WebBootstrapper : IBootstrapper
    {
        public Task<IEnumerable<IInstaller>> GetInstallersAsync()
        {
            return InstallerHelpers.GetInstallersAsync(AssemblyHelpers.GetAssemblyList(HttpRuntime.BinDirectory));
        }

        public void RegisterContent()
        {
            var assemblies = AssemblyHelpers.GetAssemblyList(HttpRuntime.BinDirectory);
            foreach (var assembly in assemblies)
            {
                RegisterAttributedContent(assembly);
            }
        }

        public Task RegisterResourcesAsync()
        {
            return Task.Factory.StartNew(() =>
            {
                var assemblies = AssemblyHelpers.GetAssemblyList(HttpRuntime.BinDirectory);
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

        private void RegisterAttributedContent(Assembly assembly)
        {
            assembly.TryGetExportedTypes().ToList().ForEach(t =>
            {
                Attribute.GetCustomAttributes(t).Where(a => typeof(RegisterAsContentAttribute).IsAssignableFrom(a.GetType())).Cast<RegisterAsContentAttribute>().ToList().ForEach(a =>
                {
                    var contentFactory = ApplicationServiceLocator.Container.Resolve(a.ContentFactoryInterface) as IContentFactory;
                    contentFactory.RegisterContentFor(t, a.ContentType);
                });
            });
        }
    }
}