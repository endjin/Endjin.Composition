namespace Endjin.Core.Installers
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Web.Http.Controllers;
    using System.Web.Mvc;
    using Endjin.Core.Container;

    public class ControllerInstaller : IInstaller
    {
        public void Install(IContainer container)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (var assembly in assemblies)
            {
                var controllers = assembly.GetExportedTypes().Where(x => !(x.IsGenericType && x.ContainsGenericParameters) && !x.IsAbstract && !x.IsInterface && (typeof(IController).IsAssignableFrom(x) || typeof(IHttpController).IsAssignableFrom(x)));

                foreach (var current in controllers)
                {
                    container.Register(Component.For(current).Named(current.FullName.ToLowerInvariant()).AsTransient());
                }
            }
        }
    }
}