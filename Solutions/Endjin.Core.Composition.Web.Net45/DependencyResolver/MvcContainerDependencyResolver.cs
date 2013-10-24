namespace Endjin.Core.Composition.DependencyResolver
{
    #region Using Directives

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Endjin.Core.Container;

    #endregion

    public class MvcContainerDependencyResolver : IDependencyResolver
    {
        private readonly IContainer container;

        public MvcContainerDependencyResolver(IContainer container)
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
    }
}