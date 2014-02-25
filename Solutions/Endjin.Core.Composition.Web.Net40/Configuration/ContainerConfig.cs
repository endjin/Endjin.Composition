[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Endjin.Core.Configuration.ContainerConfig), "InitialiseContainer")]

namespace Endjin.Core.Configuration
{
    #region Using Directives

    using System;
    using System.Diagnostics;
    using System.Web.Mvc;
    using Endjin.Core.Composition;
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

                DependencyResolver.SetResolver(
                    x => container.HasComponent(x) ? container.Resolve(x) : null,
                    x => container.HasComponent(x) ? container.ResolveAll(x) : new object[0]);
            }
            catch (Exception exception)
            {
                Trace.TraceError(exception.Message);
            }

            return container;
        }
    }
}