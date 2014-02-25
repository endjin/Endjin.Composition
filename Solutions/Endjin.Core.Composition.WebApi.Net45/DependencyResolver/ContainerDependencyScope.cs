namespace Endjin.Core.Composition.DependencyResolver
{
    #region Using Directives

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http.Dependencies;

    #endregion

    public class ContainerDependencyScope : IDependencyScope
    {
        private readonly IDependencyScope scope;

        private readonly Action<object> release;

        private readonly List<object> instances;

        public ContainerDependencyScope(IDependencyScope scope, Action<object> release)
        {
            if (scope == null)
            {
                throw new ArgumentNullException("scope");
            }

            if (release == null)
            {
                throw new ArgumentNullException("release");
            }

            this.scope = scope;
            this.release = release;
            this.instances = new List<object>();
        }

        public object GetService(Type t)
        {
            object service = this.scope.GetService(t);
            this.AddToScope(service);

            return service;
        }

        public IEnumerable<object> GetServices(Type t)
        {
            var services = this.scope.GetServices(t);
            this.AddToScope(services);

            return services;
        }

        public void Dispose()
        {
            foreach (object instance in this.instances)
            {
                this.release(instance);
            }

            this.instances.Clear();
        }

        private void AddToScope(params object[] services)
        {
            if (services.Any())
            {
                this.instances.AddRange(services);
            }
        }
    }
}