namespace Endjin.Core.Container
{
    using System;
    using System.Collections.Generic;

    public static class Component
    {
         public static IEnumerable<ComponentRegistration> For<T>()
         {
             var componentType = typeof(T);
             return For(componentType);
         }

         public static IEnumerable<ComponentRegistration> For(Type componentType)
         {
             return new[]
                 {
                     new ComponentRegistration
                         {
                             ComponentType = componentType, 
                             RegistrationTypes = new List<Type> { componentType },
                             Name = componentType.Name,
                             Lifestyle = Lifestyle.Singleton
                         }
                 };
         }
    }
}