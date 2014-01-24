namespace Endjin.Core.Container
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public static class Component
    {
         public static IEnumerable<ComponentRegistration> For<T>()
         {
             var componentType = typeof(T);
             return For(componentType);
         }

         public static IEnumerable<ComponentRegistration> For(Type componentType
#if NET45
             , [CallerFilePath] string sourceFilePath = ""
#endif
             )
         {
             return new[]
                 {
                     new ComponentRegistration
                         {
#if NET45
                             InstalledBy = sourceFilePath,
#endif
                             ComponentType = componentType, 
                             RegistrationTypes = new List<Type> { componentType },
                             Name = componentType.Name,
                             Lifestyle = Lifestyle.Singleton
                         }
                 };
         }
    }
}