namespace Endjin.Core.Composition.Samples.Net45.Installers
{
    #region Using Directives

    using System.Linq;
    using System.Reflection;
    using System.Web.Http.Controllers;
    using System.Web.Mvc;
    using Endjin.Core.Container;

    #endregion

    public class ControllerInstaller : IInstaller
    {
        public void Install(IContainer container)
        {
            var controllers = Assembly.GetExecutingAssembly().GetExportedTypes().Where(x => typeof(IController).IsAssignableFrom(x) || typeof(IHttpController).IsAssignableFrom(x));

            foreach (var current in controllers)
            {
                // Register controllers with per web request lifestyle to avoid issue with MVC dependency resolver not releasing components.
                container.Register(Component.For(current).Named(current.FullName.ToLowerInvariant()).AsTransient());
            }
        }
    }
}