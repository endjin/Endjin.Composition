using System;
namespace Endjin.Core.ResourceRegistration.Contracts
{
    using System.Reflection;

    public interface IResourceRegistrar
    {
        void RegisterResources(IResourceRegistry registry, Assembly assembly);
    }
}
