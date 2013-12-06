namespace Endjin.Core.Container
{
    using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

    public interface IContainer
    {
        bool HasComponent<T>();

        bool HasComponent(Type type);

        Task InstallAsync(IBootstrapper bootstrapper);

        void Register(IEnumerable<ComponentRegistration> registrations);

        T Resolve<T>();

        T Resolve<T>(Type type);

        T Resolve<T>(string name);

        object Resolve(string name);

        object Resolve(Type type);

        IEnumerable<T> ResolveAll<T>();

        IEnumerable<object> ResolveAll(Type type);

        IEnumerable<T> ResolveAll<T>(string name);

        IEnumerable<object> ResolveAll(Type type, string name);

        void Shutdown();

        T TryResolve<T>();

        T TryResolve<T>(string name);

        object TryResolve(Type type);

        object TryResolve(Type type, string name);

        ReadOnlyCollection<ComponentRegistration> MisconfiguredComponents { get; }
    }
}
