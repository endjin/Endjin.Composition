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

    public class DesktopBootstrapper : IBootstrapper
    {
        public Task<IEnumerable<IInstaller>> GetInstallersAsync()
        {
            return InstallerHelpers.GetInstallersAsync(AssemblyHelpers.GetAssemblyList(AppDomain.CurrentDomain.BaseDirectory));
        }

        public void RegisterContent()
        {
            var assemblies = AssemblyHelpers.GetAssemblyList(AppDomain.CurrentDomain.BaseDirectory);
            foreach (var assembly in assemblies)
            {
                RegisterAttributedContent(assembly);
            }
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

        private void RegisterAttributedContent(Assembly assembly)
        {
            assembly.GetExportedTypes().ToList().ForEach(t =>
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