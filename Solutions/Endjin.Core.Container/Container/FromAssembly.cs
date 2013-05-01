namespace Endjin.Core.Container
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public static class AllTypes
    {
        public static IEnumerable<ComponentRegistration> FromAssemblyContaining<T>()
        {
            return FromAssembly(typeof(T).GetTypeInfo().Assembly);
        }

        public static IEnumerable<ComponentRegistration> FromAssembly(Assembly assembly)
        {
            return assembly.GetExportedTypes().Where(t =>
            {
                var typeInfo = t.GetTypeInfo();
                return typeInfo.IsClass && !typeInfo.ContainsGenericParameters && !typeInfo.IsAbstract;
            }).Select(t => new ComponentRegistration
                {
                    ComponentType = t, 
                    RegistrationTypes = new List<Type> { t }, 
                    Name = t.Name, 
                    Lifestyle = Lifestyle.Singleton
                });
        }
    }
}