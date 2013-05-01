namespace Endjin.Core.Container
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IContainer
    {
        Task InstallAsync(IBootstrapper bootstrapper);

        void Shutdown();

        T Resolve<T>();

        T Resolve<T>(Type type);

        IEnumerable<T> ResolveAll<T>();

        IEnumerable<object> ResolveAll(Type type);

        IEnumerable<T> ResolveAll<T>(string name);

        IEnumerable<object> ResolveAll(Type type, string name);

        T Resolve<T>(string name);

        object Resolve(string name);

        object Resolve(Type type);

        void Register(IEnumerable<ComponentRegistration> registrations);

        T TryResolve<T>();

        object TryResolve(Type type);

        bool HasComponent<T>();

        bool HasComponent(Type type);
    }
}
