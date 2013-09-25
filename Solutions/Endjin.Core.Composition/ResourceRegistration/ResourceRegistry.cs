namespace Endjin.Core.ResourceRegistration
{
    using System.Linq;
    using Endjin.Core.Installers;
    using Endjin.Core.ResourceRegistration.Contracts;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;

    [Singleton]
    public class ResourceRegistry : IResourceRegistry
    {
        private Dictionary<string, ResourceRegistration> registrations = new Dictionary<string, ResourceRegistration>();
        private Dictionary<string, List<ResourceRegistration>> collisions = new Dictionary<string, List<ResourceRegistration>>();

        public void RegisterResource(string name, Assembly assembly, string resourceKey)
        {
            var registration = new ResourceRegistration { Assembly = assembly, Name = resourceKey};
            if (!registrations.ContainsKey(name))
            {
                registrations.Add(name, registration);
            }
            else
            {
                RegisterCollision(name, registration);
            }
        }

        public Stream GetResource(string name)
        {
            ResourceRegistration registration;
            if (!registrations.TryGetValue(name, out registration))
            {
                return null;
            }

            return registration.Assembly.GetManifestResourceStream(registration.Name);
        }

        public bool ResourceExists(string name)
        {
            return registrations.ContainsKey(name);
        }

        public IEnumerable<string> GetResourcesAt(string root)
        {
            return registrations.Keys.Where(k => GetPathRoot(k) == root.ToLowerInvariant());
        }

        public bool ResourceDirectoryExists(string root)
        {
            return registrations.Keys.Any(k => GetPathRoot(k) == root.ToLowerInvariant());
        }

        private string GetPathRoot(string path)
        {
            return path.Substring(path.LastIndexOf('/')).ToLowerInvariant();
        }

        private void RegisterCollision(string name, ResourceRegistration registration)
        {
            // We maintain an internal list of resource collisions for debugging purposes.
            // In a successfully configured system, this should be empty.
            List<ResourceRegistration> registrations;
            if (!collisions.TryGetValue(name, out registrations))
            {
                registrations = new List<ResourceRegistration>();
                collisions.Add(name, registrations);
            }
            registrations.Add(registration);
        }

        internal class ResourceRegistration
        {
            public Assembly Assembly { get; set; }

            public string Name { get; set; }
        }
    }
}
