[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Endjin.Core.Configuration.WebApiContainerConfig), "InitialiseContainer")]

namespace Endjin.Core.Configuration
{
    #region Using Directives

    using System;
    using System.Diagnostics;
    using System.Web.Http;

    using Endjin.Core.Bootstrapper;
    using Endjin.Core.Composition;
    using Endjin.Core.Composition.DependencyResolver;
    using Endjin.Core.Container;

    #endregion

    public class WebApiContainerConfig
    {
        public static IContainer InitialiseContainer()
        {
            return InitialiseContainerWithBootstrapper(new WebApiBootstrapper());
        }

        private static IContainer InitialiseContainerWithBootstrapper(IBootstrapper containerBootstrapper)
        {
            IContainer container = new Container();

            try
            {
                if (!ApplicationServiceLocator.IsInitializedSuccessfully)
                {
                    ApplicationServiceLocator.InitializeAsync(container, containerBootstrapper).Wait();
                }
                else
                {
                    container = ApplicationServiceLocator.Container;
                }
            }
            catch (Exception exception)
            {
                Trace.TraceError(exception.Message);
            }

            GlobalConfiguration.Configuration.DependencyResolver = new ContainerDependencyResolver(container);

            return container;
        }
    }
}