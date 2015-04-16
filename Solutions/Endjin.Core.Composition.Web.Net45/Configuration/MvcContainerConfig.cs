[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Endjin.Core.Configuration.MvcContainerConfig), "InitialiseContainer")]

namespace Endjin.Core.Configuration
{
    #region Using Directives

    using System;
    using System.Diagnostics;
    using System.Web.Mvc;
    using Endjin.Core.Composition;
    using Endjin.Core.Container;

    #endregion

    public class MvcContainerConfig
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
            }
            catch (Exception exception)
            {
                Trace.TraceError(exception.Message);
            }

            DependencyResolver.SetResolver(
                x => container.HasComponent(x) ? container.Resolve(x) : null,
                x => container.HasComponent(x) ? container.ResolveAll(x) : new object[0]);

            return container;
        }
    }
}