
namespace Endjin.Core.ResourceRegistration.Contracts
{
    using System.IO;
    using System.Reflection;

    public interface IResourceRegistry
    {
        void RegisterResource(string name, Assembly assembly, string resourceKey);
        Stream GetResource(string name);

        bool ResourceExists(string name);
    }
}
