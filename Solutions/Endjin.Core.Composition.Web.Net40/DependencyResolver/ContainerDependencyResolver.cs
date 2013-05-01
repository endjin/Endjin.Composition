namespace Endjin.Core.Composition.DependencyResolver
{
    #region Using Directives

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http.Dependencies;

    using Endjin.Core.Container;

    #endregion

    public class ContainerDependencyResolver : IDependencyResolver
    {
        private readonly IContainer container;

        public ContainerDependencyResolver(IContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            this.container = container;
        }

        public object GetService(Type t)
        {
            return this.container.HasComponent(t) ? this.container.TryResolve(t) : null;
        }

        public IEnumerable<object> GetServices(Type t)
        {
            return this.container.HasComponent(t) ? this.container.ResolveAll(t).ToArray() : new object[] { };
        }

        public IDependencyScope BeginScope()
        {
            return new ContainerDependencyScope(this, this.ReleaseInstance);
        }

        public void Dispose()
        {
        }

        private void ReleaseInstance(object instance)
        {
            // TODO - Need to implement this in Endjin.Container?
        }
    }
}