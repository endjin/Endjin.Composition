namespace Endjin.Core.Container
{
    using System.Collections.Generic;

    public static class ContainerExtensions
    {
        public static IEnumerable<T> TryResolveAll<T>(this IContainer container)
        {
            if (container.HasComponent<T>())
            {
                return container.ResolveAll<T>();
            }

            return new List<T>();
        }
    }
}