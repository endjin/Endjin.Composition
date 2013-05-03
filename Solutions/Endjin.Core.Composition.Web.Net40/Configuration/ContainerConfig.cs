[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Endjin.Core.Configuration.ContainerConfig), "InitialiseContainer")]

namespace Endjin.Core.Configuration
{
    #region Using Directives

    using System;
    using System.Diagnostics;
    using System.Web.Http;
    using System.Web.Mvc;
    using Endjin.Core.Composition;
    using Endjin.Core.Composition.DependencyResolver;
    using Endjin.Core.Container;

    #endregion

    public class ContainerConfig
    {
        public static IContainer InitialiseContainer()
        {
            return InitialiseContainerWithBootstrapper(new WebBootstrapper());
        }

        private static IContainer InitialiseContainerWithBootstrapper(IBootstrapper containerBootstrapper)
        {
            var container = new Container();

            try
            {
                ApplicationServiceLocator.InitializeAsync(container, containerBootstrapper).Wait();
                

                // WebAPI
                GlobalConfiguration.Configuration.DependencyResolver = new ContainerDependencyResolver(container);

                // MVC
                DependencyResolver.SetResolver(
                    x => container.HasComponent(x) ? container.Resolve(x) : null,
                    x => container.HasComponent(x) ? container.ResolveAll(x) : new object[0]);
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }

            return container;
        }
    }
}