namespace Endjin.Core.Container
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    public static class AllTypes
    {
        public static IEnumerable<ComponentRegistration> FromAssemblyContaining<T>()
        {
            return FromAssembly(typeof(T).GetTypeInfo().Assembly);
        }

        public static IEnumerable<ComponentRegistration> FromAssembly(Assembly assembly
#if NET45
            , [CallerFilePath] string sourceFilePath = ""
#endif
            )
        {
            return assembly.TryGetExportedTypes().Where(t =>
            {
                var typeInfo = t.GetTypeInfo();
                return typeInfo.IsClass && !typeInfo.ContainsGenericParameters && !typeInfo.IsAbstract;
            }).Select(t => new ComponentRegistration
            {
#if NET45
                InstalledBy = sourceFilePath,
#endif
                ComponentType = t,
                RegistrationTypes = new List<Type> { t },
                Name = t.Name,
                Lifestyle = Lifestyle.Singleton
            });
        }
    }
}